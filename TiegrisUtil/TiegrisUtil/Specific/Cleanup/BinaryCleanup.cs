using System;
using System.Collections.Generic;
using System.IO;
using TiegrisUtil.Unit;

namespace TiegrisUtil.Specific.Cleanup
{
    /// <summary>
    /// Cleans up you programming project folders, by finding unnecessary folders (eg.: bin, obj)
    /// </summary>
    public class BinaryCleanup
    {
        private readonly List<DirectoryInfo> results = new List<DirectoryInfo>();
        private readonly string[] searchTags = new string[] { "bin", "obj" };
        public int Count => results.Count;
        public IReadOnlyList<DirectoryInfo> ListAll() => results;

        #region contructors
        /// <summary>
        /// Recursively searches for folders in the root directory.
        /// Adds them to a list, if their name matches one of those defined in searchTags.
        /// </summary>
        /// <param name="root">The root Directory of the search.</param>
        /// <param name="searchTags">Look for these folder names.</param>
        public BinaryCleanup(DirectoryInfo root, string[] searchTags) {
            this.searchTags = searchTags;
            search(root);
        }
        /// <summary>
        /// Recursively searches for folders in the root directory.
        /// Adds them to a list, if their name matches 'bin' or 'obj'.
        /// </summary>
        /// <param name="root">The root Directory of the search.</param>
        public BinaryCleanup(DirectoryInfo root) {
            search(root);
        }
        /// <summary>
        /// Recursively searches for folders in the root directory.
        /// Adds them to a list, if their name matches 'bin' or 'obj'.
        /// </summary>
        /// <param name="rootPath">The root Directory of the search. Atempts to parse it from string.</param>
        public BinaryCleanup(string rootPath) {
            DirectoryInfo root;
            if (Directory.Exists(rootPath))
                root = new DirectoryInfo(rootPath);
            else
                throw new ArgumentException("Path specified in constructor argument is not a valid directory.");
            search(root);
        }
        #endregion

        #region public funtions
        public void DeleteAll() {
            for (int i = 0; i < results.Count; i++)
                results[i].Delete(true);
            results.Clear();
        }

        public void Delete(int i) {
            if (i >= 0 && i < results.Count) {
                results[i].Delete(true);
                results.RemoveAt(i);
            } else throw new ArgumentOutOfRangeException($"{i} is out of range [0; {results.Count}[.");
        }      

        public long GetTotalSize() {
            long ret = 0;
            foreach (var item in results) 
                ret += dirSize(item);
            return ret;
        }

        public long GetSize(int i) {
            if (i >= 0 && i < results.Count) {
                return dirSize(results[i]);
            } else throw new ArgumentOutOfRangeException($"{i} is out of range [0; {results.Count}[.");
        }

        public string GetTotalSizeAsHumanReadable(int decimals = 2) {
            DataSize size = new DataSize(GetTotalSize());
            return $"{formatedDouble(size.GetHumanReadableValue(), decimals)} {size.GetHumanReadableUnit()}";
        }

        public string GetSizeAsHumanReadable(int i, int decimals = 2) {
            DataSize size = new DataSize(GetSize(i));
            return $"{formatedDouble(size.GetHumanReadableValue(), decimals)} {size.GetHumanReadableUnit()}";
        }
        #endregion

        #region private funtions
        private bool isSearched(string name) {
            foreach (var tag in searchTags)
                if (tag == name)
                    return true;
            return false;
        }        

        private void search(DirectoryInfo localRoot) {
            DirectoryInfo[] children = localRoot.GetDirectories();
            foreach (var item in children) {
                if (isSearched(item.Name))
                    results.Add(item);
                else
                    search(item);
            }
        }

        private long dirSize(DirectoryInfo d) {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis) 
                size += fi.Length;
            
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis) 
                size += dirSize(di);
            
            return size;
        }

        private string formatedDouble(double number, int decimals = 2) =>
            string.Format("{0:N" + System.Math.Abs(decimals) + "}", number);
        #endregion
    }
}

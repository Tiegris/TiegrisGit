using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace TiegrisUtil.Frameworks
{
    public static class SpecialPaths
    {
        static public string CompanyName => "TigriSoft";

        public static Guid AppGuid {
            get {
                Assembly asm = Assembly.GetEntryAssembly();
                object[] attr = (asm.GetCustomAttributes(typeof(GuidAttribute), true));
                return new Guid((attr[0] as GuidAttribute).Value);
            }
        }

        public static string CompanyAppDataFolder { 
            get {
                var path = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                    CompanyName);
                return path;
            }
        }

        public static string ApplicationAppDataFolder {
            get {
                return Path.Combine(CompanyAppDataFolder, AppGuid.ToString("B").ToUpper());
            }
        }

        public static string GetApplicationDataFilePath(string fileName, bool create = true) {
            string path =  Path.Combine(ApplicationAppDataFolder, fileName);
            if (create && !File.Exists(path))
                createFolderAndFile(path);            
            return path;
        }

        public static void CreateApplicationDataFile(string fileName, bool overwrite = false) {
            string path = Path.Combine(ApplicationAppDataFolder, fileName);
            if (overwrite || !File.Exists(path))
                createFolderAndFile(path);            
        }
        
        private static void createFolderAndFile(string fileName) {
            string dir = ApplicationAppDataFolder;
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            using (var s = File.Create(fileName)) { }                
        }
    }
}

using System;
using System.Windows;

namespace TiegrisUtil.Frameworks
{

    /// <summary>
    /// Uniform popup messages.
    /// </summary>
    public class Notifications
    {
        /// <summary>
        /// Shows a warning notification on the screen, with the given message.
        /// </summary>
        /// <param name="s">The message.</param>
        static public void ShowWarning(string s = "") {
            MessageBox.Show(s, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Use as placeholder in not implemented functions. Show a message, with the given text.
        /// </summary>
        /// <param name="s">The message.</param>
        static public void ShowNotImplemented(string s = "This feature is not implemented yet.") {
            MessageBox.Show(s, "Not implemented", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Shows an error notification on the screen, with the given message.
        /// </summary>
        /// <param name="s">The message.</param>
        static public void ShowError(string s = "") {
            MessageBox.Show(s, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

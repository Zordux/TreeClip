using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FolderLayoutApp
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        [STAThread]
        static void Main(string[] args)
        {
            // Hide console window for a cleaner UI
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            // Ensure a valid folder path is provided
            if (args.Length == 0 || !Directory.Exists(args[0]))
            {
                MessageBox.Show("Please provide a valid folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = args[0];
            string folderName = Path.GetFileName(folderPath);

            // Generate layout, copy to clipboard, and notify user
            string layout = $"📁 {folderName}\n" + GetFolderLayout(folderPath, "   │");
            Clipboard.SetText(layout);
            MessageBox.Show("Folder layout copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static string GetFolderLayout(string path, string prefix = "")
        {
            StringBuilder layout = new StringBuilder();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                var directories = dirInfo.GetDirectories();
                var files = dirInfo.GetFiles();

                // List directories first
                for (int i = 0; i < directories.Length; i++)
                {
                    bool isLastDirectory = (i == directories.Length - 1) && files.Length == 0;
                    string newPrefix = isLastDirectory ? "   " : "│  ";
                    string connector = isLastDirectory ? "└──" : "├──";

                    layout.AppendLine($"{prefix}{connector} 📁 {directories[i].Name}");
                    layout.Append(GetFolderLayout(directories[i].FullName, prefix + newPrefix));
                }

                // List files last
                for (int i = 0; i < files.Length; i++)
                {
                    bool isLastFile = i == files.Length - 1;
                    string connector = isLastFile ? "└──" : "├──";
                    layout.AppendLine($"{prefix}{connector} 📄 {files[i].Name}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                layout.AppendLine($"{prefix}└── 🔒 Access Denied");
            }
            catch (Exception ex)
            {
                layout.AppendLine($"{prefix}└── ⚠️ Error: {ex.Message}");
            }

            return layout.ToString();
        }
    }
}

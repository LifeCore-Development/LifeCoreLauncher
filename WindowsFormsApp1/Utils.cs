using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Utils
    {
        public static string GetFiveMPath()
        {
            string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string shortcutPath = Path.Combine(startMenuPath, "Programs", "FiveM.lnk");

            if (!File.Exists(shortcutPath))
            {
                return null;
            }

            // COM access is a bit gross, but meh
            dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell"));
            dynamic shortcut = shell.CreateShortcut(shortcutPath);

            string directoryPath = Path.GetDirectoryName(shortcut.TargetPath);

            return directoryPath;
        }
    }
}

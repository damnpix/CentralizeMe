using Microsoft.Win32;
using System.Linq;
using System.Windows.Forms;

namespace CentralizeMe.data
{
    internal class startup
    {
        public static void Logic(bool value)
        {
            if (value) AddToStartup();
            else RemoveFromStartup();
        }

        static void AddToStartup()
        {
            string appPath = Application.ExecutablePath;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(constants.APPLICATION_NAME, appPath);
            registryKey.Close();
        }

        static void RemoveFromStartup()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (registryKey != null)
            {
                registryKey.DeleteValue(constants.APPLICATION_NAME, false);
                registryKey.Close();
            }
        }

        public static bool AddedToStartup()
        {
            return (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                true).GetValueNames().Contains(constants.APPLICATION_NAME));
        }
    }
}

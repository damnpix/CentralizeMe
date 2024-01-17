using System.Windows.Forms;

namespace CentralizeMe.data
{
    internal class hotkeys
    {
        struct all_hotkeys
        {
            public static bool ctrl_alt => Control.ModifierKeys.HasFlag(Keys.Control)
                && Control.ModifierKeys.HasFlag(Keys.Alt);
            public static bool ctrl_shift => Control.ModifierKeys.HasFlag(Keys.Control)
                && Control.ModifierKeys.HasFlag(Keys.Shift);
        };

        public static bool SelectHotkey(string name)
        {
            switch (name)
            {
                case "ctrlAlt":
                    return all_hotkeys.ctrl_alt;
                case "ctrlShift":
                    return all_hotkeys.ctrl_shift;
            }
            return false;
        }
    }
}

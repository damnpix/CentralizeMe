// CODE MADE BY @SPLIFFJAPAN
using CentralizeMe.data;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAPI;

namespace CentralizeMe
{
    public partial class MainForm : Form
    {
        void Form_Load(object sender, EventArgs e)
        {
            //Hide window
            ShowInTaskbar = false;
            Hide();
            formSettings.HideFromAltTab(Handle);
        }
        public MainForm()
        {
            InitializeComponent();

            //Change theme
            uxtheme.ChangeTheme();

            //Add elements to context menu
            contextMenu.MenuItems.Add("Exit", (sender, e) => Application.Exit());

            //Tray icon
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.BalloonTipText = "Made by @spliffjapan ";
            notifyIcon.BalloonTipTitle = constants.APPLICATION_NAME;
            notifyIcon.ShowBalloonTip(6);

            //Background Thread
            Thread thread = new Thread(async () =>
            {
                while (true)
                {
                    await Task.Delay(constants.UPDATE_TIME);

                    //Read settings
                    settingsFile.Read();

                    //Startup
                    startup.Logic(settingsFile.startupOption);

                    if (hotkeys.SelectHotkey(settingsFile.hotkeyOption))
                    {
                            IntPtr activeWindow = user32.GetForegroundWindow();
                            user32.RECT rect = new user32.RECT();
                            user32.GetWindowRect(user32.GetForegroundWindow(), ref rect);
                            Point centerOfScreen = new Point((Screen.PrimaryScreen.Bounds.Width - rect.Width) / 2,
                                (Screen.PrimaryScreen.Bounds.Height - rect.Height) / 2);
                            user32.SetWindowPos(activeWindow, IntPtr.Zero, centerOfScreen.X, centerOfScreen.Y, 0, 0,
                                constants.SWP_NOSIZE | constants.SWP_NOZORDER);
                    }
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }
    }
}

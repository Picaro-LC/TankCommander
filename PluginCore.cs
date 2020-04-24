using System;
using System.Runtime.InteropServices;
using Decal.Adapter.Wrappers;

namespace TankCommander
{
    [Decal.Adapter.FriendlyName("Tank Commander")]
    public partial class PluginCore: Decal.Adapter.PluginBase
    {
        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        public static IntPtr MyHwnd = FindWindow("Turbine Device Class", "Asheron's Call");
        public bool IsCommander = false;
        public bool LineUpActive = false;

        private static string PLUGIN = "TankCommander"; //Test
        internal static PluginHost MyHost;

        protected override void Startup()
        {
            MyHost = Host;
            ViewInit();
            initChatEvents();
            initLoginEvents();
        }

        protected override void Shutdown()
        {
            destroyLoginEvents();
            destroyChatEvents();
            ViewDestroy();
            MyHost = null;
        }
    }
}

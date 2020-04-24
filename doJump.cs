using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TankCommander
{
    public partial class PluginCore
    {
        enum eJumpState
        {
            SHUTDOWN, IDLE, KEY_DN, KEY_UP, KEY_WAIT
        }

        private Timer KeyPressTimer;
        private eJumpState JumpState = eJumpState.SHUTDOWN;
        public static uint MyWpDirDn = 0x0;
        public static uint MyLpDirDn = 0x0;
        public static uint MyLpDirUp = 0x0;
        public static int MyJumpStyle = 0;

        public static int WM_KEYDN = 0x100;
        public static int WM_KEYUP = 0x101;
        public static int WM_CHAR = 0x102;

        public static uint WpDdn = 0x00000044;
        public static uint LpDdn = 0x00200001;
        public static uint LpDup = 0xC0200001;
        public static uint WpSHIFTdn = 0x00000041;
        public static uint WpSHIFTchar = 0x00000061;
        public static uint LpSHIFTdn = 0x001E0001;
        public static uint LpSHIFTup = 0xC01E0001;
        public static uint WpUPdn = 0x00000026;
        public static uint LpUPdn = 0x01480001;
        public static uint LpUPup = 0xC1480001;
        public static uint WpDOWNdn = 0x00000028;
        public static uint LpDOWNdn = 0x01500001;
        public static uint LpDOWNup = 0xC1500001;
        public static uint WpLEFTdn = 0x000000BC;
        public static uint LpLEFTdn = 0x00330001;
        public static uint LpLEFTup = 0xC0330001;
        public static uint WpRIGHTdn = 0x000000BE;
        public static uint LpRIGHTdn = 0x00340001;
        public static uint LpRIGHTup = 0xC0340001;

        public bool startKeyPress(int JumpStyle, int JumpPower)
        {
            if (JumpState == eJumpState.IDLE)
            {
                MyJumpStyle = JumpStyle;
                if (JumpStyle == 11 | JumpStyle == 21)
                {
                    MyWpDirDn = WpUPdn;
                    MyLpDirDn = LpUPdn;
                    MyLpDirUp = LpUPup;
                }
                else if (JumpStyle == 12 | JumpStyle == 22)
                {
                    MyWpDirDn = WpDOWNdn;
                    MyLpDirDn = LpDOWNdn;
                    MyLpDirUp = LpDOWNup;
                }
                else if (JumpStyle == 13 | JumpStyle == 23)
                {
                    MyWpDirDn = WpLEFTdn;
                    MyLpDirDn = LpLEFTdn;
                    MyLpDirUp = LpLEFTup;
                }
                else if (JumpStyle == 14 | JumpStyle == 24)
                {
                    MyWpDirDn = WpRIGHTdn;
                    MyLpDirDn = LpRIGHTdn;
                    MyLpDirUp = LpRIGHTup;
                }
                else
                { WriteToChat("Tank Commander: ", "Input Error on startKeyPress!"); }

                JumpState = eJumpState.KEY_DN;
                continueKeyPress();
                startKeyPressTimer(JumpPower);
                return true;
            }
            continueKeyPress();
            return false;
        }

        private void continueKeyPress()
        {
            if (JumpState != eJumpState.KEY_DN && JumpState != eJumpState.KEY_UP) return;
            switch (JumpState)
            {
                case eJumpState.KEY_DN: sendJumpKeyDown(); break;
                case eJumpState.KEY_UP: sendJumpKeyUp(); break;
            }
        }

        private void sendJumpKeyDown()
        {
            if (MyJumpStyle > 10 & MyJumpStyle < 15)
            { SendMessage(MyHwnd, WM_KEYDN, WpSHIFTdn, LpSHIFTdn); }
            SendMessage(MyHwnd, WM_KEYDN, WpDdn, LpDdn);
            SendMessage(MyHwnd, WM_KEYDN, MyWpDirDn, MyLpDirDn);
            JumpState = eJumpState.KEY_WAIT;
            return;
        }

        private void sendJumpKeyUp()
        {
            SendMessage(MyHwnd, WM_KEYUP, WpDdn, LpDup);
            SendMessage(MyHwnd, WM_KEYUP, MyWpDirDn, MyLpDirUp);
            if (MyJumpStyle > 10 & MyJumpStyle < 15)
            { SendMessage(MyHwnd, WM_KEYUP, WpSHIFTdn, LpSHIFTup); }
            stopKeyPressTimer();
        }
        
        protected void startKeyPressTimer(int myInterval)
        {
            if (KeyPressTimer == null)
            {
                KeyPressTimer = new Timer();
                KeyPressTimer.Interval = myInterval;
                KeyPressTimer.Tick += new EventHandler(KeyPressTimer_Tick);
            }
            KeyPressTimer.Start();
        }

        void KeyPressTimer_Tick(object sender, EventArgs e)
        {
            if (JumpState == eJumpState.IDLE)
            {
                stopKeyPressTimer();
            }
            else
            {
                JumpState = eJumpState.KEY_UP;
                continueKeyPress();
            }
        }

        protected void stopKeyPressTimer()
        {
            if (KeyPressTimer != null)
            {
                KeyPressTimer.Stop();
                KeyPressTimer.Dispose();
                KeyPressTimer = null;
            }
        }
    }
}
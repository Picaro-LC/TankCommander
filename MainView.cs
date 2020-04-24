using System;
using System.Windows.Forms;
using MyClasses.MetaViewWrappers;
using System.Runtime.InteropServices;
using Decal.Adapter.Wrappers;
using System.Collections.Generic;
using System.Collections;

namespace TankCommander
{
    public partial class PluginCore
    {
        static IView View;
        static IButton bLU1000;
        static IButton bSU1000;
        static IButton bLD1000;
        static IButton bSD1000;
        static IButton bLL1000;
        static IButton bSL1000;
        static IButton bLR1000;
        static IButton bSR1000;
        static IButton bLU0750;
        static IButton bSU0750;
        static IButton bLD0750;
        static IButton bSD0750;
        static IButton bLL0750;
        static IButton bSL0750;
        static IButton bLR0750;
        static IButton bSR0750;
        static IButton bLU0500;
        static IButton bSU0500;
        static IButton bLD0500;
        static IButton bSD0500;
        static IButton bLL0500;
        static IButton bSL0500;
        static IButton bLR0500;
        static IButton bSR0500;
        static IButton bLU0250;
        static IButton bSU0250;
        static IButton bLD0250;
        static IButton bSD0250;
        static IButton bLL0250;
        static IButton bSL0250;
        static IButton bLR0250;
        static IButton bSR0250;
        static IButton bLU0025;
        static IButton bSU0025;
        static IButton bLD0025;
        static IButton bSD0025;
        static IButton bLL0025;
        static IButton bSL0025;
        static IButton bLR0025;
        static IButton bSR0025;
        static IButton bTargetLockOn;
        static IButton bTargetLockOff;
        static IButton bLineup;
        static IButton bCombatmode;
        static IButton bPeacemode;
        public void ViewInit()
        {
            View = ViewSystemSelector.CreateViewResource(MyHost, "TankCommander.ViewXML.mainView.xml");
            bLU1000 = (IButton)View["bLU1000"];
            bSU1000 = (IButton)View["bSU1000"];
            bLD1000 = (IButton)View["bLD1000"];
            bSD1000 = (IButton)View["bSD1000"];
            bLL1000 = (IButton)View["bLL1000"];
            bSL1000 = (IButton)View["bSL1000"];
            bLR1000 = (IButton)View["bLR1000"];
            bSR1000 = (IButton)View["bSR1000"];
            bLU0750 = (IButton)View["bLU0750"];
            bSU0750 = (IButton)View["bSU0750"];
            bLD0750 = (IButton)View["bLD0750"];
            bSD0750 = (IButton)View["bSD0750"];
            bLL0750 = (IButton)View["bLL0750"];
            bSL0750 = (IButton)View["bSL0750"];
            bLR0750 = (IButton)View["bLR0750"];
            bSR0750 = (IButton)View["bSR0750"];
            bLU0500 = (IButton)View["bLU0500"];
            bSU0500 = (IButton)View["bSU0500"];
            bLD0500 = (IButton)View["bLD0500"];
            bSD0500 = (IButton)View["bSD0500"];
            bLL0500 = (IButton)View["bLL0500"];
            bSL0500 = (IButton)View["bSL0500"];
            bLR0500 = (IButton)View["bLR0500"];
            bSR0500 = (IButton)View["bSR0500"];
            bLU0250 = (IButton)View["bLU0250"];
            bSU0250 = (IButton)View["bSU0250"];
            bLD0250 = (IButton)View["bLD0250"];
            bSD0250 = (IButton)View["bSD0250"];
            bLL0250 = (IButton)View["bLL0250"];
            bSL0250 = (IButton)View["bSL0250"];
            bLR0250 = (IButton)View["bLR0250"];
            bSR0250 = (IButton)View["bSR0250"];
            bLU0025 = (IButton)View["bLU0025"];
            bSU0025 = (IButton)View["bSU0025"];
            bLD0025 = (IButton)View["bLD0025"];
            bSD0025 = (IButton)View["bSD0025"];
            bLL0025 = (IButton)View["bLL0025"];
            bSL0025 = (IButton)View["bSL0025"];
            bLR0025 = (IButton)View["bLR0025"];
            bSR0025 = (IButton)View["bSR0025"];
            bTargetLockOn = (IButton)View["bTargetLockOn"];
            bTargetLockOff = (IButton)View["bTargetLockOff"];
            bLineup = (IButton)View["bLineup"];
            bCombatmode = (IButton)View["bCombatmode"];
            bPeacemode = (IButton)View["bPeacemode"];
            
            bLU1000.Hit += new EventHandler(bLU1000_Hit);
            bSU1000.Hit += new EventHandler(bSU1000_Hit);
            bLD1000.Hit += new EventHandler(bLD1000_Hit);
            bSD1000.Hit += new EventHandler(bSD1000_Hit);
            bLL1000.Hit += new EventHandler(bLL1000_Hit);
            bSL1000.Hit += new EventHandler(bSL1000_Hit);
            bLR1000.Hit += new EventHandler(bLR1000_Hit);
            bSR1000.Hit += new EventHandler(bSR1000_Hit);
            bLU0750.Hit += new EventHandler(bLU0750_Hit);
            bSU0750.Hit += new EventHandler(bSU0750_Hit);
            bLD0750.Hit += new EventHandler(bLD0750_Hit);
            bSD0750.Hit += new EventHandler(bSD0750_Hit);
            bLL0750.Hit += new EventHandler(bLL0750_Hit);
            bSL0750.Hit += new EventHandler(bSL0750_Hit);
            bLR0750.Hit += new EventHandler(bLR0750_Hit);
            bSR0750.Hit += new EventHandler(bSR0750_Hit);
            bLU0500.Hit += new EventHandler(bLU0500_Hit);
            bSU0500.Hit += new EventHandler(bSU0500_Hit);
            bLD0500.Hit += new EventHandler(bLD0500_Hit);
            bSD0500.Hit += new EventHandler(bSD0500_Hit);
            bLL0500.Hit += new EventHandler(bLL0500_Hit);
            bSL0500.Hit += new EventHandler(bSL0500_Hit);
            bLR0500.Hit += new EventHandler(bLR0500_Hit);
            bSR0500.Hit += new EventHandler(bSR0500_Hit);
            bLU0250.Hit += new EventHandler(bLU0250_Hit);
            bSU0250.Hit += new EventHandler(bSU0250_Hit);
            bLD0250.Hit += new EventHandler(bLD0250_Hit);
            bSD0250.Hit += new EventHandler(bSD0250_Hit);
            bLL0250.Hit += new EventHandler(bLL0250_Hit);
            bSL0250.Hit += new EventHandler(bSL0250_Hit);
            bLR0250.Hit += new EventHandler(bLR0250_Hit);
            bSR0250.Hit += new EventHandler(bSR0250_Hit);
            bLU0025.Hit += new EventHandler(bLU0025_Hit);
            bSU0025.Hit += new EventHandler(bSU0025_Hit);
            bLD0025.Hit += new EventHandler(bLD0025_Hit);
            bSD0025.Hit += new EventHandler(bSD0025_Hit);
            bLL0025.Hit += new EventHandler(bLL0025_Hit);
            bSL0025.Hit += new EventHandler(bSL0025_Hit);
            bLR0025.Hit += new EventHandler(bLR0025_Hit);
            bSR0025.Hit += new EventHandler(bSR0025_Hit);
            bTargetLockOn.Hit += new EventHandler(bTargetLockOn_Hit);
            bTargetLockOff.Hit += new EventHandler(bTargetLockOff_Hit);
            bLineup.Hit += new EventHandler(bLineup_Hit);
            bCombatmode.Hit += new EventHandler(bCombatmode_Hit);
            bPeacemode.Hit += new EventHandler(bPeacemode_Hit);
        }

        public void ViewDestroy()
        {
            bLD1000 = null;
            bSD1000 = null;
            bLL1000 = null;
            bSL1000 = null;
            bLR1000 = null;
            bSR1000 = null;
            bLU0750 = null;
            bSU0750 = null;
            bLD0750 = null;
            bSD0750 = null;
            bLL0750 = null;
            bSL0750 = null;
            bLR0750 = null;
            bSR0750 = null;
            bLU0500 = null;
            bSU0500 = null;
            bLD0500 = null;
            bSD0500 = null;
            bLL0500 = null;
            bSL0500 = null;
            bLR0500 = null;
            bSR0500 = null;
            bLU0250 = null;
            bSU0250 = null;
            bLD0250 = null;
            bSD0250 = null;
            bLL0250 = null;
            bSL0250 = null;
            bLR0250 = null;
            bSR0250 = null;
            bLU0025 = null;
            bSU0025 = null;
            bLD0025 = null;
            bSD0025 = null;
            bLL0025 = null;
            bSL0025 = null;
            bLR0025 = null;
            bSR0025 = null;
            bTargetLockOn = null;
            bTargetLockOff = null;
            bLineup = null;
            bCombatmode = null;
            bPeacemode = null;
            View.Dispose();
        }

        public void bLU1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long up 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,21,16,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bSU1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift up 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,21,16,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bLD1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long down 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,4,15,23,14,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bSD1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift down 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,4,15,23,14,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bLL1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long left 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,12,5,6,20,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bSL1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift left 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,12,5,6,20,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bLR1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long right 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,18,9,7,8,20,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bSR1000_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift right 1000      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,18,9,7,8,20,49,27,36,36,36,48};
            sendKey(myMessage);
        }
        public void bLU0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long up 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,21,16,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bSU0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift up 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,21,16,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bLD0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long down 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,4,15,23,14,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bSD0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift down 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,4,15,23,14,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bLL0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long left 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,12,5,6,20,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bSL0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift left 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,12,5,6,20,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bLR0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long right 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,18,9,7,8,20,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bSR0750_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift right 750      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,18,9,7,8,20,49,33,31,36,48};
            sendKey(myMessage);
        }
        public void bLU0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long up 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,21,16,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bSU0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift up 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,21,16,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bLD0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long down 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,4,15,23,14,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bSD0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift down 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,4,15,23,14,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bLL0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long left 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,12,5,6,20,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bSL0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift left 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,12,5,6,20,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bLR0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long right 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,18,9,7,8,20,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bSR0500_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift right 500      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,18,9,7,8,20,49,31,36,36,48};
            sendKey(myMessage);
        }
        public void bLU0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long up 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,21,16,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bSU0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift up 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,21,16,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bLD0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long down 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,4,15,23,14,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bSD0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift down 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,4,15,23,14,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bLL0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long left 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,12,5,6,20,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bSL0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift left 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,12,5,6,20,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bLR0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long right 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,18,9,7,8,20,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bSR0250_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift right 250      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,18,9,7,8,20,49,28,31,36,48};
            sendKey(myMessage);
        }
        public void bLU0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long up 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,21,16,49,28,31,48};
            sendKey(myMessage);
        }
        public void bSU0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift up 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,21,16,49,28,31,48};
            sendKey(myMessage);
        }
        public void bLD0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long down 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,4,15,23,14,49,28,31,48};
            sendKey(myMessage);
        }
        public void bSD0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift down 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,4,15,23,14,49,28,31,48};
            sendKey(myMessage);
        }
        public void bLL0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long left 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,12,5,6,20,49,28,31,48};
            sendKey(myMessage);
        }
        public void bSL0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift left 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,12,5,6,20,49,28,31,48};
            sendKey(myMessage);
        }
        public void bLR0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump long right 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,12,15,14,7,49,18,9,7,8,20,49,28,31,48};
            sendKey(myMessage);
        }
        public void bSR0025_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f jump shift right 25      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,10,21,13,16,49,19,8,9,6,20,49,18,9,7,8,20,49,28,31,48};
            sendKey(myMessage);
        }
        public void bTargetLockOn_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f target #GUID#     */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,20,1,18,7,5,20,49};
            sendKey(myMessage);
            int MyTarget = Host.Actions.CurrentSelection;
            string TargetString = Convert.ToString(MyTarget);
            CreateKeyString(TargetString);
            int[] HitEnter ={ 48 };
            sendKey(HitEnter);
        }
        public void bTargetLockOff_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f target off        */
            int[] myMessage ={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,20,1,18,7,5,20,49,15,6,6,48};
            sendKey(myMessage);
        }
        public void bLineup_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f lineup myLocationX myLocationY myHeading      */
            IsCommander = true;
            int[] myMessage ={ 48, 39, 22, 9, 3, 3, 49, 20, 8, 5, 12, 1, 19, 20, 16, 1, 12, 1, 4, 9, 14, 19, 37, 49, 39, 6, 49, 12, 9, 14, 5, 21, 16, 49 };
            sendKey(myMessage);
            Coordinates PlayerCoords = new Coordinates(Host.Actions.Landcell, Host.Actions.LocationY, Host.Actions.LocationX);
            string MyCoordsNS = Convert.ToString(PlayerCoords.NS);
            CreateKeyString(MyCoordsNS);
            int[] HitSpace ={ 49 };
            sendKey(HitSpace);
            string MyCoordsEW = Convert.ToString(PlayerCoords.EW);
            CreateKeyString(MyCoordsEW);
            sendKey(HitSpace);
            string MyHeading = Convert.ToString(Host.Actions.Heading);
            CreateKeyString(MyHeading);
            int[] HitEnter ={ 48 };
            sendKey(HitEnter);
        }
        public void bCombatmode_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f combatmode      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,3,15,13,2,1,20,13,15,4,5,48};
            sendKey(myMessage);
        }
        public void bPeacemode_Hit(object sender, EventArgs e)
        {
            /*      /vicc thelastpaladins, /f peacemode      */
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,16,5,1,3,5,13,15,4,5,48};
            sendKey(myMessage);
        }
/*        public void bNew_Hit(object sender, EventArgs e)
        {
                  /vicc thelastpaladins, /f new      
            int[] myMessage={48,39,22,9,3,3,49,20,8,5,12,1,19,20,16,1,12,1,4,9,14,19,37,49,39,6,49,48};
            sendKey(myMessage);
        }*/
    }
}

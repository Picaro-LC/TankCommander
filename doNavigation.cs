using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TankCommander
{
    public partial class PluginCore
    {
        enum eNavState
        {
            SHUTDOWN, KEY_DN, KEY_UP, KEY_WAIT, MOVING, TIMEOUT
        }

        private Timer MovementTimer;
        private Timer TurningTimer;
        private Timer TimeOutTimer;
        private eNavState NavState = eNavState.SHUTDOWN;
        private double MyDistanceTo;
        private double MyAngleTo;
        private Coordinates PlayerCoords;
        private CoordsObject MyDestination;
        private CoordsObject MyLocation;

        public void LineThemUp(double MyDestNS, double MyDestEW)
        {
            MyDistanceTo = 1.0;
            MyDestination = new CoordsObject(MyDestNS, MyDestEW);
            PlayerCoords = new Coordinates(Host.Actions.Landcell, Host.Actions.LocationY, Host.Actions.LocationX);
            MyLocation = new CoordsObject(PlayerCoords.NS, PlayerCoords.EW);
            MyAngleTo = MyLocation.AngleToCoords(MyDestination);
            if (MyAngleTo < 90) { MyAngleTo = MyAngleTo - 90 + 360; }
            else { MyAngleTo = MyAngleTo - 90; }
            MyDistanceTo = MyLocation.DistanceToCoords(MyDestination);
            Host.Actions.FaceHeading(MyAngleTo, true);
            startTurningTimer(1000);
        }

        public void MoveTo()
        {
            if (NavState != eNavState.TIMEOUT)
            {
                NavState = eNavState.MOVING;
                bool SetNav = true;
                if (MyDistanceTo > 0.1) { startMovement(SetNav, 1200); }
                if (MyDistanceTo > 0.01) { startMovement(SetNav, 600); }
                if (MyDistanceTo > 0.001) { startMovement(SetNav, 300); }
                if (MyDistanceTo > 0.0005) { startMovement(SetNav, 150); }
            }
            if (MyDistanceTo <= 0.0005 || NavState == eNavState.TIMEOUT)
            {
                Host.Actions.FaceHeading(MyHeading, true);
                LineUpActive = false;
                NavState = eNavState.SHUTDOWN;
            }
        }

        public void startMovement(bool SetNav, int MoveTime)
        {
            if (NavState == eNavState.MOVING)
            {
                MyWpDirDn = WpRIGHTdn;
                MyLpDirDn = LpRIGHTdn;
                MyLpDirUp = LpRIGHTup;
                NavState = eNavState.KEY_DN;
                continueMovement();
                startMovementTimer(MoveTime);
            }
            else { continueMovement(); }
        }

        private void continueMovement()
        {
            if (NavState != eNavState.KEY_DN && NavState != eNavState.KEY_UP) return;
            switch (NavState)
            {
                case eNavState.KEY_DN: sendMovementKeyDown(); break;
                case eNavState.KEY_UP: sendMovementKeyUp(); break;
            }
        }

        private void sendMovementKeyDown()
        {
            SendMessage(MyHwnd, WM_KEYDN, WpSHIFTdn, LpSHIFTdn);
            SendMessage(MyHwnd, WM_KEYDN, MyWpDirDn, MyLpDirDn);
            NavState = eNavState.KEY_WAIT;
            return;
        }

        private void sendMovementKeyUp()
        {
            SendMessage(MyHwnd, WM_KEYUP, MyWpDirDn, MyLpDirUp);
            SendMessage(MyHwnd, WM_KEYUP, WpSHIFTdn, LpSHIFTup);
            NavState = eNavState.SHUTDOWN;
            LineThemUp(MyCoordsNS, MyCoordsEW);
        }
        
        protected void startMovementTimer(int myInterval)
        {
            MovementTimer = new Timer();
            MovementTimer.Interval = myInterval;
            MovementTimer.Tick += new EventHandler(MovementTimer_Tick);
            MovementTimer.Start();
        }

        void MovementTimer_Tick(object sender, EventArgs e)
        {
            MovementTimer.Stop();
            MovementTimer.Dispose();
            MovementTimer = null;
            NavState = eNavState.KEY_UP;
            continueMovement();
        }

        protected void startTurningTimer(int myInterval)
        {
            TurningTimer = new Timer();
            TurningTimer.Interval = myInterval;
            TurningTimer.Tick += new EventHandler(TurningTimer_Tick);
            TurningTimer.Start();
        }

        void TurningTimer_Tick(object sender, EventArgs e)
        {
            TurningTimer.Stop();
            TurningTimer.Dispose();
            TurningTimer = null;
            MoveTo();
        }

        protected void startTimeOutTimer(int myInterval)
        {
            TimeOutTimer = new Timer();
            TimeOutTimer.Interval = myInterval;
            TimeOutTimer.Tick += new EventHandler(TimeOutTimer_Tick);
            TimeOutTimer.Start();
        }

        void TimeOutTimer_Tick(object sender, EventArgs e)
        {
            if (MovementTimer != null)
            {
                MovementTimer.Stop();
                MovementTimer.Dispose();
                MovementTimer = null;
                SendMessage(MyHwnd, WM_KEYUP, MyWpDirDn, MyLpDirUp);
                SendMessage(MyHwnd, WM_KEYUP, WpSHIFTdn, LpSHIFTup);
            }
            TimeOutTimer.Stop();
            TimeOutTimer.Dispose();
            TimeOutTimer = null;
            NavState = eNavState.TIMEOUT;
            MoveTo();
        }
    }
}
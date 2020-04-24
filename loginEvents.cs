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
        public void initLoginEvents()
        {
            Core.CharacterFilter.LoginComplete += new EventHandler(CharacterFilter_LoginComplete);
        }

        public void CharacterFilter_LoginComplete(object s, EventArgs e)
        {
            Host.Actions.AddChatText("[Tank Commander] Init Complete.", 1);
            /*      /loadui DisplaySettings      */
            int[] myCommand1 ={ 48,39,12,15,1,4,21,9,49,4,9,19,16,12,1,25,19,5,20,20,9,14,7,19,48 };
            sendKey(myCommand1);
            /*      hit Pause to start macro     */
            int[] myCommand2 ={ 54 };
            sendKey(myCommand2);
            /*      /vt opt set EnableMeta true  */
            int[] myCommand3 = { 48,39,22,20,49,15,16,20,49,19,5,20,49,5,14,1,2,12,5,13,5,20,1,49,20,18,21,5,48 };
            sendKey(myCommand3);
        }

        public void destroyLoginEvents()
        {
            Core.CharacterFilter.LoginComplete -= new EventHandler(CharacterFilter_LoginComplete);
        }
    }
}
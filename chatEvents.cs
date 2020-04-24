using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;

namespace TankCommander
{
    public partial class PluginCore
    {
        public static string COMMAND_PREFIX_1 = "[Fellowship] You say, \"";
        public static string COMMAND_PREFIX_2 = "/tc ";
        public static int COMMAND_LENGTH_1 = 23;
        public static int COMMAND_LENGTH_2 = 4;
        public static double MyCoordsNS;
        public static double MyCoordsEW;
        public static double MyHeading;

            public void initChatEvents()
        {
            Core.CommandLineText += new EventHandler<ChatParserInterceptEventArgs>(Core_CommandLineText);
            Core.ChatBoxMessage += new EventHandler<ChatTextInterceptEventArgs>(Core_ChatBoxMessage);
        }

        void Core_CommandLineText(object sender, ChatParserInterceptEventArgs e)
        {
            if (e.Text.StartsWith(COMMAND_PREFIX_2))
            {
                string[] cmd = e.Text.Substring(COMMAND_LENGTH_2).Trim().TrimEnd('"').ToLower().Split(' ');

                if (cmd[0].Equals("magpack"))
                {
                    e.Eat = true;
                    int myHotKey1 = 56;
                    int myHotKey2 = 16;
                    sendHotKey(myHotKey1, myHotKey2);
                }
                else if (cmd[0].Equals("logout"))
                {
                    e.Eat = true;
                    LogOut();
                }
            }
            {
                e.Eat = false;
            }
        }
        public void Core_ChatBoxMessage(object sender, ChatTextInterceptEventArgs e)
        {
            if (e.Text.StartsWith(COMMAND_PREFIX_1))
            {
                string[] cmd = e.Text.Substring(COMMAND_LENGTH_1).Trim().TrimEnd('"').ToLower().Split(' ');
                
                if (cmd[0].Equals("jump"))
                {
                    int ThisJumpStyle = 0;
                    
                    if (cmd[1].Equals("shift"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 10;
                    }
                    else if (cmd[1].Equals("long"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 20;
                    }
                    else { WriteToChat("Tank Commander: ", "Input Error on CMD1!"); }

                    if (cmd[2].Equals("up"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 1;
                    }
                    else if (cmd[2].Equals("down"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 2;
                    }
                    else if (cmd[2].Equals("left"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 3;
                    }
                    else if (cmd[2].Equals("right"))
                    {
                        ThisJumpStyle = ThisJumpStyle + 4;
                    }
                    else { WriteToChat("Tank Commander: ", "Input Error on CMD2!"); }

                    if (ThisJumpStyle > 10 & ThisJumpStyle < 25)
                    {
                        e.Eat = true;
                        JumpState = eJumpState.IDLE;
                        int ThisJumpPower = Convert.ToInt32(cmd[3]);
                        startKeyPress(ThisJumpStyle, ThisJumpPower);
                    }
                    else { WriteToChat("Tank Commander: ", "Input Error on CMD3!"); }
                }

                else if (cmd[0].Equals("vtank"))
                {
                    e.Eat = true;
                    int[] myMessage ={ 54 };
                    sendKey(myMessage);
                }

                else if (cmd[0].Equals("target"))  // per Virindi, try putting a WM_Activate in here before sending keys....
                {
                    if (cmd[1] != "off")
                    {
                        e.Eat = true;
                        int GroupTarget = Convert.ToInt32(cmd[1]);
                        /*      /vicc thelastpaladins, /f /vt opt set targetlock true      */
                        //int[] myMessage ={48,39,22,20,49,15,16,20,49,19,5,20,49,20,1,18,7,5,20,12,15,3,11,49,20,18,21,5,48};
                        //sendKey(myMessage);
                        Host.Actions.SelectItem(GroupTarget);
                    }
                    else
                    {
                        e.Eat = true;
                        /*      /vicc thelastpaladins, /f /vt opt set targetlock false      */
                        //int[] myMessage ={48,39,22,20,49,15,16,20,49,19,5,20,49,20,1,18,7,5,20,12,15,3,11,49,6,1,12,19,5,48};
                        int[] myMessage ={ 55 };
                        sendKey(myMessage);
                    }
                }

                else if (cmd[0].Equals("lineup"))
                {
                    e.Eat = true;
                    if (LineUpActive == false && IsCommander == false)
                    {
                        LineUpActive = true;
                        MyCoordsNS = Convert.ToDouble(cmd[1]);
                        MyCoordsEW = Convert.ToDouble(cmd[2]);
                        MyHeading = Convert.ToDouble(cmd[3]);
                        startTimeOutTimer(8000);
                        LineThemUp(MyCoordsNS, MyCoordsEW);
                    }
                    else if (LineUpActive == true && IsCommander == false)
                    {
                        int[] HitEnter ={ 48 };
                        sendKey(HitEnter);
                        CreateKeyString("/f lineup in progress, please wait.");
                        sendKey(HitEnter);
                    }
                    else if (LineUpActive == false && IsCommander == true)
                    {
                        IsCommander = false;
                    }
                    else { WriteToChat("LineUp:", "Invalid Conditions found!"); }
                }

                else if (cmd[0].Equals("combatmode"))
                {
                    e.Eat = true; 
                    if (CoreManager.Current.Actions.CombatMode == CombatState.Peace)
                    {
                        int[] myMessage ={ 49 };
                        sendKey(myMessage);
                    }
                }

                else if (cmd[0].Equals("peacemode"))
                {
                    if (CoreManager.Current.Actions.CombatMode != CombatState.Peace)
                    {
                        int[] myMessage ={ 49 };
                        sendKey(myMessage);
                    }
                    e.Eat = true;
                }

                else
                {
                    e.Eat = false;
                }
            }
            else
            {
                e.Eat = false;
            }
        }

        public void destroyChatEvents()
        {
            Core.CommandLineText -= new EventHandler<ChatParserInterceptEventArgs>(Core_CommandLineText);
            Core.ChatBoxMessage -= new EventHandler<ChatTextInterceptEventArgs>(Core_ChatBoxMessage);            
        }

        public void WriteToChat(string function, string message)
        {
            Host.Actions.AddChatText(String.Format("[{0}] {1} {2}", PLUGIN, function,message), 13, 1);
        }

        public void LogOut()
        {
            Host.Actions.Logout();
        }
    }
}
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;

namespace TankCommander
{
    public partial class PluginCore
    {
        /*  Captain Crunch Decoder Ring
            --------------------------------------------------------------------------------------------------------------------------------
            A    B    C    D    E    F    G    H    I    J    K    L    M    N    O    P    Q    R    S    T    U    V    W    X    Y    Z
            1    2    3    4    5    6    7    8    9    10   11   12   13   14   15   16   17   18   19   20   21   22   23   24   25   26
            --------------------------------------------------------------------------------------------------------------------------------
            1    2    3    4    5    6    7    8    9    0    COMMA    PERIOD    FORESLASH    SEMICOLEN    RSGLQUOTE   LSQBRK   RSQBRK
            27   28   29   30   31   32   33   34   35   36   37       38        39           40           41          42       43
            --------------------------------------------------------------------------------------------------------------------------------
            MINUS    EQUAL    BACKSLASH    LSGLQUOTE    RETURN    SPACE    UP    RIGHT    LEFT    DOWN    PAUSE SCROLLLock  CTRL
            44       45       46           47           48        49       50    51       52      53      54    55          56
            ------------------------------------------------------------------------------------------------------------------------------*/

        uint[] wParamK = { 0x0, 0x00000041, 0x00000042, 0x00000043, 0x00000044, 0x00000045, 0x00000046, 0x00000047, 0x00000048, 0x00000049, 0x0000004A, 0x0000004B, 0x0000004C, 0x0000004D, 0x0000004E, 0x0000004F, 0x00000050, 0x00000051, 0x00000052, 0x00000053, 0x00000054, 0x00000055, 0x00000056, 0x00000057, 0x00000058, 0x00000059, 0x0000005A, 0x00000031, 0x00000032, 0x00000033, 0x00000034, 0x00000035, 0x00000036, 0x00000037, 0x00000038, 0x00000039, 0x00000030, 0x000000BC, 0x000000BE, 0x000000BF, 0x000000BA, 0x000000DE, 0x000000DB, 0x000000DD, 0x000000BD, 0x000000BB, 0x000000DC, 0x000000C0, 0x0000000D, 0x00000020, 0x00000026, 0x00000027, 0x00000025, 0x00000028, 0x00000013, 0x00000091, 0x00000011 };
        uint[] wParamC = { 0x0, 0x00000061, 0x00000062, 0x00000063, 0x00000064, 0x00000065, 0x00000066, 0x00000067, 0x00000068, 0x00000069, 0x0000006A, 0x0000006B, 0x0000006C, 0x0000006D, 0x0000006E, 0x0000006F, 0x00000070, 0x00000071, 0x00000072, 0x00000073, 0x00000074, 0x00000075, 0x00000076, 0x00000077, 0x00000078, 0x00000079, 0x0000007A, 0x00000031, 0x00000032, 0x00000033, 0x00000034, 0x00000035, 0x00000036, 0x00000037, 0x00000038, 0x00000039, 0x00000030, 0x0000002C, 0x0000002E, 0x0000002F, 0x0000003B, 0x00000027, 0x0000005B, 0x0000005D, 0x0000002D, 0x0000003D, 0x0000005C, 0x00000060, 0x0000000D, 0x00000020, 0x00000026, 0x00000027, 0x00000025, 0x00000028, 0x00000013, 0x00000046, 0x00000011 };
        uint[] lParam1 = { 0x0, 0x001E0001, 0x00300001, 0x002E0001, 0x00200001, 0x00120001, 0x00210001, 0x00220001, 0x00230001, 0x00170001, 0x00240001, 0x00250001, 0x00260001, 0x00320001, 0x00310001, 0x00180001, 0x00190001, 0x00100001, 0x00130001, 0x001F0001, 0x00140001, 0x00160001, 0x002F0001, 0x00110001, 0x002D0001, 0x00150001, 0x002C0001, 0x00020001, 0x00030001, 0x00040001, 0x00050001, 0x00060001, 0x00070001, 0x00080001, 0x00090001, 0x000A0001, 0x000B0001, 0x00330001, 0x00340001, 0x00350001, 0x00350001, 0x00350001, 0x00350001, 0x00350001, 0x00350001, 0x000D0001, 0x00350001, 0x00350001, 0x001C0001, 0x00390001, 0x01480001, 0x014D0001, 0x014B0001, 0x01500001, 0x00450001, 0x00460001, 0x001D0001 };
        uint[] lParam2 = { 0x0, 0xC01E0001, 0xC0300001, 0xC02E0001, 0xC0200001, 0xC0120001, 0xC0210001, 0xC0220001, 0xC0230001, 0xC0170001, 0xC0240001, 0xC0250001, 0xC0260001, 0xC0320001, 0xC0310001, 0xC0180001, 0xC0190001, 0xC0100001, 0xC0130001, 0xC01F0001, 0xC0140001, 0xC0160001, 0xC02F0001, 0xC0110001, 0xC02D0001, 0xC0150001, 0xC02C0001, 0xC0020001, 0xC0030001, 0xC0040001, 0xC0050001, 0xC0060001, 0xC0070001, 0xC0080001, 0xC0090001, 0xC00A0001, 0xC00B0001, 0xC0330001, 0xC0340001, 0xC0350001, 0xC0350001, 0xC0350001, 0xC0350001, 0xC0350001, 0xC0350001, 0xC00D0001, 0xC0350001, 0xC0350001, 0xC01C0001, 0xC0390001, 0xC1480001, 0xC14D0001, 0xC14B0001, 0xC1500001, 0xC0450001, 0xC0460001, 0xC01D0001 };

        // Cross reference Char Array for use in obtaining index #'s as Int[]'s.  First '#' is a place holder for index#0.  *NOTE* Not all keys have Char's and are listed as '#' as a place holder.
        char[] charRefArray = { '#','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','1','2','3','4','5','6','7','8','9','0',',','.','/',';','`','[',']','-','=','#','#','#',' ','#','#','#','#','#','#','#' };

        public void sendKey(int[] KeyIndexNumber)
        {
            foreach (int i in KeyIndexNumber)
            {
                SendMessage(MyHwnd, WM_KEYDN, wParamK[i], lParam1[i]);
                SendMessage(MyHwnd, WM_CHAR, wParamC[i], lParam1[i]);
                SendMessage(MyHwnd, WM_KEYUP, wParamK[i], lParam2[i]);
            }
        }

        public void sendHotKey(int KeyIndexNumber1, int KeyIndexNumber2)
        {
            SendMessage(MyHwnd, WM_KEYDN, wParamK[KeyIndexNumber1], lParam1[KeyIndexNumber1]);
            SendMessage(MyHwnd, WM_KEYDN, wParamK[KeyIndexNumber2], lParam1[KeyIndexNumber2]);
            SendMessage(MyHwnd, WM_CHAR, wParamC[KeyIndexNumber2], lParam1[KeyIndexNumber2]);
            SendMessage(MyHwnd, WM_KEYUP, wParamK[KeyIndexNumber2], lParam2[KeyIndexNumber2]);
            SendMessage(MyHwnd, WM_KEYUP, wParamK[KeyIndexNumber1], lParam2[KeyIndexNumber1]);
        }

        public void CreateKeyString(string TargetString)
        {
            char[] MyCharArray = TargetString.ToCharArray();
            ArrayList MyCharList = new ArrayList();
            foreach (char i in MyCharArray)
            {
                int n = 0;
                while (n < 57)
                {
                    if (charRefArray[n] == i)
                    {
                        MyCharList.Add(n);
                    }
                    n++;
                }
            }
            int[] MyKeyString = (int[])MyCharList.ToArray(typeof(int));
            sendKey(MyKeyString);
        }
    }
}
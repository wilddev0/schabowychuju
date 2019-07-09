using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Diagnostics;
namespace NotepadMeme
{
    class T
    {
        public static bool TStatus;

        public static int iterator = 0;
        static VAMemory mem = new VAMemory(MainClass.injProc);
        public static int BaseAddress = MainClass.GetBaseAddress();
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);

        public const int MouseEventLeftDown = 0x02;
        public const int MouseEventLeftUp = 0x04;

        public static void TMenu(bool TT)
        {
            //Thread tthread = new Thread(new ThreadStart(TMain));
            Thread tthread = new Thread(TMain);
            TStatus = TT;
            if (TStatus)
            {
                tthread.Start();
            }
            else if (!TStatus)
            {
                tthread.Abort();
            }
            MainClass.MainMenu();

        }

        public static bool GetTStatus()
        {
            return TStatus;
        }

        private static void TMain()
        {
            while (true && TStatus)
            {

                if (iterator > 10)
                {

                    iterator = 0;
                }
                else
                {
                    iterator = iterator + 1;
                }

                int ALocalPlayer = BaseAddress + Offsets.LP;
                int SourcePlayer = mem.ReadInt32((IntPtr)ALocalPlayer);

                int ASrcPlayerTeam = SourcePlayer + Offsets.T;
                int SrcPlayerTeam = mem.ReadInt32((IntPtr)ASrcPlayerTeam);

                int ASrcPlayerCrosshair = SourcePlayer + Offsets.CId;
                int SrcPlayerCrosshair = mem.ReadInt32((IntPtr)ASrcPlayerCrosshair);

                int AAttack = BaseAddress + Offsets.FA;
                if(SrcPlayerCrosshair > 0 && SrcPlayerCrosshair < 65)
                {
                    int APointingPlayer = BaseAddress + Offsets.EL + (SrcPlayerCrosshair -1) * 0x10;
                    int PP = mem.ReadInt32((IntPtr)APointingPlayer);

                    int PPH = mem.ReadInt32((IntPtr)PP + Offsets.H);

                    int PPT = mem.ReadInt32((IntPtr)PP + Offsets.T);

                    if (PPT != SrcPlayerTeam && PPH > 0 && ConfigurationSettings.AppSettings["AutoTriggerBot"] == "true")
                    {

                        Thread.Sleep(Convert.ToInt32(ConfigurationSettings.AppSettings["TriggerBotReactionTimeMs"]));
                        mouse_event(MouseEventLeftDown, 0, 0, 0, new UIntPtr());
                        mouse_event(MouseEventLeftUp, 0, 0, 0, new UIntPtr());

                    }
                    else if (ConfigurationSettings.AppSettings["AutoTriggerBot"] == "false")
                    {
                        if(PPT != SrcPlayerTeam && PPH > 0 && GetAsyncKeyState(Convert.ToInt32(ConfigurationSettings.AppSettings["TriggerBotKey"])) != 0)
                        {
                            Thread.Sleep(Convert.ToInt32(ConfigurationSettings.AppSettings["TriggerBotReactionTimeMs"]));
                            mouse_event(MouseEventLeftDown, 0, 0, 0, new UIntPtr());
                            mouse_event(MouseEventLeftUp, 0, 0, 0, new UIntPtr());
                           //mem.WriteInt32((IntPtr)BaseAddress + Offsets.FA, 4);
                        }
                    }
                }
            }
                    
        }
    }
}

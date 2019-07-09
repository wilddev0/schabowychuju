using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NotepadMeme
{
    class RabbitHop
    {

        public static bool RabbitStatus;
        public static void RMenu(bool RStatus)
        {
            Thread thread = new Thread(new ThreadStart(RMain));
            RabbitStatus = RStatus;
            if (RabbitStatus)
            {
                thread.Start();
            }
            else if (!RabbitStatus)
            {
                thread.Abort();
                thread = null;
            }
            MainClass.MainMenu();
        }


        public static bool GetRabbitStatus()
        {
            return RabbitStatus;
        }

        public static int bAddress = MainClass.GetBaseAddress();

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);


        public static void RMain()
        {

            if (bAddress != 0)
            {
                VAMemory mem = new VAMemory(MainClass.injProc);
                int fjump = bAddress + Offsets.J;



                int ALocalPlayer = bAddress + Offsets.LP;
                int LocalPlayer = mem.ReadInt32((IntPtr)ALocalPlayer);

                int AJFlag = LocalPlayer + Offsets.JF;
                while (true && RabbitStatus)
                {
                    while (GetAsyncKeyState(32) != 0)
                    {
                        int JStat = mem.ReadInt32((IntPtr)AJFlag);
                        if (JStat == 257)
                        {
                            mem.WriteInt32((IntPtr)fjump, 6);
                        }
                    }
                }
            }
        }
    }
}

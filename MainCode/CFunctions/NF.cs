using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;


namespace NotepadMeme
{
    class NF
    {
        public static bool isNF;

        static VAMemory mem = new VAMemory(MainClass.injProc);

        private static int BaseAddress = MainClass.GetBaseAddress();

        public static bool GetNfStatus()
        {
            return isNF;
        }

        public static void NFMenu(bool status)
        {
            Thread nfthread = new Thread(new ThreadStart(NFMain));
            isNF = status;
            if(isNF)
            {
                nfthread.Start();
            }
            else
            {
                nfthread.Abort();
            }
            MainClass.MainMenu();
        }

        private static void NFMain()
        {
            while (true && isNF)
            {
                int SPLR = mem.ReadInt32((IntPtr)BaseAddress + Offsets.LP);

                float FLA = SPLR + Offsets.FLA;

                if (mem.ReadFloat((IntPtr)FLA) > 0f)
                {
                    mem.WriteFloat((IntPtr)FLA, 0f);
                    Thread.Sleep(100);
                }
            }
        }
    }
}

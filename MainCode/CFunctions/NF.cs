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
        static VAMemory mem = new VAMemory(MainClass.injProc);

        private static int BaseAddress = MainClass.GetBaseAddress();

        public static void NFMain()
        {
            while (true)
            {
                int SPLR = BaseAddress + Offsets.LP;

                float FD = mem.ReadFloat((IntPtr)SPLR + Offsets.FD);

                float FLA = SPLR + Offsets.FLA;
                if (mem.ReadFloat((IntPtr)FLA) > 0.0f)
                {
                    mem.WriteFloat((IntPtr)FLA, 0.0f);
                }
            }
        }
    }
}

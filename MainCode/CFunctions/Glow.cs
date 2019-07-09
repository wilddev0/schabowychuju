using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace NotepadMeme
{
    class G
    {
        public static int iterator = 0;
        public static  int BaseAdress = MainClass.GetBaseAddress();
        public static  int currentaddress;
        public static bool IsDormant;
        public static bool isGlowing;
        public struct GlowStructure
        {
            public float r;
            public float g;
            public float b;
            public float a;
        }


        public static void GMenu(bool GStatus)
        {
            Thread gthread = new Thread(new ThreadStart(AllSeeingEyes));
            isGlowing = GStatus;
            if (isGlowing)
            {
                gthread.Start();
            }
            else if (!isGlowing)
            {
                gthread.Abort();
            }
            MainClass.MainMenu();
        }


        public static bool GetGlowStatus()
        {
            return isGlowing;
        }
        public static void AllSeeingEyes()
        {
            if (MainClass.GetIfProcessIsRunning())
            {
                while (true && isGlowing)
                {
                    VAMemory mem = new VAMemory(MainClass.injProc);
                    GlowStructure NeighbourTeam = new GlowStructure()
                    {
                        r = float.Parse(ConfigurationSettings.AppSettings["TeamGlowColorR"]),
                        g = float.Parse(ConfigurationSettings.AppSettings["TeamGlowColorG"]),
                        b = float.Parse(ConfigurationSettings.AppSettings["TeamGlowColorB"]),
                        a = float.Parse(ConfigurationSettings.AppSettings["TeamGlowColorA"]),
                    };
                    GlowStructure NiggersTeam = new GlowStructure()
                    {
                        r = float.Parse(ConfigurationSettings.AppSettings["EnemyGlowColorR"]),
                        g = float.Parse(ConfigurationSettings.AppSettings["EnemyGlowColorG"]),
                        b = float.Parse(ConfigurationSettings.AppSettings["EnemyGlowColorB"]),
                        a = float.Parse(ConfigurationSettings.AppSettings["EnemyGlowColorA"]),
                    };
                    do
                    {
                        if (iterator > 10)
                        {
                           
                            iterator = 0;
                        }
                        else
                        {
                            iterator = iterator + 1;
                        }

                        int ALP = BaseAdress + Offsets.LP;

                        int SP = mem.ReadInt32((IntPtr)ALP);

                        int ASPT = SP + Offsets.T;

                        int HomieTeam = mem.ReadInt32((IntPtr)ASPT);

                        int AEL = BaseAdress + Offsets.EL + iterator * 0x10;

                        int EL = mem.ReadInt32((IntPtr)AEL);

                        int NiggerHealth = mem.ReadInt32((IntPtr)EL + Offsets.H);

                        int ANiggerTeam = EL + Offsets.T;

                        int NiggerTeam = mem.ReadInt32((IntPtr)ANiggerTeam);

                        int DormantStatus = EL + Offsets.D;

                        IsDormant = mem.ReadBoolean((IntPtr)DormantStatus);
                        if (!IsDormant)
                        {
          
                            currentaddress = EL + Offsets.GI;

                            int Glow = mem.ReadInt32((IntPtr)currentaddress);

                            if (HomieTeam == NiggerTeam && ConfigurationSettings.AppSettings["GlowTeamMates"] == "true")
                            {
                                currentaddress = BaseAdress + Offsets.GOM;
                                int GObject = mem.ReadInt32((IntPtr)currentaddress);

                                int result = Glow * 0x38 + 0x4;

                                int currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NeighbourTeam.r);

                                result = Glow * 0x38 + 0x8;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NeighbourTeam.g);

                                result = Glow * 0x38 + 0xC;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NeighbourTeam.b);

                                result = Glow * 0x38 + 0x10;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NeighbourTeam.a);

                                result = Glow * 0x38 + 0x24;
                                currentObj = GObject + result;
                                mem.WriteBoolean((IntPtr)currentObj, true);

                                result = Glow * 0x38 + 0x25;
                                currentObj = GObject + result;
                                mem.WriteBoolean((IntPtr)currentObj, true);

                            }
                            else if (HomieTeam != NiggerTeam && ConfigurationSettings.AppSettings["GlowEnemies"] == "true")
                            {
                                currentaddress = BaseAdress + Offsets.GOM;
                                int GObject = mem.ReadInt32((IntPtr)currentaddress);

                                int result = Glow * 0x38 + 0x4;

                                int currentObj = GObject + result;

                                if (ConfigurationSettings.AppSettings["EnemyGlowColorDependsOnHealth"] == "true")
                                {
                                    if (NiggerHealth <= 100 && NiggerHealth > 75)
                                    {
                                        NiggersTeam.r = 0;
                                        NiggersTeam.g = 1;
                                        NiggersTeam.b = 0;
                                        NiggersTeam.a = 1;

                                    }
                                    else if (NiggerHealth <= 75 && NiggerHealth > 50)
                                    {

                                        NiggersTeam.r = 255;
                                        NiggersTeam.g = 255;
                                        NiggersTeam.b = 0;
                                        NiggersTeam.a = 1;


                                    }
                                    else if (NiggerHealth <= 50 && NiggerHealth > 25)
                                    {


                                        NiggersTeam.r = 255;
                                        NiggersTeam.g = 153;
                                        NiggersTeam.b = 0;
                                        NiggersTeam.a = 1;

                                    }
                                    else if (NiggerHealth <= 25 && NiggerHealth > 0)
                                    {

                                        NiggersTeam.r = 1;
                                        NiggersTeam.g = 0;
                                        NiggersTeam.b = 0;
                                        NiggersTeam.a = 1;

                                    }
                                }

                                mem.WriteFloat((IntPtr)currentObj, NiggersTeam.r);

                                result = Glow * 0x38 + 0x8;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NiggersTeam.g);

                                result = Glow * 0x38 + 0xC;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NiggersTeam.b);

                                result = Glow * 0x38 + 0x10;
                                currentObj = GObject + result;
                                mem.WriteFloat((IntPtr)currentObj, NiggersTeam.a);

                                result = Glow * 0x38 + 0x24;
                                currentObj = GObject + result;
                                mem.WriteBoolean((IntPtr)currentObj, true);

                                result = Glow * 0x38 + 0x25;
                                currentObj = GObject + result;
                                mem.WriteBoolean((IntPtr)currentObj, true);

                            }
                        }
                    }while (true && isGlowing);
                }
            }
        }
    }
}

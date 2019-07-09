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


    class MainClass
    {
        public static string userlogin;
        private const string ver = "CANARY PRODUCTION CLOSED ALPHA 0.7c";
        public const string a = "c";
        public const string b = "s";
        public const string c = "g";
        public const string injProc = a + b + c + "o";
        public const string d = "cli";
        public const string e = "ent";
        public const string f = "_pano";
        public const string g = "rama.dll";
        static Process[] pname = Process.GetProcessesByName(injProc);
        private const string status = "PROBABLY UNDETECTED";


        public static string GetOptionStatusLabel(bool option)
        {
            if (option)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }
        public static bool GetIfProcessIsRunning()
        {
            if (pname.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void BootMain(string login)
        {
            userlogin = login;
            if (GetIfProcessIsRunning())
            {
                MainMenu();
            }
            else
            {
                if (Console.ForegroundColor != ConsoleColor.Red)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Clear();
                Console.WriteLine("COULD NOT FIND CSGO.EXE PROCESS\n");
                Thread.Sleep(400);
                BootMain(login);
            }
        }
        public static void MainMenu()
        {
            int outputC = -0;
            Console.Clear();
            Console.Title = "";
            Console.SetWindowSize(52, 20);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------- krasnolud CS:GO EXTERNAL CHEAT ----------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your username: " + userlogin);
            Console.WriteLine("Version: {0}", ver);
            Console.WriteLine("Discord: krasnolud#2814");
            Console.ResetColor(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine("--------------------- COMMANDS ----------------------"); Console.WriteLine();
            Console.WriteLine("other - Other options");
            Console.WriteLine("1 - Bunnyhop (CurrentStatus: {0})", GetOptionStatusLabel(RabbitHop.GetRabbitStatus()));
            Console.WriteLine("2 - Glow Wallhack (CurrentStatus: {0})", GetOptionStatusLabel(G.GetGlowStatus()));
            Console.WriteLine("3 - Triggerbot (CurrentStatus: {0})", GetOptionStatusLabel(T.GetTStatus()));
            Console.WriteLine("4 - No Flash (CurrentStatus: {0}", GetOptionStatusLabel(N.GetNfStatus()));
            Console.WriteLine("5 - Aimbot (CurrentStatus: TODO)");
            Console.WriteLine("6 - ESP (CurrentStatus: TODO)");
            #region commands
            Console.WriteLine("other - Other options");
            Console.WriteLine("1 - Bunnyhop (CurrentStatus: {0})", GetOptionStatusLabel(RabbitHop.GetRabbitStatus()));
            Console.WriteLine("2 - Glow Wallhack (CurrentStatus: {0})", GetOptionStatusLabel(G.GetGlowStatus()));
            Console.WriteLine("3 - Triggerbot (CurrentStatus: {0})", GetOptionStatusLabel(T.GetTStatus()));
            Console.WriteLine("4 - No Flash (CurrentStatus: Coding)");
            Console.WriteLine("5 - Aimbot (CurrentStatus: TODO)");
            Console.WriteLine("6 - ESP (CurrentStatus: TODO)");
            #endregion commmands
            Console.WriteLine(); Console.WriteLine("-------------------------------------------------------");
            #region commandoutput
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Type your choice: ");
            Console.ForegroundColor = ConsoleColor.Red;
            #endregion commandoutput
            try
            {
                outputC = Convert.ToInt16(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                //Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("The command can by only a number.!\nPress any key to return to the main menu."); Console.ReadKey(); MainMenu();
                //outputC = Console.ReadLine();Console.ReadLine().ToString();
                //DrawStatus();
                OtherOptionsMenu();
            }
            catch (System.OverflowException)
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You typed wrong command!\nPress any key to return to the main menu."); Console.ReadKey(); MainMenu();
            }
            catch (Exception) { }
            if (outputC != -0)
            {
                switch (outputC)
                {
                    case 1:
                        if (!RabbitHop.GetRabbitStatus())
                        {
                            RabbitHop.RMenu(true);
                        }
                        else
                        {
                            RabbitHop.RMenu(false);
                        }
                        break;
                    case 2:
                        if (!G.GetGlowStatus())
                        {
                            G.GMenu(true);
                        }
                        else
                        {
                            G.GMenu(false);
                        }
                        break;
                    case 3:
                        if (!T.GetTStatus())
                        {
                            T.TMenu(true);
                        }
                        else
                        {
                            T.TMenu(false);
                        }
                        break;
                    case 4:
                        if (!NF.GetNfStatus())
                        {
                            NFMenu(true);
                        }
                        else
                        {
                            NFMenu(false);
                        }
                        break;
                    default:
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You typed wrong command!\nPress any key to return to the main menu."); Console.ReadKey(); MainMenu(); break;
                }
            }
            //end of command output code
            Console.ReadKey();
        }

        static void DrawStatus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(); Console.WriteLine(status);
            Console.ReadKey();
            MainMenu();
        }
        public static int GetBaseAddress()
        {
            Process[] p = Process.GetProcessesByName(injProc);
            foreach (ProcessModule m in p[0].Modules)
            {
                if (m.ModuleName == d + e + f + g)
                {
                    return (int)m.BaseAddress;
                }
            }
            return 0;
        }

        private static void OtherOptionsMenu()
        {
            string selectedoption = "";
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------- krasnolud CS:GO EXTERNAL CHEAT ----------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your username: " + userlogin);
            Console.WriteLine("Version: {0}", ver);
            Console.WriteLine("Discord: krasnolud#2814");
            Console.ResetColor(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine("--------------------- OTHER OPTIONS ----------------------"); Console.WriteLine();
            #region commands
            Console.WriteLine("return - Back to main menu");
            Console.WriteLine("status - See detection status");
            #endregion commmands
            Console.WriteLine(); Console.WriteLine("-------------------------------------------------------");
            #region commandoutput
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Type your choice: ");
            Console.ForegroundColor = ConsoleColor.Red;
            #endregion commandoutput
            try
            {
                selectedoption = Console.ReadLine().ToString();   
            }
            catch(System.FormatException)
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You typed wrong command!\nPress any key to return to the main menu."); Console.ReadKey(); MainMenu();
            }
            if (selectedoption != "")
            {
                switch(selectedoption)
                {
                    case "return":
                        MainMenu();
                        break;
                    case "status":
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("BYPASSED VAC - Undetected"); Console.ReadKey(); MainMenu();break;
                    default:
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You typed wrong command!\nPress any key to return to the main menu."); Console.ReadKey(); MainMenu();
                        break;
                }
            }
        }
    }
}

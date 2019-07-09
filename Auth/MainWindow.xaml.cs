using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace NotepadMeme
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public static bool Debug = true;
        public MainWindow()
        {
            InitializeComponent();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DO NOT TURN OFF THIS WINDOW!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Waiting for succes auth..")
;        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = logintxtbox.Text;
            string password = pswtxtbox.Password;
            if (login == "krasnolud.dev" && password == "Kclosedtester420" && !Debug || login == "Olivier" && password == "Oclosedtester420" && !Debug || login == "Ferdek" && password == "Fclosedtester420" && !Debug || login == "Banan" && password == "Bclosedtester420" && !Debug)
            {
                Hide();
                MainClass.BootMain(login);
            }
            else if (Debug)
            {
                Hide();
                MainClass.BootMain("DEBUG USER");
            }
            else
            {
                MessageBox.Show("Bad Login or Password");
            }
            
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

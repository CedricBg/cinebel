using Cinebel.AdoToolbox;
using Cinebel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Cinebel.ViewModels;


namespace Cinebel
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    
    //Fichier xaml.cs de la fenêtre courante 
    public partial class Window1 : Window
    {
        public ObservableCollection<Genre> TousGenre = new ObservableCollection<Genre>();
        public Window1()
        {
            InitializeComponent();
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "RecupToutLesGenre";  //procedure stockée
            Command cmd = new Command(sql, true);
            foreach (Genre item in cnx.ExecuteReader(cmd, Genre.Converter))
            {
                TousGenre.Add(item);

            }
            dgUsers.ItemsSource = TousGenre;
            //dgusers est le nom dans le xaml
        }
        

    }
}

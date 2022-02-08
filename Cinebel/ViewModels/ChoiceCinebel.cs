using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinebel.Models;
using Cinebel.MvvMTools;
using System.Collections.ObjectModel;
using Cinebel.AdoToolbox;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Data;

namespace Cinebel.ViewModels 
{
    public class ChoiceCinebel : ViewModelBase

    {
       
        public ChoiceCinebel()
        {
            _TousGenre = new ObservableCollection<Genre>();
            _TousActeurs = new ObservableCollection<Personne>();
            _TousScenariste = new ObservableCollection<Scenaristes>();
            _TousRealisateur = new ObservableCollection<Realisateur>();
            AllGenre();
            AllActors();
            AllScenariste();
            AllRealisateur();
        }

       

        private string _Synopsis;
        public string Synopsis
        {
            get { return _Synopsis; }
            set
            {
                if (value != _Synopsis)
                {
                    _Synopsis = value;
                    RaisePropertyChanged(nameof(Synopsis));
                }
            }
        }
        private string _Titre;
        public string Titre
        {
            get { return _Titre; }
            set
            {
                if (value != _Titre)
                {
                    _Titre = value;
                    RaisePropertyChanged(nameof(Titre));
                }
            }
        }


        private DateTime _AnneeDeSortie = DateTime.Now;
        public DateTime AnneeDeSortie
        {
            get { return _AnneeDeSortie; }
            set
            {
                if (value != _AnneeDeSortie)
                {
                    _AnneeDeSortie = value;
                    RaisePropertyChanged(nameof(AnneeDeSortie));
                }
            }
        }

        private string _ConfirmationFilmAjouter;
        public string ConfirmationFilmAjouter
        {
            get { return _ConfirmationFilmAjouter; }
            set
            {
                _ConfirmationFilmAjouter = value; RaisePropertyChanged(nameof(ConfirmationFilmAjouter));
            }
        }

        private int _ScenaristeAjouter;
        public int ScenaristeAjouter
        {
            get { return _ScenaristeAjouter; }
            set
            {
                _ScenaristeAjouter = value; RaisePropertyChanged(nameof(ScenaristeAjouter));
            }
        }

        private int _RealisateurAjouter;
        public int RealisateurAjouter
        {
            get { return _RealisateurAjouter; }
            set
            {
                _RealisateurAjouter = value; RaisePropertyChanged(nameof(RealisateurAjouter));
            }
        }


        private Genre _Genres;
        public Genre Genres
        {
            get { return _Genres; }
            set
            {
                if (value != _Genres)
                {
                    _Genres = value;
                    RaisePropertyChanged(nameof(Genres));
                }
            }
        }



        private Scenaristes _ScenaristeSelecter;
        public Scenaristes ScenaristeSelecter
        {
            get { return _ScenaristeSelecter; }
            set
            {
                if (value != _ScenaristeSelecter)
                {
                    _ScenaristeSelecter = value;
                    RaisePropertyChanged(nameof(ScenaristeSelecter));
                }
            }
        }

        private Realisateur _RealisateurSelecter;
        public Realisateur RealisateurSelecter
        {
            get { return _RealisateurSelecter; }
            set
            {
                if (value != _RealisateurSelecter)
                {
                    _RealisateurSelecter = value;
                    RaisePropertyChanged(nameof(RealisateurSelecter));
                }
            }
        }

        private Personne _ActeurSelecter;
        public Personne ActeurSelecter
        {
            get { return _ActeurSelecter; }
            set
            {
                if (value != _ActeurSelecter)
                {
                    _ActeurSelecter = value;
                    RaisePropertyChanged(nameof(ActeurSelecter));
                }
            }
        }
       


        private ObservableCollection<Genre> _TousGenre;
        public ObservableCollection<Genre> TousGenre
        {
            get { return _TousGenre; }
            set
            {
                if (value != _TousGenre)
                {
                    _TousGenre = value;
                    RaisePropertyChanged(nameof(TousGenre));
                }
            }
        }




        public void AllGenre()
        {
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "RecupToutLesGenre";
            Command cmd = new Command(sql, true);
            foreach (Genre item in cnx.ExecuteReader(cmd, Genre.Converter))
            {
                TousGenre.Add(item);
            }
        }

        private ObservableCollection<Personne> _TousActeurs;
        public ObservableCollection<Personne> TousActeurs
        {
            get { return _TousActeurs; }
            set { _TousActeurs = value; }
        }
        public void AllActors()
        {
             string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllActors";  //procedure stockée
            Command cmd = new Command(sql, true);
            foreach (Personne item in cnx.ExecuteReader(cmd, Personne.Converter))
            {
                TousActeurs.Add(item);
            }

        }

        private ObservableCollection<Realisateur> _TousRealisateur;

        public ObservableCollection<Realisateur> TousRealisateur
        {
            get { return _TousRealisateur; }
            set { _TousRealisateur = value; RaisePropertyChanged("YourSelectedItem"); }
        }
        public void AllRealisateur()
        {
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllActors";  //procedure stockée
            Command cmd = new Command(sql, true);
            foreach (Realisateur item in cnx.ExecuteReader(cmd, Realisateur.Converter))
            {
                TousRealisateur.Add(item);
            }
        }


        private ObservableCollection<Scenaristes> _TousScenariste;

        public ObservableCollection<Scenaristes> TousScenariste
        {
            get { return _TousScenariste; }
            set { _TousScenariste = value; }
        }
        public void AllScenariste()
        {
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllActors";  //procedure stockée
            Command cmd = new Command(sql, true);
            foreach (Scenaristes item in cnx.ExecuteReader(cmd, Scenaristes.Converter))
            {
                TousScenariste.Add(item);
            }
        }

        private string _Affiche;

        public string Affiche { get { return _Affiche; }
            set { _Affiche = value; RaisePropertyChanged(nameof(ErrorMessageOk));
            }
        }




        private RelayCommand _AjouterImage;

        public RelayCommand AjouterImage
        {
            get { return _AjouterImage ?? (_AjouterImage = new RelayCommand(ChargerImage)); }
        }
        public void ChargerImage()
        {
            String savePath = @"./images/";
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
  

            }
        }

        private RelayCommand _AjouterFilm;

        public RelayCommand Ajouterfilm
        {
            get { return _AjouterFilm ?? (_AjouterFilm = new RelayCommand(AddFilm)); }
        }

        private string CheckFilm()
        {
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "CheckFilmExist";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("titre", Titre);
            string filmChecked = (string)cnx.ExecuteScalar(cmd);
            return filmChecked;
        }

        


        public void AddFilm()
        {
            string filmChecked = CheckFilm();
 
                string newDate = AnneeDeSortie.ToString("dd/MM/yyyy");
            ConfirmationFilmAjouter = "Film bien enregistré";

            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AjoutFilm";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("titre", Titre);
            cmd.AddParameter("AnneeSortie", newDate);
            cmd.AddParameter("Affiche", "tous");
            if (Genres != null)
                cmd.AddParameter("Id_Genre", Genres.Id);
            else
                cmd.AddParameter("Id_Genre", 1);
            
            if (RealisateurSelecter != null)
                cmd.AddParameter("Id_Realisateur", RealisateurSelecter.Id_Personne_real);
            else
                cmd.AddParameter("Id_Realisateur", 1);

            if (ScenaristeSelecter != null)
                cmd.AddParameter("ID_Scenariste", ScenaristeSelecter.Id_Personne_scen);
            else
                cmd.AddParameter("ID_Scenariste", 1);
            if(Synopsis != null)
                cmd.AddParameter("synopsis", Synopsis);
            else
                ConfirmationFilmAjouter = "Pas titre entré";
            cnx.ExecuteNonQuery(cmd);
            Synopsis = "";
            Titre = "";
            AnneeDeSortie = DateTime.Now;

        }

        /////////////////////////////////////////
        ////////////////////////////////////////
        ///Tabaitem 2
        ///



        private string _ErrorMessageOk = "Enregistrement";

        public string ErrorMessageOk
        {
            get { return _ErrorMessageOk; }
            set {_ErrorMessageOk = value;RaisePropertyChanged(nameof(ErrorMessageOk));
            }
        }


        private string _PreNomCreaPersonne;

        public string PreNomCreaPersonne {
            get { return _PreNomCreaPersonne; }
            set { _PreNomCreaPersonne = value; RaisePropertyChanged(nameof(PreNomCreaPersonne)); }
        }

        private string _NomCreaPersonne;

        public string NomCreaPersonne { get { return _NomCreaPersonne; }
        set { _NomCreaPersonne = value; RaisePropertyChanged(nameof(NomCreaPersonne)); }
        }

        private DateTime _DateNiassPersonne = DateTime.Now;
        public DateTime DateNiassPersonne 
        {
            get { return _DateNiassPersonne; }
            set { _DateNiassPersonne = value; RaisePropertyChanged(nameof(DateNiassPersonne)); }
        }

        private RelayCommand _AjouterPersonne;

        public RelayCommand AjouterPersonne
        {
            get { return _AjouterPersonne ?? (_AjouterPersonne = new RelayCommand(AddPersonne)); }
        }

        public void AddPersonne()
        {
            if (!string.IsNullOrEmpty(NomCreaPersonne))
                { 
                string newDate = DateNiassPersonne.ToString("dd/MM/yyyy");
                

                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "AjoutPersonne";
                Command cmd = new Command(sql, true);
                cmd.AddParameter("Nom", NomCreaPersonne);
                cmd.AddParameter("Prenom", PreNomCreaPersonne);
                cmd.AddParameter("Date", newDate);
                cnx.ExecuteNonQuery(cmd);
                ErrorMessageOk = $"Personne Enregistré {NomCreaPersonne}";
                NomCreaPersonne = "";
                PreNomCreaPersonne = "";
                DateNiassPersonne = DateTime.Now;
                AllActors();
                AllScenariste();
                AllRealisateur();
            }
        }


    }
}

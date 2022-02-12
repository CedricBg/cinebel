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
using Cinebel;

namespace Cinebel.ViewModels
{
    public class ChoiceCinebel : ViewModelBase
    {

        public ChoiceCinebel()
        {
            _TousGenre = new ObservableCollection<Genre>();
            _TousScenariste = new ObservableCollection<Scenaristes>();
            _TousRealisateur = new ObservableCollection<Realisateur>();
            _ListeFilmCrea = new ObservableCollection<film>();
            _ALLActors = new ObservableCollection<Acteur>();
            _ListeToutes = new  ObservableCollection<ModelListe>();

            AllGenre();
            AllScenariste();
            AllRealisateur();
            SelectAllFilms();
            AllListe();

        }

        /// <summary>
        /// //////////////////////////////////////Tab item Accueil/////////////////////////////
        /// </summary>
        /// 


        private string _typeFilm;

        public string typeFilm
        {
            get { return _typeFilm; }
            set
            {
                if (value != _typeFilm)
                {
                    _typeFilm = value;
                    RaisePropertyChanged(nameof(typeFilm));
                }
            }
        }

        private string _AfficherTitre;

        public string AfficherTitre
        {
            get { return _AfficherTitre; }
            set
            {
                if (value != _AfficherTitre)
                {
                    _AfficherTitre = value;
                    RaisePropertyChanged(nameof(AfficherTitre));
                }
            }
        }



        private string _imagess = "https://media-animation.be/local/cache-vignettes/Le";

        public string imagess
        {
            get { return _imagess; }
            set
            {
                if (value != _imagess)
                {
                    _imagess = value;
                    RaisePropertyChanged(nameof(imagess));
                }
            }
        }

        private int _ControleAffichage = 0;
        public int ControleAffichage
        {
            get { return _ControleAffichage; }
            set
            {
                if (value != _ControleAffichage)
                {
                    _ControleAffichage = value;
                    RaisePropertyChanged(nameof(ControleAffichage));
                }
            }
        }

        private string _AfficherGene;
        public string AfficherGene
        {
            get { return _AfficherGene; }
            set
            {
                if (value != _AfficherGene)
                {
                    _AfficherGene = value;
                    RaisePropertyChanged(nameof(AfficherGene));
                }
            }
        }


        private film _AfficherFilm;
        public film AfficherFilm
        {
            get { return _AfficherFilm; }
            set
            {
                if (value != _AfficherFilm)
                {
                    _AfficherFilm = value;
                    RaisePropertyChanged(nameof(AfficherFilm));
                }
            }
        }

        private RelayCommand _PinUpView;

        public RelayCommand PinUpView
        {
            get { return _PinUpView ?? (_PinUpView = new RelayCommand(ViewFilm)); }
        }


        private ObservableCollection<Acteur> _ALLActors;
        public ObservableCollection<Acteur> ALLActors
        {
            get { return _ALLActors; }
            set
            {
                if (value != _ALLActors)
                {
                    _ALLActors = value;
                    RaisePropertyChanged(nameof(ALLActors));
                }
            }
        }
        
        public void ViewFilm()
        {
            ALLActors.Clear();
            Synopsis = "";
            AfficherGene = "";
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AfficherActeursAccueil";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("Id_Film", AfficherFilm.Id);
            foreach (Acteur item in cnx.ExecuteReader(cmd, Acteur.Converter))
            {
                ALLActors.Add(item);
                imagess = item.Affichess;
                AfficherTitre = item.Titre;
                Synopsis = item.Synopsis;
                AfficherGene = item.Nom_Genre;



            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        private string _Connecte = $"Connecté en tant que {User.Nickname}";
        public string Connecte
        {
            get { return _Connecte; }
            set
            {
                if (value != _Connecte)
                {
                    _Connecte = value;
                    RaisePropertyChanged(nameof(Connecte));
                }
            }
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
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "RecupToutLesGenre";
            Command cmd = new Command(sql, true);
            foreach (Genre item in cnx.ExecuteReader(cmd, Genre.Converter))
            {
                TousGenre.Add(item);
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
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllActors";  //procedure stockée
            Command cmd = new Command(sql, true);
            foreach (Scenaristes item in cnx.ExecuteReader(cmd, Scenaristes.Converter))
            {
                TousScenariste.Add(item);
            }
        }

        private string _Affiche;

        public string Affiche
        {
            get { return _Affiche; }
            set
            {
                _Affiche = value; RaisePropertyChanged(nameof(ErrorMessageOk));
            }
        }

        private string _AjouterImage = "Https://";

        public string AjouterImage
        {
            get { return _AjouterImage; }
            set
            {
                _AjouterImage = value; RaisePropertyChanged(nameof(AjouterImage));
            }
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value; RaisePropertyChanged(nameof(Id));
            }
        }

        private RelayCommand _AjouterFilm;

        public RelayCommand Ajouterfilm
        {
            get { return _AjouterFilm ?? (_AjouterFilm = new RelayCommand(AddFilm)); }
        }

        private string CheckFilm()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "CheckFilmExist";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("titre", Titre);
            string filmChecked = (string)cnx.ExecuteScalar(cmd);
            return filmChecked;
        }

        public ObservableCollection<film> films { get; set; }
        public void AddFilm()
        {

            string filmChecked = CheckFilm();

            string newDate = AnneeDeSortie.ToString("dd/MM/yyyy");

            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AjoutFilm";
            Command cmd = new Command(sql, true);
            if (Titre != null || Synopsis != null)
                cmd.AddParameter("titre", Titre);
            cmd.AddParameter("AnneeSortie", newDate);
            if (AjouterImage != null)
                cmd.AddParameter("Affiche", AjouterImage);
            else
                cmd.AddParameter("Affiche", "/Images/Cine.jpg");
            cmd.AddParameter("Id_Genre", Genres.Id);
            cmd.AddParameter("Id_Realisateur", RealisateurSelecter.Id_Personne_real);
            cmd.AddParameter("ID_Scenariste", ScenaristeSelecter.Id_Personne_scen);
            cmd.AddParameter("synopsis", Synopsis);
            Id = (int)cnx.ExecuteScalar(cmd);
            ConfirmationFilmAjouter = "Film bien enregistré";
            Synopsis = "";
            Titre = "";
            AnneeDeSortie = DateTime.Now;
            _TousGenre = new ObservableCollection<Genre>();
            _TousScenariste = new ObservableCollection<Scenaristes>();
            _TousRealisateur = new ObservableCollection<Realisateur>();

            Acteurs acteurs = new Acteurs();
            acteurs.ShowDialog();


        }


        /////////////////////////////////////////
        ////////////////////////////////////////
        ///TabItem 2
        ///



        private string _ErrorMessageOk = "Enregistrement";

        public string ErrorMessageOk
        {
            get { return _ErrorMessageOk; }
            set
            {
                _ErrorMessageOk = value; RaisePropertyChanged(nameof(ErrorMessageOk));
            }
        }


        private string _PreNomCreaPersonne;

        public string PreNomCreaPersonne
        {
            get { return _PreNomCreaPersonne; }
            set { _PreNomCreaPersonne = value; RaisePropertyChanged(nameof(PreNomCreaPersonne)); }
        }

        private string _NomCreaPersonne;

        public string NomCreaPersonne
        {
            get { return _NomCreaPersonne; }
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
                string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                AllScenariste();
                AllRealisateur();

            }
        }

        ////////////////////////////////////////////Tabitem3//////////////////////////////////
        ////////////////////////////////////////////Tabitem3//////////////////////////////////
        ///

        private string _NomCreaListe;
        public string NomCreaListe
        {
            get { return _NomCreaListe; }
            set
            {
                _NomCreaListe = value; RaisePropertyChanged(nameof(ListeFilmCreaSelecter));
            }
        }

        private film _ListeFilmCreaSelecter;
        public film ListeFilmCreaSelecter
        {
            get { return _ListeFilmCreaSelecter; }
            set
            {
                _ListeFilmCreaSelecter = value; RaisePropertyChanged(nameof(ListeFilmCreaSelecter));
            }
        }

        private string _MessageCreaListe;
        public string MessageCreaListe
        {
            get { return _MessageCreaListe; }
            set
            {
                _MessageCreaListe = value; RaisePropertyChanged(nameof(MessageCreaListe));
            }
        }

        private int _IdCreaFilms;
        public int IdCreaFilms
        {
            get { return _IdCreaFilms; }
            set
            {
                _IdCreaFilms = value; RaisePropertyChanged(nameof(IdCreaFilms));
            }
        }
        private ObservableCollection<film> _ListeFilmCrea;
        public ObservableCollection<film> ListeFilmCrea
        {
            get { return _ListeFilmCrea; }
            set { _ListeFilmCrea = value; RaisePropertyChanged(nameof(ListeFilmCrea)); }

        }

        private RelayCommand _CreaList;

        public RelayCommand CreaList
        {
            get { return _CreaList ?? (_CreaList = new RelayCommand(CreationListe)); }
        }
        public void SelectAllFilms()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "Allfilms";
            Command cmd = new Command(sql, true);
            foreach (film item in cnx.ExecuteReader(cmd, film.ConvertAll))
            {
                foreach (Genre elt in TousGenre)
                {
                    if (item.Genre == elt.Id)
                    {
                        item.StrGenre = elt.NomGenre;
                    }
                }
                ListeFilmCrea.Add(item);
            }

        }
        public void CreationListe()
        {
            if (NomCreaListe != null)
            {

                string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "NewListe";
                Command cmd = new Command(sql, true);
                cmd.AddParameter("Id_Utilisateur", User.Id);
                cmd.AddParameter("NomListe", NomCreaListe);
                string NomDeListe = (string)cnx.ExecuteScalar(cmd);
                ListeMemo.Nom = NomCreaListe;
                ListeView window = new ListeView();
                window.ShowDialog();
            }
            else
            {
                if (ListeSelected != null)
                {
                    
                    ListeMemo.Nom = ListeSelected.NomListe;
                    ListeView window = new ListeView();
                    window.ShowDialog();
                }
            }
            
               

        }
        private ObservableCollection<ModelListe> _ListeToutes;
        public ObservableCollection<ModelListe> ListeToutes
        {
            get { return _ListeToutes; }
            set { _ListeToutes = value; RaisePropertyChanged(nameof(ListeToutes));}

        }
        private ModelListe _ListeSelected;
        public ModelListe ListeSelected
        {
            get { return _ListeSelected; }
            set
            {
                _ListeSelected = value; RaisePropertyChanged(nameof(ListeSelected));
            }
        }
        public void AllListe()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllListe";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("Id_Utilisateur", User.Id);
            foreach (ModelListe item in cnx.ExecuteReader(cmd, ModelListe.Converter))
            {
                ListeToutes.Add(item);
            };
        }

    }
}

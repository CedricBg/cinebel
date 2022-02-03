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

namespace Cinebel.ViewModels 
{
    public class ChoiceCinebel : ViewModelBase
    {
        public ChoiceCinebel()
        {
            AllGenre();
        }

        private string _Id;
        public string Id
        {
            get { return _Id; }
        }

        private string _NomGenre;
        public string NomGenre
        {
            get { return _NomGenre; }
            set
            {
                if (value != _NomGenre)
                {
                    _NomGenre = value;
                    RaisePropertyChanged(nameof(NomGenre));
                }
            }
        }
        private int _Id_Genre;

        public int Id_Genre
        {
            get { return _Id_Genre; }
            set
            {
                if (value != _Id_Genre)
                {
                    _Id_Genre = value;
                    RaisePropertyChanged(nameof(Id_Genre));
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
        private string _Realisateur;
        public string Realisateur
        {
            get { return _Realisateur; }
            set
            {
                if (value != _Realisateur)
                {
                    _Realisateur = value;
                    RaisePropertyChanged(nameof(Realisateur));
                }
            }
        }
        private string _Scenariste;
        public string Scenariste
        {
            get { return _Scenariste; }
            set
            {
                if (value != _Scenariste)
                {
                    _Scenariste = value;
                    RaisePropertyChanged(nameof(Scenariste));
                }
            }
        }

        private string _Affiche;
        public string Affiche
        {
            get { return _Affiche; }
            set
            {
                if (value != _Affiche)
                {
                    _Affiche = value;
                    RaisePropertyChanged(nameof(Affiche));
                }
            }
        }
        private string _AnneeDeSortie;
        public string AnneeDeSortie
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
        private RelayCommand _TouGenre;
        public RelayCommand TouGenre
        {
            get { return _TouGenre ?? (_TouGenre = new RelayCommand(AllGenre)); }
        }

        public ObservableCollection<Genre> TousGenre = new ObservableCollection<Genre>();

        public void AllGenre()
        {

            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "RecupToutLesGenre";

            Command cmd = new Command(sql, true);

            foreach (Genre item in cnx.ExecuteReader(cmd, Genre.Converter))
            {
                TousGenre.Add(item);
            }
        }


        private RelayCommand _AjouterFilm;

        public RelayCommand Ajouterfilm
        {
            get { return _AjouterFilm ?? (_AjouterFilm = new RelayCommand(AddFilm)); }
        }

        private string CheckFilm()
        {
                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            if(filmChecked != Titre) 
            {
                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "UserRegister";
                Command cmd = new Command(sql, true);
                cmd.AddParameter("titre", Titre);
                cmd.AddParameter("Annee_de_sortie", AnneeDeSortie);
                cmd.AddParameter("Affiche", Affiche);
                cmd.AddParameter("Genre", NomGenre);
                cmd.AddParameter("Scenariste", Scenariste);
                cmd.AddParameter("Realisateur", Realisateur);
                cmd.AddParameter("synopsis", Synopsis);

                cnx.ExecuteNonQuery(cmd);

            } 
        }
    }
}

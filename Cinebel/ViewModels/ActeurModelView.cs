using Cinebel.AdoToolbox;
using Cinebel.Models;
using Cinebel.MvvMTools;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinebel;

namespace Cinebel.ViewModels
{
    public class ActeurModelView : ViewModelBase
    {
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

        private Personne _Id;
        public Personne Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }

        }

        public ActeurModelView()
        {

            _TousActeurs = new ObservableCollection<Personne>();
            _TousFilms = new ObservableCollection<int>();
            AllActors();
        }

        private string _Role;
        public string Role
        {
            get { return _Role; }
            set
            {
                if (value != _Role)
                {
                    _Role = value;
                    RaisePropertyChanged(nameof(Role));
                }
            }
        }

        private string _EnregistrementMessage;
        public string EnregistrementMessage
        {
            get { return _EnregistrementMessage; }
            set
            {
                if (value != _EnregistrementMessage)
                {
                    _EnregistrementMessage = value;
                    RaisePropertyChanged(nameof(EnregistrementMessage));
                }
            }
        }

        private string _IdPersonne;
        public string IdPersonne
        {
            get { return _IdPersonne; }
            set
            {
                if (value != _IdPersonne)
                {
                    _IdPersonne = value;
                    RaisePropertyChanged(nameof(IdPersonne));
                }
            }
        }

        private film _IdFilm;
        public film IdFilm
        {
            get { return _IdFilm; }
            set
            {
                if (value != _IdFilm)
                {
                    _IdFilm = value;
                    RaisePropertyChanged(nameof(IdFilm));
                }
            }
        }
        private Personne _Acteurs;
        public Personne Acteurs
        {
            get { return _Acteurs; }
            set
            {
                if (value != _Acteurs)
                {
                    _Acteurs = value;
                    RaisePropertyChanged(nameof(Acteurs));
                }
            }
        }

        private ObservableCollection<Personne> _TousActeurs;
        public ObservableCollection<Personne> TousActeurs
        {
            get { return _TousActeurs; }
            set
            {
                if (value != _TousActeurs)
                {
                    _TousActeurs = value;
                    RaisePropertyChanged(nameof(TousActeurs));
                }
            }
        }

        private ObservableCollection<int> _TousFilms;
        public ObservableCollection<int> TousFilms
        {
            get { return _TousFilms; }
            set
            {
                if (value != _TousFilms)
                {
                    _TousFilms = value;
                    RaisePropertyChanged(nameof(TousFilms));
                }
            }
        }

        private RelayCommand _Actors;

        public RelayCommand Actors
        {
            get { return _Actors ?? (_Actors = new RelayCommand(AddActors)); }
        }

        public void AllActors()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "AllActors";
            Command cmd = new Command(sql, true);
            foreach (Personne item in cnx.ExecuteReader(cmd, Personne.Converter))
            {
                TousActeurs.Add(item);
            }

        }
        public void allFilms()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "LesFilms";
            Command cmd = new Command(sql, true);
            foreach (film item in cnx.ExecuteReader(cmd, film.Converter))
            {
                TousFilms.Add(item.Id);
            }
        }
        public void AddActors()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            allFilms();
            Connection cnx = new Connection(cs);
            string sql = "AddActors";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("Role", Role);
            cmd.AddParameter("Id_Personne", Id.Id_Personne);
            cmd.AddParameter("Id_Film", TousFilms.Last());
            cnx.ExecuteNonQuery(cmd);
            EnregistrementMessage = $"{Role}";
        }
    }
}

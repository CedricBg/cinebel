using Cinebel.AdoToolbox;
using Cinebel.Models;
using Cinebel.MvvMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.ViewModels
{
    public class ListModelView : ViewModelBase
    {

        public ListModelView()
        {
            _TousGenre = new ObservableCollection<film>();
            _ListeFilmCrea = new ObservableCollection<Genre>();
            AllGenre();
            SelectAllFilms();
        }


        private film _filmSelecter;
        public film filmSelecter
        {
            get { return _filmSelecter; }
            set
            {
                if (value != _filmSelecter)
                {
                    _filmSelecter = value;
                    RaisePropertyChanged(nameof(filmSelecter));
                }
            }
        }

        private ObservableCollection<Genre> _ListeFilmCrea;
        public ObservableCollection<Genre> ListeFilmCrea
        {
            get { return _ListeFilmCrea; }
            set { _ListeFilmCrea = value; RaisePropertyChanged(nameof(ListeFilmCrea)); }

        }

        private ObservableCollection<film> _TousGenre;

        public ObservableCollection<film> TousGenre
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
                ListeFilmCrea.Add(item);
            }
        }
        public void SelectAllFilms()
        {
            string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "Allfilms";
            Command cmd = new Command(sql, true);
            foreach (film item in cnx.ExecuteReader(cmd, film.ConvertAll))
            {

                    foreach (Genre elt in ListeFilmCrea)
                    {
                        if (item.Genre == elt.Id)
                        {
                            item.StrGenre = elt.NomGenre;
                        }
                    }
                    TousGenre.Add(item);
            }
        }

        private RelayCommand _AddFilm;

        public RelayCommand AddFilm
        {
            get { return _AddFilm ?? (_AddFilm = new RelayCommand(enregistrefilmInList)); }
        }

        public void enregistrefilmInList()
        {
            // string cs = @"Data Source=DESKTOP-CEUURF0\MSSQLSERVER2;Initial Catalog=Cinebel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    Connection cnx = new Connection(cs);
            //    string sql = "insertFilmsinListe";
            //    Command cmd = new Command(sql, true);
            //    cmd.AddParameter("Id_Utilisateur", User.Id);
            //    cmd.AddParameter("NomListe", ListeMemo.Nom);
            //    cmd.AddParameter("idFilm", filmSelecter.Id);
            //    cnx.ExecuteNonQuery(cmd);
        }
    }
    
}

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
using System.Diagnostics;
using System.Windows;

namespace Cinebel.ViewModels
{
    
    public class LoginCinebel : ViewModelBase 
    {
        static bool connecte = false;

        private string _NickName;
        public string NickName
        {
            get { return _NickName; }
            set
            {
                if (value != _NickName) 
                { 
                    _NickName = value;
                    RaisePropertyChanged(nameof(NickName));
                } 
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value != _Password)
                {
                    _Password = value;
                    RaisePropertyChanged(nameof(Password));
                }
            }
        }

        private string _ErrorMessage;

        public string ErrorMessage {
            get => _ErrorMessage; 
            set
            {
                _ErrorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            } 
        }


        private RelayCommand _Register;
        public RelayCommand Register
        {
            get { return _Register ?? (_Register = new RelayCommand(AddUser)); }
        }

        private string CheckUser()
        {
            string UserChecked = null;
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "CheckUser";
            Command cmd = new Command(sql, true);
            cmd.AddParameter("NickName", NickName);
            UserChecked = (string)cnx.ExecuteScalar(cmd);
            return UserChecked;
        }

        public void AddUser()
        {
            string UserChecked = CheckUser();
            if (!string.IsNullOrEmpty(NickName) && !string.IsNullOrEmpty(Password))
            {
                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "UserRegister";
                Command cmd = new Command(sql, true);
                cmd.AddParameter("NickName", NickName);
                cmd.AddParameter("Password", Password);
                cnx.ExecuteNonQuery(cmd);
            }
        }

        public ObservableCollection<Genre> TousGenre = new ObservableCollection<Genre>();

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


        private RelayCommand _Login;
        public RelayCommand Login
        {
            get { return _Login ?? (_Login = new RelayCommand(LoginUser)); }
        }

        public void LoginUser()
        {
            if (!string.IsNullOrEmpty(NickName) && !string.IsNullOrEmpty(Password))
            {
                ErrorMessage = null;
                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=2163945Aa;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "UserLogin";

                Command cmd = new Command(sql, true);
                cmd.AddParameter("NickName", NickName);
                cmd.AddParameter("Password", Password);

                if (cnx.ExecuteScalar(cmd) != null)
                {
                    connecte = true;
                    Window1 window1 = new Window1();
                    NickName = "";
                    Password = "";
                    window1.Show();
                    Application.Current.Windows[0].Close();
                }
                else
                {
                    ErrorMessage = "Bad Crédentials";
                }
            }
            
        }

        


        private RelayCommand _ChangeButton;
        public RelayCommand ChangeButton
        {
            get { return _ChangeButton ?? (_ChangeButton = new RelayCommand(ButtonRegister)); }
        }


        static bool changer = false;
        
        
        public void ButtonRegister()
        {
            if(changer)
                //clickedButton.Visible = false;
                
            changer = false;
            else
                changer = true;


        }
      

    }
}

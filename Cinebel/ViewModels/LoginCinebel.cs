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
            get { return _NickName; }
            set
            {
                if (value != _Password)
                {
                    _Password = value;
                    RaisePropertyChanged(nameof(Password));
                }
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
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            if (UserChecked == null)
            {
                string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                Connection cnx = new Connection(cs);
                string sql = "UserRegister";
                Command cmd = new Command(sql, true);
                cmd.AddParameter("NickName", NickName);
                cmd.AddParameter("Password", Password);
                cnx.ExecuteNonQuery(cmd);
            }
        }

        private RelayCommand _Login;
        public RelayCommand Login
        {
            get { return _Login ?? (_Login = new RelayCommand(LoginUser)); }
        }

        public void LoginUser()
        {
            string NickNameDb = null;
            string cs = @"Data Source=DESKTOP-05K31B6\VE_SERVER;Initial Catalog=Cinebel;User ID=kirk;Password=090063554744;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Connection cnx = new Connection(cs);
            string sql = "UserLogin";

            Command cmd = new Command(sql, true);
            cmd.AddParameter("NickName", NickName);
            cmd.AddParameter("Password", Password);
            NickNameDb = (string)cnx.ExecuteScalar(cmd);

            if(NickNameDb == NickName)
            {
                connecte = true;
                Window1 window1 = new Window1();
                window1.Show();
                
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.Models
{
    public class Utilisateur
    {
        public string NickName { get; set; }
        public string password { get; set; }
        public int ID { get; set; } 


        public static Utilisateur Converter(SqlDataReader reader)
        {
            return new Utilisateur
            {
                NickName = (string)reader["NickName"],
                ID = (int)reader["Id_Utilisateur"]
            };
        }
    } 
} 

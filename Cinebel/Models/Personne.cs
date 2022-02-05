using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cinebel.Models
{
    public class Personne
    {
        public string NickName { get; set; }
        public string password { get; set; }

        public static Personne Converter(SqlDataReader reader)
        {
            return new Personne
            {
                NickName = (string)reader["NickName"],
                password = (string)reader["password"]
            };
        }

    }

    
}

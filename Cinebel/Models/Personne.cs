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
        public int Id_Personne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Date_Naiss { get; set; }

        public static Personne Converter(SqlDataReader reader)
        {
            return new Personne
            {
                Id_Personne = (int)reader["Id_Pers"],
                Nom = (string)reader["Nom_Pers"],
                Prenom = (string)reader["Prenom_Pers"],
            };
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.Models
{
    public class Realisateur
    {
        public int Id_Personne_real { get; set; }
        public string Nom_real { get; set; }
        public string Prenom_real { get; set; }

        public static Realisateur Converter(SqlDataReader reader)
        {
            return new Realisateur
            {
                Id_Personne_real = (int)reader["Id_Pers"],
                Nom_real = (string)reader["Nom_Pers"],
                Prenom_real = (string)reader["Prenom_Pers"]
            };
        }
    }
}

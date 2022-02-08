using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.Models
{
    public class Scenaristes
    {
       
            public int Id_Personne_scen { get; set; }
            public string Nom_scen { get; set; }
            public string Prenom_scen { get; set; }
            

            public static Scenaristes Converter(SqlDataReader reader)
            {
                return new Scenaristes
                {
                    Id_Personne_scen = (int)reader["Id_Pers"],
                    Nom_scen = (string)reader["Nom_Pers"],
                    Prenom_scen = (string)reader["Prenom_Pers"],
                };
        }
    }
}

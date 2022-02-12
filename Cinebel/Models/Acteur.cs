using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.Models
{
    public class Acteur
    {
        public string Role { get; set; }
        public string  Nom { get; set; }
        public string Prenom { get; set; }
        public string Titre { get; set; }
        public string AnneeDeSortie { get; set; }
        public string Synopsis { get; set; }
        public string Nom_Genre { get; set; }
        public string Affichess { get; set; }

        public static Acteur Converter(SqlDataReader reader)
        {
            return new Acteur
            {
                Role = (string)reader["Role"],
                Nom = (string)reader["Nom_Pers"],
                Prenom = (string)reader["Prenom_Pers"],
                Titre = (string)reader["titre"],
                AnneeDeSortie = (string)reader["Annee_de_sortie"],
                Synopsis = (string)reader["Synopsis"],
                Nom_Genre = (string)reader["Nom_genre"],
                Affichess = (string)reader["Affiche"],
            };
        }
    }
}

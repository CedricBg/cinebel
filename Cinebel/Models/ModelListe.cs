using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cinebel.Models
{
    public class ModelListe
    {
        public int Id { get; set; }
        public int Id_Utilisateur { get; set; }
        public string NomListe { get; set; }
        


        public static ModelListe Converter(SqlDataReader reader)
        {
            return new ModelListe
            {
                Id = (int)reader["Id"],
                Id_Utilisateur = (int)reader["Id_Utilisateur"],
                NomListe = (string)reader["NomListe"],

            };
        }
    }
}

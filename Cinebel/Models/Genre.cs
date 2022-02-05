using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Cinebel.AdoToolbox;
using Cinebel.MvvMTools;
using System.Collections.ObjectModel;

namespace Cinebel.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string NomGenre { get; set; }

        public static Genre Converter(SqlDataReader reader)
        {
            return new Genre
            {
                Id = (int)reader["Id_Genre"],
                NomGenre = (string)reader["Nom_genre"], 
            };
        }

        

        
    }
}

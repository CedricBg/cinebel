using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Cinebel.Models
{
    public class film
    {
        public int Id { get; set; }
        public int Genre { get; set; }
        public string Synopsis { get; set; }
        public string Titre { get; set; }
        public int Realisateur { get; set; }
        public int Scenariste { get; set; }
        public string Affiche { get; set; }
        public string AnneeDeSortie { get; set; }


        public static film Converter(SqlDataReader reader)
        {
            return new film
            {
                Id = (int)reader["Id_Film"],
               
            };
        }
    }

}

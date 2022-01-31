using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinebel.Models
{
    public class film
    {
        public int Id { get; set; }
        public int Genre { get; set; }
        public int Realisateur { get; set; }
        public int Scenariste { get; set; }
        public string Synopsis { get; set; }
        public string Titre { get; set; }
        public string Affiche { get; set; }
        public DateTime AnneeDeSortie { get; set; }


    }
}

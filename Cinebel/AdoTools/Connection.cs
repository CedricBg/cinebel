using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoToolbox
{
    public class Connection
    {
        SqlConnection _connection;
        public SqlConnection connection
        {
           private get { return _connection; }
            set { _connection = value; }
        }


        public Connection(string connexionString)
        {
            connection = new SqlConnection(connexionString);
        }

        
        public bool ExecuteNonQuery(Command cmd)
        {
            connection
                using (SqlCommand cmd = connexion.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Produit SET QteStock = @QteStock Where IdProduit = '{nrProduit}';";
                    connexion.Open();
                    cmd.Parameters.AddWithValue("QteStock", QuantiteStock);
                    int Qte = (int)cmd.ExecuteNonQuery();
                    connexion.Close();

                }

        }

        public object ExecuteScalar(Command cmd)
        {
            
        }

        public IEnumerable<T> ExecuteReader<T>(Command cmd)
        {

            //yield return ;
            //Vous aurez besoin d'un delegate type Func
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(Command cmd)
        {
            //return new DataTable();

        }
    }
}

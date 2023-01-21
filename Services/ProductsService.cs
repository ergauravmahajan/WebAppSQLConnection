using System.Data.Sql;
using System.Data.SqlClient;
using WebAppSQLConnection.Models;

namespace WebAppSQLConnection.Services
{
    public class ProductsService
    {
        private static string db_source = "appdbserver-gaurav.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "password@123";
        private static string db_database = "app-db";

        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource= db_source;
            sqlConnectionStringBuilder.UserID= db_user;
            sqlConnectionStringBuilder.Password= db_password;
            sqlConnectionStringBuilder.InitialCatalog= db_database;
            return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public List<Products> GetProducts()
        {
            SqlConnection sqlConnection = GetConnection();
            List<Products> products = new List<Products>();

            String statement = "select ProductsId,ProductName,Quantity from Products";
            sqlConnection.Open();
            SqlCommand sqlCommand= new SqlCommand(statement, sqlConnection);
            using (SqlDataReader  reader= sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products products1 = new Products()
                    {
                        ProductsID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };
                    products.Add(products1);
                }
               
            }

            sqlConnection.Close();
            return products;
        }

    }
}

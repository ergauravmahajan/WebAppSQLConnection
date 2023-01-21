using System.Data.Sql;
using System.Data.SqlClient;
using WebAppSQLConnection.Models;

namespace WebAppSQLConnection.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IConfiguration _configuration;

        public ProductsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnectionString"));
        }

        public List<Products> GetProducts()
        {
            SqlConnection sqlConnection = GetConnection();
            List<Products> products = new List<Products>();

            String statement = "select ProductsId,ProductName,Quantity from Products";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(statement, sqlConnection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
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

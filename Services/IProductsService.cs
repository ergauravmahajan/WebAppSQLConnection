using WebAppSQLConnection.Models;

namespace WebAppSQLConnection.Services
{
    public interface IProductsService
    {
        List<Products> GetProducts();
    }
}
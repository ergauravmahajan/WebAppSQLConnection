using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSQLConnection.Models;
using WebAppSQLConnection.Services;

namespace WebAppSQLConnection.Pages
{
    public class IndexModel : PageModel
    {
       
        public List<Products> Products;
        public void OnGet()
        {
            ProductsService productsService = new ProductsService();
            Products = productsService.GetProducts();
        }
    }
}
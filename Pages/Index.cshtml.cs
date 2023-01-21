using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSQLConnection.Models;
using WebAppSQLConnection.Services;

namespace WebAppSQLConnection.Pages
{
    public class IndexModel : PageModel
    {
       
        public List<Products> Products;

        private readonly IProductsService productsService1;

        public IndexModel(IProductsService productsService)
        {
            productsService1 = productsService;
        }
        public void OnGet()
        {
            Products = productsService1.GetProducts();
        }
    }
}
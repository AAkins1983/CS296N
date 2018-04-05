using System.Linq;

//This class doesn’t do anything especially useful, but it does have a dependency on the IRepository
//interface, which means using dependency injection will resolve this dependency using the configuration
//that applies to the rest of the application as well., I have declared the ProductTotalizer
//class as a dependency of the HomeController class
namespace DependencyInjection.Models
{
    public class ProductTotalizer
    {
        public ProductTotalizer(IRepository repo) => Repository = repo;
        public IRepository Repository { get; set; }
        public decimal Total => Repository.Products.Sum(p => p.Price);
    }
}

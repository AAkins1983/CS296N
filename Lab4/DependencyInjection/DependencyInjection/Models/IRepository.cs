using System.Collections.Generic;

namespace DependencyInjection.Models
{
    //The interface defines the operations that can be performed on the 
    //collection of Product objects
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product this[string name] { get; }

        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
}

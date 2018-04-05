using System.Collections.Generic;

//This interface defines the behavior of a simple storage mechanism for Product objects
namespace DependencyInjection.Models
{
    public interface IModelStorage
    {
        IEnumerable<Product> Items { get; }
        Product this[string key] { get; set; }
        bool ContainsKey(string key);
        void RemoveItem(string key);
    }
}

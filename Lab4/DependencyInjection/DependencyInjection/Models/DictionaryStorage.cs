using System.Collections.Generic;

//The DictionaryStorage class implements the IModelStorage interface by using a strongly
//typed dictionary to store model object
namespace DependencyInjection.Models
{
    public class DictionaryStorage : IModelStorage
    {
        private Dictionary<string, Product> items
        = new Dictionary<string, Product>();
        public Product this[string key]
        {
            get { return items[key]; }
            set { items[key] = value; }
        }
        public IEnumerable<Product> Items => items.Values;
        public bool ContainsKey(string key) => items.ContainsKey(key);
        public void RemoveItem(string key) => items.Remove(key);
    }
}

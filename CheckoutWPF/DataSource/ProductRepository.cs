using CheckoutWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutWPF.DataSource
{
    public class ProductNotFoundException : Exception
    {
        public int ProductID { get; set; }

        public ProductNotFoundException(int id)
        {
            ProductID = id;
        }
    }

    public class ProductRepository
    {
        private static List<Product> _products;

        static ProductRepository()
        {
            GenerateProducts();
        }

        private static void GenerateProducts()
        {
            _products = new List<Product>();
            _products.Add(new Product()
            {
                ID = 1,
                Name = "Spaghetti",
                Price = 5.50m
            });
            _products.Add(new Product()
            {
                ID = 2,
                Name = "Lasagne",
                Price = 7.20m
            });
            _products.Add(new Product()
            {
                ID = 3,
                Name = "Pesto",
                Price = 2.30m
            });
            _products.Add(new Product()
            {
                ID = 4,
                Name = "Olivenöl",
                Price = 2.30m
            });
        }

        public static bool TryGetProductById(int id, out Product product)
        {
            product = _products.Find(x => x.ID == id);

            return product != null;
        }

        public static Product GetProductById(int id)
        {
            try
            {
                return _products.Single(x => x.ID == id);
            }
            catch(Exception)
            {
                throw new ProductNotFoundException(id);
            }            
        }
    }
}

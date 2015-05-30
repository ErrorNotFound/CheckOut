using CheckoutWPF.Abstract;
using CheckoutWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class ProductRepository : AbstractModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                if (value == _products)
                    return;

                _products = value;
                OnPropertyChanged();
            }
        }

        private ProductRepository()
        {
            GenerateProducts();
        }

        private static ProductRepository _instance;
        public static ProductRepository Instance { get { return _instance ?? (_instance = new ProductRepository()); } }

        private void GenerateProducts()
        {
            _products = new ObservableCollection<Product>();
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
            _products.Add(new Product()
            {
                ID = 5,
                Name = "Reis",
                Price = 1.50m
            });
            _products.Add(new Product()
            {
                ID = 6,
                Name = "Kloß mit Soß",
                Price = 2.00m
            });
            _products.Add(new Product()
            {
                ID = 7,
                Name = "Schweinshaxe",
                Price = 8.50m
            });
            _products.Add(new Product()
            {
                ID = 8,
                Name = "Ein Product mit ganz langem Namen",
                Price = 88.99m
            });
            _products.Add(new Product()
            {
                ID = 9,
                Name = "Ein Product mit ganz langem Namen, aber noch lääääääääännnnnnnnnnger",
                Price = 188.99m
            });
            _products.Add(new Product()
            {
                ID = 10,
                Name = "Test 1",
                Price = 8.99m
            });
            _products.Add(new Product()
            {
                ID = 11,
                Name = "Test 2",
                Price = 8.99m
            });
            _products.Add(new Product()
            {
                ID = 12,
                Name = "Test 3",
                Price = 8.99m
            });

        }

        public bool TryGetProductById(int id, out Product product)
        {
            try
            {
                product = _products.Single(x => x.ID == id);

                return true;
            }
            catch (Exception)
            {
                product = null;
                return false;
            }
        }

        public Product GetProductById(int id)
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

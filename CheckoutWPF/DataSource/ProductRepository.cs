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

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                if (value == _categories)
                    return;

                _categories = value;
                OnPropertyChanged();
            }
        }



        private ProductRepository()
        {
            GenerateCategories();
            GenerateProducts();
        }


        private static ProductRepository _instance;
        public static ProductRepository Instance { get { return _instance ?? (_instance = new ProductRepository()); } }

        private void GenerateCategories()
        {
            _categories = new ObservableCollection<Category>();
            _categories.Add(new Category()
            {
                Name = "None",
                Id = 0
            });
            _categories.Add(new Category()
            {
                Name = "Food",
                Id = 1
            });
            _categories.Add(new Category()
            {
                Name = "Drinks",
                Id = 2
            });
            _categories.Add(new Category()
            {
                Name = "Deserts",
                Id = 3
            });
        }

        private void GenerateProducts()
        {
            _products = new ObservableCollection<Product>();
            _products.Add(new Product()
            {
                Id = 1,
                Name = "Spaghetti",
                CategoryId = 1,
                Price = 5.50m
            });
            _products.Add(new Product()
            {
                Id = 2,
                Name = "Lasagne",
                CategoryId = 1,
                Price = 7.20m
            });
            _products.Add(new Product()
            {
                Id = 3,
                Name = "Kloß mit Soß",
                CategoryId = 1,
                Price = 2.30m
            });
            _products.Add(new Product()
            {
                Id = 4,
                Name = "Olivenöl",
                CategoryId = 2,
                Price = 2.30m
            });
            _products.Add(new Product()
            {
                Id = 5,
                Name = "Spezi",
                CategoryId = 2,
                Price = 1.50m
            });
            _products.Add(new Product()
            {
                Id = 6,
                Name = "Bier",
                CategoryId = 2,
                Price = 2.00m
            });
            _products.Add(new Product()
            {
                Id = 7,
                Name = "Limo",
                CategoryId = 2,
                Price = 8.50m
            });
            _products.Add(new Product()
            {
                Id = 8,
                Name = "Ein Product mit ganz langem Namen",
                CategoryId = 0,
                Price = 88.99m
            });
            _products.Add(new Product()
            {
                Id = 9,
                Name = "Ein Product mit ganz langem Namen, aber noch lääääääääännnnnnnnnnger",
                CategoryId = 0,
                Price = 188.99m
            });
            _products.Add(new Product()
            {
                Id = 10,
                Name = "Test 1",
                CategoryId = 0,
                Price = 8.99m
            });
            _products.Add(new Product()
            {
                Id = 11,
                Name = "Test 2",
                CategoryId = 0,
                Price = 8.99m
            });
            _products.Add(new Product()
            {
                Id = 12,
                Name = "Test 3",
                CategoryId = 0,
                Price = 8.99m
            });

        }

        public bool TryGetProductById(int id, out Product product)
        {
            try
            {
                product = _products.Single(x => x.Id == id);

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
                return _products.Single(x => x.Id == id);
            }
            catch(Exception)
            {
                throw new ProductNotFoundException(id);
            }            
        }
    }
}

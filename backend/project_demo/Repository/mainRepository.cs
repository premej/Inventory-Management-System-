using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_demo.Data;
using project_demo.Model;
using project_demo.Model.DTO;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace project_demo.Repository
{
    public class mainRepository : Imainrepository
    {
       private readonly AppDbContext _context;
        private readonly ILogger<mainRepository> _logger;
        public mainRepository(AppDbContext context,ILogger<mainRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Purchase Newpurchaseasync(int user_id, int productid, int Quantity, string suppliername)
        {
            try
            {
                var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == user_id);
                if (supplier == null)
                {
                    return null;//Supplier does not exist in the database. Please add the supplier to continue.";
                }
                var test = _context.products.FirstOrDefault(p => p.ProductId == productid);
                if (test == null)
                {
                    // return NotFound("The mentioned product is not in not in database ");
                    return null;
                }

                var res = new Purchase { USerId = user_id, quantity = Quantity, PurchaseDate = DateTime.Now, Invoice_Amount = (test.price * Quantity), Supplier_Name = suppliername, ProductId = productid };
                _context.Purchases.Add(res);
                _context.SaveChanges();
                var st1 = _context.stocks.FirstOrDefault(p => p.ProductId == productid);
                if (st1 != null)
                {
                    st1.Quantity += Quantity;
                    st1.Last_modified = DateTime.Now;
                }



                _context.SaveChanges();
                _logger.LogInformation("Purchase for user {UserId} and product {ProductId} completed successfully.", user_id, productid);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing Newpurchaseasync.");
                throw;
            }


        }
        Product Imainrepository.NewProduct(string ProductName, string product_detail, string category_Name, int category_id, string Category_Name, int amount)
        {
            var existingCategory = _context.categories.FirstOrDefault(c => c.category_id == category_id || c.category_Name == category_Name);

            // If the category doesn't exist, add it to the Category table
            if (existingCategory == null)
            {
                var newCategory = new Category { category_id = category_id, category_Name = category_Name };
                _context.categories.Add(newCategory);
                _context.SaveChanges();
            }
            var res = new Product { ProductName = ProductName, Product_detail = product_detail, Category_name = Category_Name, Category_id = category_id, CategoryName = Category_Name, price = amount };

            _context.products.Add(res);
            _context.SaveChanges();
            var res1 = _context.products.FirstOrDefault(p => p.ProductName == ProductName);
            var st1 = new Stock { ProductId = res1.ProductId, Quantity = 0, Last_modified = DateTime.Now, min_Quantity = 10, max_Quantity = 50 };
            _context.stocks.Add(st1);
            _context.SaveChanges();
            return res;
        }
        public async Task<IEnumerable<Product>> GetOutOfStockProductsAsync()
        {
            return await _context.products
                                 .Where(p => _context.stocks.Any(s => s.ProductId == p.ProductId && s.Quantity == 0))
                                 .ToListAsync();
        }
        public async Task<bool> SetMinQuantityAsync(string productName, int minQuantity)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.ProductName == productName);
            if (product == null)
            {
                return false;
            }
            var stock = await _context.stocks.FirstOrDefaultAsync(s => s.ProductId == product.ProductId);
            if (stock == null)
            {
                return false;
            }
            stock.min_Quantity = minQuantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetMaxQuantityAsync(string productName, int maxQuantity)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.ProductName == productName);
            if (product == null)
            {
                return false;
            }
            var stock = await _context.stocks.FirstOrDefaultAsync(s => s.ProductId == product.ProductId);
            if (stock == null)
            {
                return false;
            }
            stock.max_Quantity = maxQuantity;
            await _context.SaveChangesAsync();
            return true;
        }
     
        public string NewSaleAsync(int customer_id, string customername, int productid, int quantity)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customer_id);
            if (customer == null)
            {
                return "Customer does not exist in the database. Please add the customer to continue.";
            }
            var test = _context.products.FirstOrDefault(p => p.ProductId == productid);
            if (test == null)
            {
                return "The mentioned product is not in not in database ";
            }

            var st1 = _context.stocks.FirstOrDefault(p => p.ProductId == productid);
            if (st1.Quantity >= quantity)
            {
                var res = new Sale { USerId = customer_id, Sale_Date = DateTime.Now, Customer_name = customername, ProductId = productid, Quantity = quantity, amount = (test.price * quantity) };
                _context.Sales.Add(res);
            }
            else if(st1.Quantity < quantity)
            { 
                return "insufficent quantity" ;
            }

            if (st1 != null)
            {
                st1.Quantity -= quantity;
                st1.Last_modified = DateTime.Now;
            }
            _context.SaveChanges();
            return "OK";
        }

       

        public  List<dynamic> UserTransaction()
        {
            //    var pur =  _context.Purchases.Select(p => new
            //    {
            //        productid=p.ProductId,
            //        date = p.PurchaseDate,
            //        Type = "In",
            //        Amount = p.Invoice_Amount
            //    }).ToList();
            //    var sel =  _context.Sales.Select(p => new
            //    {
            //        productid=p.ProductId,
            //        date = p.Sale_Date,
            //        Type = "Out",
            //        Amount = p.amount
            //    }).ToList();
            //    var transactions = pur.Union(sel).OrderBy(t => t.date) .ToList<dynamic>();
            //    var stocks = _context.products.Select(p => new
            //    {
            //        productid = p.ProductId,
            //        productname = p.ProductName
            //    }).ToList();
            //    var stocks1 = _context.stocks.Select(s => new
            //    {
            //        productid = s.ProductId,
            //        quantity = s.Quantity
            //    }).ToList();
            //    var final = (from transaction in transactions
            //                 join product in stocks on transaction.productid equals product.productid
            //                 join stock in stocks1 on transaction.productid equals stock.productid
            //                 select new
            //                 {
            //                     productname = product.productname,
            //                     Type = transaction.Type,
            //                     date = transaction.date,
            //                     amount = transaction.Amount,
            //                     Current_stock = stock.quantity
            //                 }).OrderByDescending(t => t.date).ToList();
            //    var dynamicList = final.Cast<dynamic>().ToList();
            //    return dynamicList;
            //}
            var purchases = _context.Purchases.Select(p => new
            {
                productid = p.ProductId,
                date = p.PurchaseDate,
                Type = "In",
                Amount = p.Invoice_Amount,
                Quantity = p.quantity
            }).ToList();

            var sales = _context.Sales.Select(s => new
            {
                productid = s.ProductId,
                date = s.Sale_Date,
                Type = "Out",
                Amount = s.amount,
                Quantity = s.Quantity
            }).ToList();

            var transactions = purchases.Union(sales).OrderBy(t => t.date).ToList<dynamic>();

            var products = _context.products.Select(p => new
            {
                productid = p.ProductId,
                productname = p.ProductName
            }).ToList();

            var stocks = new Dictionary<int, int>();

            var final = new List<dynamic>();

            foreach (var transaction in transactions)
            {
                var product = products.FirstOrDefault(p => p.productid == transaction.productid);

                if (!stocks.ContainsKey(transaction.productid))
                {
                    stocks[transaction.productid] = 0;
                }

                var beforeStock = stocks[transaction.productid];

                if (transaction.Type == "In")
                {
                    stocks[transaction.productid] += transaction.Quantity;
                }
                else if (transaction.Type == "Out")
                {
                    stocks[transaction.productid] -= transaction.Quantity;
                }

                var afterStock = stocks[transaction.productid];

                final.Add(new
                {
                    productname = product?.productname,
                    Type = transaction.Type,
                    date = transaction.date,
                    amount = transaction.Amount,
                    before_stock = beforeStock,
                    after_stock = afterStock,
                    quantity = transaction.Quantity
                });
            }

            return final.OrderByDescending(t => t.date).Cast<dynamic>().ToList();
        }



        public IQueryable<review_inventoryDto> Review_inventory()
        {
            var res1 = (from p in _context.stocks
                        join q in _context.products on p.ProductId equals q.ProductId
                        select new review_inventoryDto
                        {
                            ProductId = q.ProductId,
                            ProductName = q.ProductName,
                            quantity = p.Quantity,
                            minquantity = p.min_Quantity,
                            maxquantity = p.max_Quantity
                        });

            return res1;
        }

       public bool UpdatePriceById(int product_id, float new_price)
        {
            var res_product = _context.products.FirstOrDefault(r => r.ProductId == product_id);
            if (res_product == null)
            {
                return false;
            }
            res_product.price = new_price;
            _context.SaveChanges();
            return true;
        }
        public async Task<int?> GetStockByProductIdAsync(int productId)
        {
            var stock = await _context.stocks.FirstOrDefaultAsync(s => s.ProductId == productId);
            return stock?.Quantity;
        }
        public List<dynamic> GetAllPurchaseHistory()
        {
            var purchases = _context.Purchases.Select(p => new
            {
                productid = p.ProductId,
                date = p.PurchaseDate,
                Type = "In",
                quantity = p.quantity,
                Amount = p.Invoice_Amount,
                SupplierName = p.Supplier_Name
            }).ToList();

            var stocks = _context.products.Select(p => new
            {
                productid = p.ProductId,
                productname = p.ProductName
            }).ToList();

            var final = (from item1 in purchases
                         join item2 in stocks on item1.productid equals item2.productid
                         select new
                         {
                             productName = item2.productname,
                             type = item1.Type,
                             date = item1.date,
                             amount = item1.Amount,
                             supplierName = item1.SupplierName,
                             quantity = item1.quantity
                         }).OrderByDescending(t => t.date).ToList();

            var dynamicList = final.Cast<dynamic>().ToList();
            return dynamicList;
        }



        public List<dynamic> GetAllSalesHistory()
        {
            var sales = _context.Sales.Select(s => new
            {
                productid = s.ProductId,
                date = s.Sale_Date,
                Type = "Out",
                Quantity = s.Quantity,
                Amount = s.amount,
                CustomerName = s.Customer_name

            }).ToList();

            var stocks = _context.products.Select(p => new
            {
                productid = p.ProductId,
                productname = p.ProductName
            }).ToList();

            var final = (from item1 in sales
                         join item2 in stocks on item1.productid equals item2.productid
                         select new
                         {
                             productName = item2.productname,
                             Type = item1.Type,
                             date = item1.date,
                             amount = item1.Amount,
                             customerName = item1.CustomerName,
                             quantity = item1.Quantity
                         }).OrderByDescending(t => t.date).ToList();

            var dynamicList = final.Cast<dynamic>().ToList();
            return dynamicList;
        }

        public List<item_quantityDTO> GetProductsBelowMinQuantity()
        {
            return (from p in _context.stocks
                    join q in _context.products on p.ProductId equals q.ProductId
                    where p.Quantity < p.min_Quantity
                    select new item_quantityDTO
                    {
                        ProductId = q.ProductId,
                        productName = q.ProductName,
                        Quantity=p.Quantity,
                        Last_modified = p.Last_modified,
                        minquantity = p.min_Quantity,
                        maxquantity = p.max_Quantity
                    }).ToList();
        }

        public List<item_quantityDTO> GetProductsAboveMaxQuantity()
        {
            return (from p in _context.stocks
                    join q in _context.products on p.ProductId equals q.ProductId
                    where p.Quantity > p.max_Quantity
                    select new item_quantityDTO
                    {
                        ProductId = q.ProductId,
                        productName = q.ProductName,
                        Quantity = p.Quantity,
                        Last_modified = p.Last_modified,
                        minquantity = p.min_Quantity,
                        maxquantity = p.max_Quantity
                    }).ToList();
        }
        public List<dynamic> GetAllSuppliers()
        {
            return _context.Suppliers.Select(s => new
            {
                id=s.SupplierId,
                SupplierName = s.Name,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email
            }).ToList<dynamic>();
        }

        public List<dynamic> GetAllCustomers()
        {
            return _context.Customers.Select(c => new
            {
                id=c.CustomerId,
                CustomerName = c.Name,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email
            }).ToList<dynamic>();
        }
        public async Task<bool> AddSupplierAsync(SupplierDto supplier)
        {
            var newSupplier = new Supplier
            {
                Name = supplier.Name,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email
            };

            _context.Suppliers.Add(newSupplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddCustomerAsync(CustomerDto customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateSupplierAsync(int supplierId, SupplierDto supplier)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(supplierId);
            if (existingSupplier == null)
            {
                return false;
            }

            existingSupplier.Name = supplier.Name;
            existingSupplier.PhoneNumber = supplier.PhoneNumber;
            existingSupplier.Email = supplier.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCustomerAsync(int customerId, CustomerDto customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer == null)
            {
                return false;
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Email = customer.Email;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<ProductTransactionDto> GetProductWiseTransactions(int productId)
        {
            var transactions = _context.Purchases
                .Where(p => p.ProductId == productId)
                .Select(p => new ProductTransactionDto
                {
                    ProductId = p.ProductId,
                    ProductName = _context.products.FirstOrDefault(pr => pr.ProductId == p.ProductId).ProductName,
                    Date = p.PurchaseDate,
                    Type = "In",
                    Quantity = p.quantity,
                    Amount = p.Invoice_Amount
                })
                .Union(_context.Sales
                    .Where(s => s.ProductId == productId)
                    .Select(s => new ProductTransactionDto
                    {
                        ProductId = s.ProductId,
                        ProductName = _context.products.FirstOrDefault(pr => pr.ProductId == s.ProductId).ProductName,
                        Date = s.Sale_Date,
                        Type = "Out",
                        Quantity = s.Quantity,
                        Amount = s.amount
                    }))
                .OrderBy(t => t.Date)
                .ToList();

            return transactions;
        }

        public List<PurchaseReportDto> GetPurchaseReport(DateTime startDate, DateTime endDate, string period)
        {
            var purchases = _context.Purchases
                .Where(p => p.PurchaseDate >= startDate && p.PurchaseDate <= endDate)
                .GroupBy(p => new
                {
                    p.ProductId,
                    Date = period == "daily" ? p.PurchaseDate.Date : new DateTime(p.PurchaseDate.Year, p.PurchaseDate.Month, 1),
                    p.Supplier_Name ,
                    // Include Supplier_Name in the grouping
                })
                .Select(g => new PurchaseReportDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = _context.products.FirstOrDefault(pr => pr.ProductId == g.Key.ProductId).ProductName,
                    SupplierName = g.Key.Supplier_Name, // Use the grouped Supplier_Name
                    Date = g.Key.Date,
                    type="In",
                    Quantity = g.Sum(p => p.quantity),
                    amount = g.Sum(p => p.Invoice_Amount)
                })
                .OrderBy(r => r.Date)
                .ToList();

            return purchases;
        }
        public List<SalesReportDto> GetSalesReport(DateTime startDate, DateTime endDate, string period)
        {
            var sales = _context.Sales
                .Where(s => s.Sale_Date >= startDate && s.Sale_Date <= endDate)
                .GroupBy(s => new
                {
                    s.ProductId,
                    Date = period == "daily" ? s.Sale_Date.Date : new DateTime(s.Sale_Date.Year, s.Sale_Date.Month, 1),
                    s.Customer_name
                })
                .Select(g => new SalesReportDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = _context.products.FirstOrDefault(p => p.ProductId == g.Key.ProductId).ProductName,
                    CustomerName = g.Key.Customer_name,
                    Date = g.Key.Date,
                    type="Out",
                    Quantity = g.Sum(s => s.Quantity),
                    amount = g.Sum(s => s.amount)
                })
                .OrderBy(r => r.Date)
                .ToList();

            return sales;

        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Get Category by ID
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.categories.FindAsync(id);
        }

        // Get All Categories
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.categories.ToListAsync();
        }

        // Update Category
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Delete Category
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

    }


}
    
       



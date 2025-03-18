using Microsoft.AspNetCore.Mvc;
using project_demo.Model;
using project_demo.Model.DTO;

namespace project_demo.Repository
{
    public interface Imainrepository
    {
        Purchase Newpurchaseasync(int user_id, int productid, int Quantity, string suppliername);
        Product NewProduct(string ProductName, string product_detail, string category_Name, int category_id, string Category_Name, int amount);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);

        string NewSaleAsync(int customer_id, string customername, int productid, int quantity);
        IQueryable<review_inventoryDto> Review_inventory();
        List<dynamic> UserTransaction();
        bool UpdatePriceById(int product_id, float new_price);
        Task<bool> SetMinQuantityAsync(string productName, int minQuantity);
        Task<bool> SetMaxQuantityAsync(string productName, int maxQuantity);
        //List<item_quantityDTO> Min_Quantity();
        //List<item_quantityDTO> Max_Quantity();
        Task<int?> GetStockByProductIdAsync(int productId);
        List<dynamic> GetAllPurchaseHistory(); // Add this line
        List<dynamic> GetAllSalesHistory();
        List<item_quantityDTO> GetProductsBelowMinQuantity(); // Add this line
        List<item_quantityDTO> GetProductsAboveMaxQuantity(); // Add this line
        List<dynamic> GetAllSuppliers();
        List<dynamic> GetAllCustomers();
        Task<bool> AddSupplierAsync(SupplierDto supplier);
        Task<bool> AddCustomerAsync(CustomerDto customer);
        Task<bool> UpdateSupplierAsync(int supplierId, SupplierDto supplier);
        Task<bool> UpdateCustomerAsync(int customerId, CustomerDto customer);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<bool> DeleteSupplierAsync(int supplierId);
        Task<IEnumerable<Product>> GetOutOfStockProductsAsync();
        List<ProductTransactionDto> GetProductWiseTransactions(int productId);
        List<PurchaseReportDto> GetPurchaseReport(DateTime startDate, DateTime endDate, string period);
        List<SalesReportDto> GetSalesReport(DateTime startDate, DateTime endDate, string period);
    }
        
}

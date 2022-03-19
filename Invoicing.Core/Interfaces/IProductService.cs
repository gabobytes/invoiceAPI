using Invoicing.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IProductService
    {
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(Product product);
    }
}
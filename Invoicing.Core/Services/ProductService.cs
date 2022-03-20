using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Services
{
    public class ProductService :  IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task InsertProduct(Product product)
        {   
             await _unitOfWork.ProductRepository.Add(product);
             await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
             _unitOfWork.ProductRepository.Update(product);
             await _unitOfWork.SaveChangesAsync();
             return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

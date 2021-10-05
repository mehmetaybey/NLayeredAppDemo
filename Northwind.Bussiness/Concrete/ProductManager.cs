using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.Utilities;
using Northwind.Bussiness.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFrameWork;
using Northwind.Entities.Concrete;

namespace Northwind.Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
          
            return _productDal.GetAll();
        }

        List<Product> IProductService.GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Add(Product product)
        {
           ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);

        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);

            }
            catch (DbUpdateException e )
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
      
    
    }
}

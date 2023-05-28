using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult<Product> GetById(int id);
        IResult<List<Product>> GetAll();
        IResult<ProductModel> Add(ProductModel entity);
        IResult<Product> Delete(int id);
        IResult<Product> Update(Product entity);
    }
}

using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public IResult<ProductModel> Add(ProductModel entity)
        {
            var result = Valid(entity);
            if (result == null)
            {
                var mapped = _mapper.Map<Product>(entity);
                _productDal.Add(mapped);
                return new Result<ProductModel>("ekleme başarılı.");
            }
            return new Result<ProductModel>(result, false);
        }

        public IResult<Product> Delete(int id)
        {
            _productDal.Delete(id);
            return new Result<Product>("silme işlemi başarılı.");
        }

        public IResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new Result<List<Product>>(result);
        }

        public IResult<Product> GetById(int id)
        {
            var result = _productDal.Get(x => x.Id == id);
            return new Result<Product>(result);
        }

        public IResult<Product> Update(Product entity)
        {
            var mapped = _mapper.Map<ProductModel>(entity);
            var result = Valid(mapped);
            if (result == null)
            {
                _productDal.Update(entity);
                return new Result<Product>("güncelleme başarılı.");
            }
            return new Result<Product>(result, false);
        }
        public string Valid(ProductModel productModel)
        {
            ProductModelValidator validator = new ProductModelValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(productModel);
            if (!result.IsValid)
            {
                return result.Errors[0].ErrorMessage;
            }
            return null;

        }
    }
}

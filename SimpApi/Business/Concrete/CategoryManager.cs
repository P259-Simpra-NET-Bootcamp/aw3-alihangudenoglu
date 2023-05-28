using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public IResult<CategoryModel> Add(CategoryModel entity)
        {
            var result = Valid(entity);
            if (result == null)
            {
                var mapped = _mapper.Map<Category>(entity);
                _categoryDal.Add(mapped);
                return new Result<CategoryModel>("ekleme başarılı.");
            }
            return new Result<CategoryModel>(result, false);
        }

        public IResult<Category> Delete(int id)
        {
            _categoryDal.Delete(id);
            return new Result<Category>("silme işlemi başarılı.");
        }

        public IResult<List<CategoryModel>> GetAll()
        {
            var result = _categoryDal.GetAll();
            var mapped = _mapper.Map<List<CategoryModel>>(result);
            return new Result<List<CategoryModel>>(mapped);
        }

        public IResult<List<Category>> GetAllCategoryWithProduct()
        {
            var result = _categoryDal.GetAllCategoryWithProduct();
            return new Result<List<Category>>(result);
        }

        public IResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(x=>x.Id==id);
            return new Result<Category>(result);
        }

        public IResult<Category> Update(Category entity)
        {
            var mapped = _mapper.Map<CategoryModel>(entity);
            var result = Valid(mapped);
            if (result == null)
            {
                _categoryDal.Update(entity);
                return new Result<Category>("güncelleme başarılı.");
            }
            return new Result<Category>(result, false);
        }
        public string Valid(CategoryModel categoryModel)
        {
            CategoryModelValidator validator = new CategoryModelValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(categoryModel);
            if (!result.IsValid)
            {
                return result.Errors[0].ErrorMessage;
            }
            return null;

        }
    }
}

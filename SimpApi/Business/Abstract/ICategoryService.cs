using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult<Category> GetById(int id);
        IResult<List<CategoryModel>> GetAll();
        IResult<List<Category>> GetAllCategoryWithProduct();
        IResult<CategoryModel> Add(CategoryModel entity);
        IResult<Category> Delete(int id);
        IResult<Category> Update(Category entity);
    }
}

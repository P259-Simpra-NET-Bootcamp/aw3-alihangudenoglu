using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        public List<Category> GetAllCategoryWithProduct(Expression<Func<Category, bool>> filter = null);
    }
}

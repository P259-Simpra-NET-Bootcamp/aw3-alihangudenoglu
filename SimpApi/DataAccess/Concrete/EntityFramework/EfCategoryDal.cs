using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, MsSqlContext>, ICategoryDal
    {      

       public List<Category> GetAllCategoryWithProduct(Expression<Func<Category, bool>> filter = null)
        {
            using (MsSqlContext context=new MsSqlContext())
            {
                var result=context.Categorys.Include(i=>i.Products);
                return filter==null?result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

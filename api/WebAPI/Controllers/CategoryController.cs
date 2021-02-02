using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        CategoryDAL categoryDAL = new CategoryDAL();
        public IEnumerable<Category> Get()
        {
            return categoryDAL.GetAll();
        }

        public Category Get(int id)
        {
            return categoryDAL.GetCategoryById(id);
        }

        public Category Post(Category Category)
        {
            return categoryDAL.Create(Category);
        }

        public Category Put(int id, Category Category)
        {
            return categoryDAL.Update(id, Category);
        }

        public void Delete(int id)
        {
            categoryDAL.Delete(id);
        }
    }
}

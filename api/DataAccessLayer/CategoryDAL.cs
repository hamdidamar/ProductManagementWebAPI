using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAL
    {
        DBEntities db = new DBEntities();

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }

        public Category GetCategoryById(int id)
        {
            return db.Category.Find(id);
        }



        public Category Create(Category category)
        {

            db.Category.Add(category);
            db.SaveChanges();
            return category;

        }
        public Category Update(int id, Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            db.Category.Remove(db.Category.Find(id));
            db.SaveChanges();

        }
    }
}

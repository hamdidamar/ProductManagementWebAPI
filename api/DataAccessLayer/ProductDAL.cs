using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL
    {
        DBEntities db = new DBEntities();

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

        public Product GetProductById(int id)
        {
            return db.Product.Find(id);
        }



        public Product Create(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return product;

        }
        public Product Update(int id, Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            db.Product.Remove(db.Product.Find(id));
            db.SaveChanges();

        }


    }
}

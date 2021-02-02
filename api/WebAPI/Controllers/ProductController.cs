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
    public class ProductController : ApiController
    {
        ProductDAL productDAL = new ProductDAL();

        public HttpResponseMessage Get()
        {
            var products = productDAL.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        public HttpResponseMessage Get(int id)
        {
            var product = productDAL.GetProductById(id);
            if (product==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        public HttpResponseMessage Post(Product product)
        {
            if (ModelState.IsValid)
            {
                var createdValue = productDAL.Create(product);
                return Request.CreateResponse(HttpStatusCode.Created, createdValue);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
        }

        public HttpResponseMessage Put(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var updatedValue = productDAL.Update(id, product);
                return Request.CreateResponse(HttpStatusCode.OK, updatedValue);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public void Delete(int id)
        {
            productDAL.Delete(id);
        }
    }
}

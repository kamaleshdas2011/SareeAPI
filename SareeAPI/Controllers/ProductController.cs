using DataModel;
using SareeAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SareeAPI.Controllers
{
    public class ProductController : ApiController
    {
        ImageStore _store = new ImageStore();
        public IHttpActionResult Get()
        {
            DatabaseContext db = new DatabaseContext();
            var prods = db.Products.ToList();
            //_store.GetImages();
            return Ok(prods);

        }
        public Product Get(int sku)
        {
            DatabaseContext db = new DatabaseContext();
            var prod = (from p in db.Products where p.id == sku select p).FirstOrDefault();
            return prod;
            //if (prod != null)
            //{
            //    return Ok(prod);
            //}
            //else
            //{
            //    return NotFound();
            //}

        }
    }
}

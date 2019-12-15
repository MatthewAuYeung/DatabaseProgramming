using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GameBackend.Controllers
{
    public class ProductController : ApiController
    {
        IList<Product> products = new List<Product>
            {
                new Product
                {
                    idproduct = 1,
                    productName = "Biscuits",
                    manufacturingYear = 2018,
                    brandName="ParleG"
                },
                new Product
                {
                    idproduct = 2,
                    productName = "Cars",
                    manufacturingYear = 2018,
                    brandName="BMW"
                },
                new Product
                {
                    idproduct = 3,
                    productName = "Cars",
                    manufacturingYear = 2018,
                    brandName="Mercedese"
                },
                new Product
                {
                    idproduct = 4,
                    productName = "Brush",
                    manufacturingYear = 2017,
                    brandName="Colgate"
                }

            };


        public IEnumerable<Product> GetProducts()
        { 
            return products;
        }

        public IHttpActionResult PostNewProduct(Product product)
        {
            this.products.Add(product);
            Console.WriteLine(products);
              
            return Ok(products);
        }

        public IHttpActionResult GetProductById(int idproduct)
        {
            foreach (var product in products)
            {
                if (product.idproduct == idproduct)
                {
                    return Ok(product);
                }
            }

            return NotFound();
        }

        public IHttpActionResult DeleteProduct(int idproduct)
        {
            foreach (var product in products)
            {
                if (product.idproduct == idproduct)
                {
                    products.Remove(product);
                    return Ok(products);
                }
            }

            return NotFound();
        }

        public IHttpActionResult PutProduct(Product _product)
        {
            foreach (var product in products)
            {
                if (product.idproduct == _product.idproduct)
                {
                    products.Remove(product);
                    products.Add(_product);
                    return Ok(products);
                }
            }

            return NotFound();
        }
    }
}

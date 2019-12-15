using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GameBackend.Controllers
{
    public class SQLPlayerDataController : ApiController
    {
        IList<PlayerData> products = new List<PlayerData>
            {
                new PlayerData
                {
                },
            };


        public IEnumerable<PlayerData> GetSQLPlayerData()
        { 
            return products;
        }

        public IHttpActionResult PostNewSQLPlayerData(PlayerData product)
        {
            this.products.Add(product);
            Console.WriteLine(products);
              
            return Ok(products);
        }

        public IHttpActionResult GetSQLPlayerDataById(int idproduct)
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

        public IHttpActionResult DeleteSQLPlayerData(int idproduct)
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

        public IHttpActionResult PutSQLPlayerData(PlayerData _product)
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

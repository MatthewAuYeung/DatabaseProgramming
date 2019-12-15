using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GameBackend.Controllers
{
    public class NoSQLMatchDataController : ApiController
    {
        IList<PlayerData> products = new List<PlayerData>
            {
                new PlayerData
                {
                },
                new PlayerData
                {
                },
                new PlayerData
                {
                },
                new PlayerData
                {
                }

            };


        public IEnumerable<PlayerData> GetNoSQLMatchData()
        { 
            return products;
        }

        public IHttpActionResult PostNewNoSQLMatchData(MatchData product)
        {
            this.products.Add(product);
            Console.WriteLine(products);
              
            return Ok(products);
        }

        public IHttpActionResult GetNoSQLMatchDataById(int idproduct)
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

        public IHttpActionResult DeleteNoSQLMatchData(int idproduct)
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

        public IHttpActionResult PutNoSQLMatchData(MatchData _product)
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

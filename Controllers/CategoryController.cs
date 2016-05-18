using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Community2.Controllers
{
    public class CategoryController : ApiController
    {
        Database1Entities7 db = new Database1Entities7();

        public object  GetCategories()
        {
            return db.categories;

            //object cat = db.categories.Select(x => new
            //    {
            //        x.Id,
            //        x.name,
            //        services = x.services.Select(y => new {
            //            y.Id,
            //            y.no_of_workers,
            //            y.description,
            //            y.cid,
            //            y.service_type,
            //            worker_Portfolio = y.worker_Portfolio.Select(z => new{
            //                z.Id,
            //                z.name,
            //                z.cnic,
            //                z.contact1,
            //                z.address,
            //                z.experience_,
            //                z.contact2,
            //                z.sid
            //        })
            //        })
            //    });

            //return cat;
        }
            public object getServices()
            {
                return db.services;
            }

        
    }
}

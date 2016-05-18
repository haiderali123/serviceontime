using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Community2.Controllers
{
    public class ServiceController : ApiController
    {
        Database1Entities7 db = new Database1Entities7();

        public object GetServices()
        {
            return db.services;
        }

    }
}

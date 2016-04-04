using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eObchod.Server.API.Controllers
{
    [Route("api/Sample")]
    public class SampleController : ApiController
    {
        [HttpGet]
        public object GetSample()
        {
            return @"Hello world! To jest jakaś porażka!";
        }
    }
}

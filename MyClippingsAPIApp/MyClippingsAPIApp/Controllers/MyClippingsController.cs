using KindleClippings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyClippingsAPIApp.Controllers
{
    public class MyClippingsController : ApiController
    {
        [Route("GetAllFromFile")]
        [HttpGet]
        public IEnumerable<Clipping> GetAllFromFile(string filename)
        {
            var clippings = MyClippingsParser.Parse(filename);

            return clippings;
        }
    }
}

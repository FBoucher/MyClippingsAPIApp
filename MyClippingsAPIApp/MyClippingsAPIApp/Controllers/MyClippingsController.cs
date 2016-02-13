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
        [Route("AllKindleClippings")]
        [HttpGet]
        public IEnumerable<Clipping> AllKindleClippings(string filename)
        {
            var clippings = MyClippingsParser.Parse(filename);

            return clippings;
        }

        [Route("KindleClippingsAfter")]
        [HttpGet]
        public IEnumerable<Clipping> KindleClippingsAfter(string filename, string StartDate)
        {
            var clippings = KindleClippings.MyClippingsParser.Parse(filename);

            var result = from c in clippings
                         where c.DateAdded >= DateTime.Parse(StartDate)
                         select c as KindleClippings.Clipping;

            return result;
        }

    }
}

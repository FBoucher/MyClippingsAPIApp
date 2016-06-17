using KindleClippings;
using MyClippingsAPIApp.Helpers;
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
        public IEnumerable<Clipping> KindleClippingsAfter(string containername, string filename, string StartDate)
        {
            var blobStream = StorageHelper.GetStreamFromStorage(containername, filename);

            var clippings = KindleClippings.MyClippingsParser.Parse(blobStream);

            var result = from c in clippings
                         where c.DateAdded >= DateTime.Parse(StartDate)
                         select c as KindleClippings.Clipping;

            return result;
        }



        [Route("ArrayKindleClippingsAfter")]
        [HttpGet]
        public Clipping[] ArrayKindleClippingsAfter(string containername, string filename, string StartDate)
        {
            var blobStream = StorageHelper.GetStreamFromStorage(containername, filename);

            var clippings = KindleClippings.MyClippingsParser.Parse(blobStream);

            var result = (from c in clippings
                          where c.DateAdded >= DateTime.Parse(StartDate)
                          && c.ClippingType == ClippingTypeEnum.Note
                          select c as KindleClippings.Clipping).ToArray<Clipping>();

            return result;
        }
    }
}

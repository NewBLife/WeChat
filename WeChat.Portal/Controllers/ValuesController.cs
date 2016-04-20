using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Aurore.Framework.Core;
using WeChat.Data.Entitys;
using WeChat.Services.Interfaces;

namespace WeChat.Portal.Controllers
{
    public class ValuesController : ApiController
    {


        // GET api/values
        public IEnumerable<string> Get()
        {

            return new[] { "Value1", "Value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

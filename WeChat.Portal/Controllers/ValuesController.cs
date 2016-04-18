using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Aurore.Framework.Core;

namespace WeChat.Portal.Controllers
{
    public class ValuesController : ApiController
    {
        //private readonly ILogger _logger;

        //public ValuesController(ILogger logger)
        //{
        //    _logger = logger;
        //}
        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new WebException("ex");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
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

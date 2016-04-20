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
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values
        public UserEntity Get(string id = "")
        {
            var userEntity = _userService.GetUsers(id);
            return userEntity;
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

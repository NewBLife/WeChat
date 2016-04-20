using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeChat.Data.Entitys;
using WeChat.Services.Interfaces;

namespace WeChat.Portal.Controllers
{

    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public UserEntity Get(string id = null)
        {
            return _userService.GetUsers(id);
        }

        [AcceptVerbs("Detail")]
        public UserDetailEntity GetUser(string id)
        {
            return _userService.GetUser(id);
        }
    }
}

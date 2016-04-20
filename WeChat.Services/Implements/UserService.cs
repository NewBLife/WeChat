using Aurore.Framework.Core.Caching;
using Aurore.Framework.Web.Utils.HttpUtility;
using WeChat.Data.Constants;
using WeChat.Data.Entitys;
using WeChat.Services.Interfaces;

namespace WeChat.Services.Implements
{
    public class UserService: BaseService,IUserService
    {
        public UserService(ICacheManager cacheManager) : base(cacheManager)
        {
        }
        public string AddUser()
        {
            throw new System.NotImplementedException();
        }

        public UserEntity GetUsers(string nextOpenid)
        {
            var url = RequestUrl.GetUsers(this.Token,nextOpenid);
           return GetJson<UserEntity>(url);
        }

      
    }
}
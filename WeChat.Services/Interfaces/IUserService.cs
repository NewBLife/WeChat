using WeChat.Data.Entitys;

namespace WeChat.Services.Interfaces
{
    public interface IUserService
    {
        string AddUser();


        UserDetailEntity GetUser(string openId);

        UserEntity GetUsers(string nextOpenid);
    }
}

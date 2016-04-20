using WeChat.Data.Entitys;

namespace WeChat.Services.Interfaces
{
    public interface IUserService
    {
        string AddUser();

        UserEntity GetUsers(string nextOpenid);
    }
}

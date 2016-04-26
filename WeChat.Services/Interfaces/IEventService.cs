using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;

namespace WeChat.Services.Interfaces
{
    public interface IEventService
    {
        BaseMessage ClickEvent(RequestEvent request);
    }
}
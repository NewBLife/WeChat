using System.Xml;
using WeChat.Core.XmlModels;

namespace WeChat.Services.Interfaces
{
    public interface IWeChatService
    {
        BaseMessage Execute(XmlDocument document);
    }
}
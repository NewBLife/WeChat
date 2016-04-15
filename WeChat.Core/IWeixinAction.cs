using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;

namespace WeChat.Core
{
    /// <summary>
    /// 客户端请求的数据接口
    /// </summary>
    public interface IWeixinAction
    {
       
        BaseMessage HandleText(RequestText info);
        BaseMessage HandleImage(RequestImage info);
        BaseMessage HandleVoice(RequestVoice info);
        BaseMessage HandleVideo(RequestVideo info);
        BaseMessage HandleShortVideo(RequestVideo info);
        BaseMessage HandleLocation(RequestLocation info);
        BaseMessage HandleLink(RequestLink info);
        BaseMessage HandleEventClick(RequestEvent info);

    }
}
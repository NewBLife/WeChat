using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;
using WeChat.Core.XmlModels.Response;

namespace WeChat.Core
{
    /// <summary>
    /// 客户端请求的数据接口
    /// </summary>
    public interface IWeixinAction
    {
        /// <summary>
        /// 对文本请求信息进行处理
        /// </summary>
        /// <param name="info">文本信息实体</param>
        /// <returns></returns>
        BaseMessage HandleText(RequestText info);

        /// <summary>
        /// 对图片请求信息进行处理
        /// </summary>
        /// <param name="info">图片信息实体</param>
        /// <returns></returns>
        BaseMessage HandleImage(RequestImage info);

        BaseMessage HandleVoice(RequestVoice info);

        ///// <summary>
        ///// 对订阅请求事件进行处理
        ///// </summary>
        ///// <param name="info">订阅请求事件信息实体</param>
        ///// <returns></returns>
        //BaseMessage HandleEventSubscribe(RequestEventSubscribe info);

        ///// <summary>
        ///// 对菜单单击请求事件进行处理
        ///// </summary>
        ///// <param name="info">菜单单击请求事件信息实体</param>
        ///// <returns></returns>
        //BaseMessage HandleEventClick(RequestEventClick info);

    }
}
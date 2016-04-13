using WeChat.Core.Constants;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;

namespace WeChat.Core
{
    public class WeixinApiDispatch
    {
        private IWeixinAction _weixinAction;

        public WeixinApiDispatch(IWeixinAction weixinAction)
        {
            _weixinAction = weixinAction;
        }
        public WeixinApiDispatch()
        {
          _weixinAction = new WeixinAction();
        }
        public BaseMessage Execute(string postStr)
        {
            var requestObj = XmlHelper.Instance().Deserializer<BaseMessage>(postStr);
            var response = new BaseMessage();
            switch (requestObj.MsgType)
            {
                case MsgType.Text:
                    RequestText textObj = XmlHelper.Instance().Deserializer<RequestText>(postStr);
                    response=_weixinAction.HandleText(textObj);
                    break;
                case MsgType.Image:
                    RequestImage imageObj = XmlHelper.Instance().Deserializer<RequestImage>(postStr);
                    response = _weixinAction.HandleImage(imageObj);
                    break;
            }
            return response;
        }
    }
}
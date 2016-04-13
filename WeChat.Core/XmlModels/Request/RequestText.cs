using System.Xml.Serialization;

namespace WeChat.Core.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestText: RequestBaseMessage
    {
         public string Content { get; set; }
    }
}
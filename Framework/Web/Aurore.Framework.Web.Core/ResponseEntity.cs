using System.Xml.Serialization;

namespace Aurore.Framework.Web.Core
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseEntity<T>
    {

        public bool Success { get; set; }
        public string ErrorCode { get; set; }

        public string ErrorMsg { get; set; }

        public T Data { get; set; }
    }
}
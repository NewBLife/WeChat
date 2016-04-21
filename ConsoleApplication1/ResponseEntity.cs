using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "root")]
    public class ResponseEntity<T>
    {
        public string ErrorCode { get; set; }


        public object Obj { get; set; }

        public string ErrorMsg { get; set; }

        public T Data { get; set; }
    }
}
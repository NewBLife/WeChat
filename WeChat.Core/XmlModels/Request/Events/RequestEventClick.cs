using System.Xml.Serialization;

namespace WeChat.Core.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestEventClick : BaseEvent
    {
        public string EventKey { get; set; }
    }

    [XmlRoot(ElementName = "xml")]
    public class RequestEventLocation : BaseEvent
    {       
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Precision { get; set; }
    }
    [XmlRoot(ElementName = "xml")]
    public class RequestEventView : BaseEvent
    {
        public string EventKey { get; set; }
    }
    [XmlRoot(ElementName = "xml")]
    public class RequestEventScan : BaseEvent
    {
        public string EventKey { get; set; }

        public long Ticket { get; set; }
    }


    [XmlRoot(ElementName = "xml")]
    public class RequestEventUnsubscribe : BaseEvent
    {
    }

}
using System.Xml;
using System.Xml.Serialization;

namespace WeChat.Core.Entitys
{
    public class VoiceEntity
    {
        [XmlElement("MediaId")]
        public XmlCDataSection XmlMediaId
        {
            get { return new XmlDataDocument().CreateCDataSection(MediaId); }
            set { MediaId = value.Value; }
        }

        [XmlIgnore]
        public string MediaId { get; set; }
     
    }
}
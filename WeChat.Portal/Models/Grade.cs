using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "GradeRoot")]
    public class Grade
    {
        public string GradeName { get; set; }
        public int Id { get; set; }
        [XmlArrayItem(ElementName = "StudentItem")]
        [XmlElement(ElementName = "ElementName")]
        public List<Student> Students { get; set; }
    }
}
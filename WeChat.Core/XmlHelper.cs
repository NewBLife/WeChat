using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WeChat.Utils;

namespace WeChat.Core
{

    /// <summary>
    /// Xml的操作公共类
    /// </summary>    
    public static class XmlHelper
    {


        public static string Serializer<T>(this T obj)
        {
            string xmlString;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //Add an empty namespace and empty value
            ns.Add("", "");
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlserializer.Serialize(ms, obj, ns);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xmlString;
        }

        public static T Deserializer<T>(this string xmlString)
        {


            T t = default(T);
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (Stream xmlstream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                using (XmlReader xmlreader = XmlReader.Create(xmlstream))
                {
                    object obj = xmlserializer.Deserialize(xmlreader);
                    t = (T)obj;
                }
            }
            return t;
        }
        public static T Deserializer<T>(this XmlDocument xmlDoc)
        {


            T t = default(T);
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (Stream xmlstream = new MemoryStream(Encoding.UTF8.GetBytes(xmlDoc.ConvertToString())))
            {
                using (XmlReader xmlreader = XmlReader.Create(xmlstream))
                {
                    object obj = xmlserializer.Deserialize(xmlreader);
                    t = (T)obj;
                }
            }
            return t;
        }

        public static string ConvertToString(this XmlDocument xmlDoc)
        {

            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
    }
}
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
    public class XmlHelper
    {
        private static XmlHelper _xmlHelper;
        #region 字段定义
      
        #endregion

        #region 构造方法
      
        private XmlHelper()
        {
           
        }
        public static XmlHelper Instance()
        {
            return _xmlHelper ?? (_xmlHelper = new XmlHelper());
        }

        #endregion

        public string Serializer<T>(T obj)
        {
            string xmlString;
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlserializer.Serialize(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xmlString;
        }

        public T Deserializer<T>(string xmlString)
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
    }
}
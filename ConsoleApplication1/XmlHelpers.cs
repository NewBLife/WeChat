using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public static class XmlHelpers
    {
        private static readonly Type[] WriteTypes =
        {
            typeof (string),
            typeof (Enum),
            typeof (DateTime),
            typeof (DateTime?),
            typeof (DateTimeOffset),
            typeof (DateTimeOffset?),
            typeof (int),
            typeof (int?),
            typeof (decimal),
            typeof (decimal?),
            typeof (Guid),
            typeof (Guid?)
        };

        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || WriteTypes.Contains(type);
        }

        public static object ToXml(this object input, bool allowNull = false)
        {
            return input.ToXml(allowNull, "xml");
        }

        public static object ToXml(this object input, bool allowNull, string elementName, string childName="item")
        {

            elementName = XmlConvert.EncodeName(elementName);
            if (input != null)
            {
                var type = input.GetType();
                elementName = type.GetTypeName(elementName);
                if (input is IEnumerable && !type.IsSimpleType())
                {
                   object elements;
                    if (input is IEnumerable<object>)
                    {
                        elements = (input as IEnumerable<object>)
                            .Select(m => m.ToXml(allowNull, childName))
                            .ToArray();
                    }
                    else if (input is Array)
                    {
                        elements = (from object item in (input as Array) select CreateElement(item.GetType(), childName, item)).Cast<object>().ToList();

                        //elements = from prop in a
                        //let name = XmlConvert.EncodeName(childName)
                        //               let val = prop
                        //               let value = CreateElement(prop.GetType(), name, val)
                        //               where value != null
                        //               select value;
                        //elements = (input as Array)
                        //    .Select(m => m.ToXml(allowNull, childName))
                        //    .ToArray();
                    }
                    else
                    {
                        elements = null;
                    }


                    var root = new XElement(elementName);
                    root.Add(elements);
                    return root;
                }
                else
                {

                    //element = type.GetTypeName(type.Name);
                    var ret = new XElement(elementName);
                    var props = type.GetProperties();
                    var elements = from prop in props
                                   let name = XmlConvert.EncodeName(prop.Name)
                                   let val = prop.GetValue(input, null)
                                   let value = prop.PropertyType.IsSimpleType()
                                       ? CreateElement(prop.PropertyType, name, val)//new XElement(name, val)
                                       : val.ToXml(allowNull, prop.GetTypeName(name),prop.GetTypeItemName(name))
                                   where value != null
                                   select value;

                    ret.Add(elements);
                    return ret;
                }
            }
            else
            {
                if (allowNull)
                {
                    return new XElement(elementName); ;
                }
                else
                {
                    return null;
                }

            }



        }



        private static XElement CreateElement(Type type, string name, object value)
        {
            if (type == typeof(string))
            {
                XCData content = new XCData(value.ToString());
                return new XElement(name, content);
            }
            return new XElement(name, value);
        }


        private static string GetTypeItemName(this PropertyInfo type, string name)
        {
            var attributes = type.GetCustomAttributes<XmlArrayItemAttribute>();
            if (attributes == null) return name;
            var attribute = attributes.FirstOrDefault();
            if (attribute == null) return name;
            else
                return attribute.ElementName;
        }

        private static string GetTypeName(this PropertyInfo type, string name)
        {
            var attributes = type.GetCustomAttributes<XmlElementAttribute>();
            if (attributes == null) return name;
            var attribute = attributes.FirstOrDefault();
            if (attribute == null) return name;
            else
                return attribute.ElementName;
        }
        private static string GetTypeName(this Type type, string name)
        {
            var attributes = type.GetCustomAttributes<XmlRootAttribute>();
            if (attributes == null) return name;
            var attribute = attributes.FirstOrDefault();
            if (attribute == null) return name;
            else
                return attribute.ElementName;
        }
    }
}
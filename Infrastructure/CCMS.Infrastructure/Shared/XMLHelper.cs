using System.IO;
using System.Xml.Serialization;

namespace CCMS.Infrastructure.Shared
{
    public static class XMLHelper
    {
        public static T DeserializeFromXML<T>(string data)
        {
            var serializer = new XmlSerializer(typeof(T));
            T deserializedObject;
            using (TextReader xmlReader = new StringReader(data))
            {
                deserializedObject = (T)serializer.Deserialize(xmlReader);
            }
            return deserializedObject;
        }

        public static string ToXML<T>(this T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NKM.File.Definitions.Common.Stream;

namespace NKM.File.Common.Stream {
    public class BinarySerializerDeserializer : IBinarySerializerDeserializer {
        public System.IO.Stream Serialize<T>(T source) {
            IFormatter formatter = new BinaryFormatter();
            System.IO.Stream stream = new MemoryStream();
            formatter.Serialize(stream, source);
            return stream;
        }

        public T Deserialize<T>(System.IO.Stream stream) {
            IFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T) formatter.Deserialize(stream);
        }

        public T Clone<T>(T source) {
            return Deserialize<T>(Serialize(source));
        }
    }
}
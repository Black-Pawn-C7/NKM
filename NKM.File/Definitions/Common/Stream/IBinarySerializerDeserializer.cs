namespace NKM.File.Definitions.Common.Stream {
    public interface IBinarySerializerDeserializer {
        System.IO.Stream Serialize<T>(T source);

        T Deserialize<T>(System.IO.Stream stream);

        T Clone<T>(T source);
    }
}
using System;
using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Models.Lager;

namespace StukInformationSystem.Data.Common.Models.Lager {
    public class FirmenViewModel : IFirmenViewModel{
        [JsonProperty("FirmenID", Required = Required.Always)]
        public int ID { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("Straße", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Straße { get; set; }

        [JsonProperty("Nr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int Nr { get; set; }

        [JsonProperty("PLZ", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Plz { get; set; }

        [JsonProperty("Ort", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Ort { get; set; }

        [JsonProperty("Land", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Land { get; set; }

        [JsonProperty("Kundennummer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Kundennummer { get; set; }

        [JsonProperty("Telefon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Telefon { get; set; }

        [JsonProperty("Telefon_2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Telefon2 { get; set; }

        [JsonProperty("Fax", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }

        [JsonProperty("E-Mail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string EMail { get; set; }

        [JsonProperty("Ansprechpartner", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Ansprechpartner { get; set; }

        [JsonProperty("A.-Telefon", Required = Required.Always)]
        public string ATelefon { get; set; }

        [JsonProperty("A.-Mobil", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AMobil { get; set; }

        [JsonProperty("A.-Fax", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AFax { get; set; }

        [JsonProperty("A.-E-Mail", Required = Required.Always)]
        public string AEMail { get; set; }

        [JsonProperty("Lieferung", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Lieferung { get; set; }

        [JsonProperty("Vermietung", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Vermietung { get; set; }

        [JsonProperty("Presse", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Presse { get; set; }

        [JsonProperty("inaktiv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Inaktiv { get; set; }

        [JsonProperty("SteuerNr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public int SteuerNr { get; set; }

        [JsonProperty("USTNr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string UstNr { get; set; }

        [JsonProperty("Stand", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Stand { get; set; }

        [JsonProperty("Bearbeiter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Bearbeiter { get; set; }

        [JsonProperty("Bemerkung", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Bemerkung { get; set; }

        [JsonIgnore]
        public string Ersteller { get; set; } //Todo Implement this on sql query
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(int) || t == typeof(int);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            int l;
            if (Int32.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type int");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (int)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
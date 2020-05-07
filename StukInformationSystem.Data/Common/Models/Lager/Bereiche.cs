using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Models.Lager;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class Bereiche : IBereiche
    {
        [JsonProperty("Bereich")]
        public int Bereich { get; set; }

        [JsonProperty("BereichName")]
        public string BereichName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class ArtikelCount
    {
        [JsonProperty("Artikel")]
        public int Count { get; set; }
    }
}

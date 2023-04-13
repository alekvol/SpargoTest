using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpargoTest.Models
{
    public class GoodsModel
    {
        [JsonProperty("refId")]
        public string? RefId { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("producer")]
        public string? Producer { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("barcodes")]
        public string[]? Barcodes { get; set; }

        [JsonProperty("goodsGroupCodes")]
        public string? GoodsGroupCodes { get; set; }

        [JsonProperty("mnnEn")]
        public string? MnnEn { get; set; }

        [JsonProperty("mnnRu")]
        public string? MnnRu { get; set; }

        [JsonProperty("rv")]
        public string? Rv { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }
    }
}

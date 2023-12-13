using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Presentation.Rest.Services.Dto.Threshold
{
    public class ThresholdDto
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public int SourceId { get; set; }
        [JsonProperty]
        public int IndicatorId { get; set; }
        [JsonProperty]
        public int MinValue { get; set; }
        [JsonProperty]
        public int MaxValue { get; set; }
    }
}

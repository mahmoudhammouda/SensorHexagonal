using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Presentation.Rest.Services.Dto.Measure
{
    public class CreateMeasureDto
    {
        [JsonProperty]
        public int IndicatorId { get; set; }
        [JsonProperty]
        public int SourceId { get; set; }
        [JsonProperty]
        public string Valeur { get; set; }
        [JsonProperty]
        public string Unite { get; set; }
        [JsonProperty]
        public string ObservationTime { get; set; }
    }
}

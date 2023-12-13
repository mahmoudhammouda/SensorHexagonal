using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Presentation.Rest.Services.Dto.Measure
{
    public class UpdateMeasureDto
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Value { get; set; }
        [JsonProperty]
        public string Unity { get; set; }
        [JsonProperty]
        public string ObservationTime { get; set; }
    }
}

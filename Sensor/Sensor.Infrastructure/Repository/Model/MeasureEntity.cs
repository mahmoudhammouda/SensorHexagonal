using Sensor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository.Model
{
    [Table("MeasureEntity")]
    public class MeasureEntity : ModelEntity
    {
        [Column("IndicatorId")]
        public int IndicatorId { get; set; }
        [Column("SourceId")]
        public int SourceId { get; set; }
        [Column("Value")]
        public string Value { get;  set; }
        [Column("Unity")]
        public string Unity { get;  set; }

        [Column("ObservationTime")]
        public string ObservationTime { get; set; }

    }
}

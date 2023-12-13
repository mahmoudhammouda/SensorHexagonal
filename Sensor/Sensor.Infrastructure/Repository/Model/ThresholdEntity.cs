using Sensor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository.Model
{
    [Table("ThresholdEntity")]
    public class ThresholdEntity : ModelEntity
    {
        [Column("IndicatorId")]
        public int IndicatorId { get; set; }

        [Column("SourceId")]
        public int SourceId { get; set; }


        [Column("MinValue")]
        public int MinValue { get; set; }
        [Column("MaxValue")]
        public int MaxValue { get; set; }

    }
}

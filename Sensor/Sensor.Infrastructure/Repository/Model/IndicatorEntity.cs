using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository.Model
{
    [Table("IndicatorEntity")]
    public class IndicatorEntity : ModelEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Category")]
        public string Category { get; set; }
        [Column("Type")]
        public string Type { get; set; }
    }
}

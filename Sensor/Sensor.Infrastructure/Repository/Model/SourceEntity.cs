using Sensor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository.Model
{
    [Table("SourceEntity")]
    public class SourceEntity : ModelEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("SourceType")]
        public string SourceType { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Model
{
    public struct MeasureValue
    {
        public string Valeur { get; private set; }
        public string Unite { get; private set; }

        public MeasureValue(string valeur, string unite)
        {
            Valeur = valeur;
            Unite = unite;
        }

    }
}

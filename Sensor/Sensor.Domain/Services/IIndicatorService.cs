using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Services
{
    public  interface IIndicatorService
    {
        void AddIndicator(Indicator indicator);
        void UpdateIndicator(Indicator indicator);
        Indicator GetIndicator(int id);
        IEnumerable<Indicator> GetAllIndicator();
        void DeleteIndicator(Indicator indicator);

    }
}

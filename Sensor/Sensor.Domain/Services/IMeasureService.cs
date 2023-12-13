using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Services
{
    public  interface IMeasureService
    {
        void AddMeasure(Measure measure);
        Measure AddMeasure(
            int indicatorId,
            int sourceId,
            string value,
            string unite,
            DateTime observationTime);
        void UpdateMeasure(Measure measure);
        Measure UpdateMeasure(
            int id,
            string value,
            string unite,
            DateTime observationTime);
        Measure GetMeasure(int id);
        IEnumerable<Measure> GetAllMeasure();
        IEnumerable<Measure> GetLatestMeasures(int cout);
        void DeleteMesure(Measure measure);


    }
}

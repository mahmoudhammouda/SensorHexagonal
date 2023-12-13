using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Services
{
    public  interface IThresholdService
    {
        // Crud Operations
        void AddThreshold(Threshold threshold);
        void UpdateThreshold(Threshold threshold);
        Threshold GetThreshold(int id);
        IEnumerable<Threshold> GetAllThreshold();
        void DeleteThreshold(Threshold threshold);

        // Query Operations 
        IEnumerable<Threshold> FindBySourceId(int sourceId);
        Threshold FindBySourceIdAndIndicatorId(int sourceId, int indicatorId);

    }
}

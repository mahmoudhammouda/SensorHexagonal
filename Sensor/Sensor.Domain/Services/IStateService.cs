using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Services
{
    public  interface IStateService
    {
        // Crud Operations
        void UpdateOrCreateState(int sourceId, int indicatorId, int value);
        State GetState(int sourceId, int indicatorId);

    }
}

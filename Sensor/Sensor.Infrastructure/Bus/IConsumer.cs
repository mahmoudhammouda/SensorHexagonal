﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Bus
{
    public interface IConsumer<T>
    {
        void ReceiveMessage(T data);
    }
}

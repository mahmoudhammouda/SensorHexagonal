using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class StateDomainException : DomainException
    {
        public StateDomainException(string key) : base($" there is an issue with the state '{key}'")
        {
        }


    }

    public class InvalidModelException : DomainException
    {
        public InvalidModelException(string model, string operation) : base($" Model '{model}' Not valid for operation '{operation}'.")
        {
        }

       
    }

    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }


    public class NotFoundModelException : DomainException
    {
        public NotFoundModelException(string model, object key)
            : base($"the model '{model}' with key '{key}' not found.")
        {
        }
    }





}

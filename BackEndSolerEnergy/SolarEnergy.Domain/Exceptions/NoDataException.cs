using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarEnergy.Domain.Exceptions
{
    public class NoDataException : Exception
    {
        public NoDataException(string message) : base(message)
        {
        }
    }
}
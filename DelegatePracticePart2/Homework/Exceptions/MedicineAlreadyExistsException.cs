using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Exceptions
{
    internal class MedicineAlreadyExistsException : Exception
    {
        public MedicineAlreadyExistsException(string message) : base(message)
        {
        }
    }
}

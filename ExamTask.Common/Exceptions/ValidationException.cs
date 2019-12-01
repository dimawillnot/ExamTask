using ExamTask.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamTask.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public readonly ErrorCode ValidationCode;

        public ValidationException(ErrorCode validationCode)
        {
            ValidationCode = validationCode;
        }
    }
}

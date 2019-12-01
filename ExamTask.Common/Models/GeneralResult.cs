using ExamTask.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamTask.Common.Models
{
    public class GeneralResult<TError>
    {
        public bool IsSuccess { get; set; }

        public TError Error { get; set; }

        public string Message { get; set; }

        public ErrorCode ErrorCode { get; set; }
    }
}

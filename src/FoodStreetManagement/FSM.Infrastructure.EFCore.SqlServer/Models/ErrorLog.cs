using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.SqlServer.Models
{
    public partial class ErrorLog
    {
        public string LogId { get; set; } = null!;
        public string ErrorCode { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public string ErrorType { get; set; } = null!;
        public string? StackTrace { get; set; }
        public int? HttpStatusCode { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

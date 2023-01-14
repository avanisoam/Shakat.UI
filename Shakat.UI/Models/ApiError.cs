using System;
using System.ComponentModel;
using System.Linq;

namespace DaiNandani.Models
{
    public class ApiError
    {
        public string? Message { get; set; }
        public string? Details { get; set; }
        public string? StackTrace { get; set; }
    }
}

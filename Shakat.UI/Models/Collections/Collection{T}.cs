using System;
//using Newtonsoft.Json;

namespace DaiNandani.Models
{
    public class Collection<T> : Link
    {
        public T[]? Value { get; set; }
    }
}

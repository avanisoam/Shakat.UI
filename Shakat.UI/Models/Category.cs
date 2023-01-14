using System;

namespace DaiNandani.Models
{
	public class Category : Link
	{
		public string? Id { get; set; }
        public string? Name { get; set; }
		public string? Color { get; set; }
	}
}
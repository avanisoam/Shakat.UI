using System.Net;

namespace DaiNandani.Models
{
	public class ApiObjectResponse<T> : ApiResponse
	{
		public T? Response { get; set; }
	}
}
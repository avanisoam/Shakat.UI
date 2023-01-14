using System.Net;

namespace DaiNandani.Models
{
	public class ApiResponse
	{

		public HttpStatusCode StatusCode { get; set; }

		public ApiError? Error { get; set; }


	}
}
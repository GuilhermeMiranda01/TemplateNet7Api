using Microsoft.AspNetCore.Mvc;

namespace Application.Models
{
    internal class ExceptionDetails : ProblemDetails
    {  
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}

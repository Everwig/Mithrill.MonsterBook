using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Mithrill.MonsterBook.WebApi.Common
{
    /// <summary>
    /// Extension above ProblemDetails in .net core library because the base class don't expose traceId property what FE expect.
    /// </summary>
    public class ProblemDetailsWithTraceId : ProblemDetails
    {
        [JsonPropertyName("traceId")]
        public string? TraceId
        {
            get
            {
                Extensions.TryGetValue("traceId", out var traceId);
                return traceId?.ToString();
            }
        }
    }
}

using System;
using System.Net;

namespace Training.Common.Strategy;

[Serializable]
public class StrategyException : System.Exception
{
    public StrategyException(HttpStatusCode status, string message, System.Exception inner)
        : base(message, inner) => this.Status = status;
    public StrategyException(HttpStatusCode status, string message)
        : base(message) => this.Status = status;
    protected StrategyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    public HttpStatusCode Status { get; set; }
}
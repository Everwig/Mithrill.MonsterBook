using System;
using System.Runtime.Serialization;

namespace Mithrill.MonsterBook.Application.Common.Exceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message) { }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException) { }

        protected UnauthorizedException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }
    }
}

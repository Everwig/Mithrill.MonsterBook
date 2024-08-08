using System;
using System.Runtime.Serialization;

namespace Mithrill.MonsterBook.Application.Common.Exceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message) { }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException) { }

        protected ConflictException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }
    }
}
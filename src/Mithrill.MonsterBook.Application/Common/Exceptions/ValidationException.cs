using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Mithrill.MonsterBook.Application.Common.Exceptions;

[Serializable]
public class ValidationException : Exception
{
    public ValidationException(Exception? innerException = null)
        : base("One or more validation failures have occurred.", innerException)
    {
        Failures = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures, Exception? innerException = null)
        : this(innerException)
    {
        Failures = failures.GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public ValidationException(string message, IEnumerable<ValidationFailure> failures, Exception? innerException = null)
        : base(message, innerException)
    {
        Failures = failures.GroupBy(failure => failure.PropertyName, failure => failure.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext) { }

    public IDictionary<string, string[]> Failures { get; set; }
}
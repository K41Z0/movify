using System.Text.Json.Serialization;

namespace Domain.Common.Result;

/// <summary>
/// Represents the result of an operation that returns a value.
/// Pure implementation following Clean Architecture by Robert C. Martin.
/// </summary>
public class Result<T> : Result
{
    private readonly T? _value;

    [JsonConstructor]
    protected Result(bool isSuccess, T? value, string? error = null, ErrorType type = ErrorType.None)
        : base(isSuccess, error, type)
    {
        _value = value;
    }

    public T Value => IsSuccess 
        ? _value! 
        : throw new InvalidOperationException("Cannot access Value of a failed result.");

    public T? ValueOrDefault => _value;

    public static Result<T> Success(T value) => new(true, value);
    public static new Result<T> Failure(string error, ErrorType type = ErrorType.Failure) => new(false, default, error, type);

    public static implicit operator Result<T>(T value) => Success(value);
}
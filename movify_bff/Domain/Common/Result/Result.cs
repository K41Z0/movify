using System.Text.Json.Serialization;

namespace Domain.Common.Result;

/// <summary>
/// Represents the result of an operation that does not return a value.
/// Follows Uncle Bob's Clean Architecture principles.
/// </summary>
public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? Error { get; }
    public ErrorType Type { get; }

    [JsonConstructor]
    protected Result(bool isSuccess, string? error = null, ErrorType type = ErrorType.None)
    {
        IsSuccess = isSuccess;
        Error = error;
        Type = type;
    }

    public static Result Success() => new(true);
    public static Result Failure(string error, ErrorType type = ErrorType.Failure) => new(false, error, type);

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(string error, ErrorType type = ErrorType.Failure) => Result<T>.Failure(error, type);
}

public enum ErrorType
{
    None = 0,
    Failure = 1,
    NotFound = 2,
    Validation = 3,
    Conflict = 4
}
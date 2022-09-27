namespace Application.Core;

public class Result<T>
{
  public bool IsSuccess { get; set; }
  public T Value { get; set; } = default!;
  public string Error { get; set; } = String.Empty;
  public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
  public static Result<T> Failure(string error) => new() { IsSuccess = false, Error = error };
}
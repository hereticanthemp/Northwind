namespace Northwind.Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected Result(bool isSuccess, Error error, TValue? value) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException();

    public new static Result<TValue> Success(TValue value) => new(true, Error.None, value);
    
    public static implicit operator Result<TValue>(TValue value) => Success(value);

    public new static Result<TValue> Failure(Error error) => new(false, error, default);
}
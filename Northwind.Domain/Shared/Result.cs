namespace Northwind.Domain.Shared;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }
        
        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;
    
    public Error Error { get; }

    public static Result Success => new Result(true, Error.None);
    
    public static Result Failure(Error error) => new Result(false, error);
}
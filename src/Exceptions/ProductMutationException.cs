namespace SlopShop.Exceptions;

public class ProductMutationException : Exception
{
    public ProductMutationException()
    {
    }

    public ProductMutationException(string message)
        : base(message)
    {
    }

    public ProductMutationException(string message, Exception inner)
        : base(message, inner)  
    {
    }
}
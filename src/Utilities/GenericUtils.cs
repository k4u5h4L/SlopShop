namespace SlopShop.Utilities;

public class GenericUtils
{
    public static bool IsNull(object? obj)
    {
        return obj == null;
    }

    public static int GetPageNumber(int page)
    {
        return page < 1 ? 1 : page;
    }
}
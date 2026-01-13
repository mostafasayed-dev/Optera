namespace Optera.Shared.Response
{
    public enum ResponseStatus
    {
        NONE = 0,
        SUCCEEDED = 100,
        FAILED = -100,
        INVALID = -200,
        NOT_AUTHORIZED = -401,
        NOT_FOUND = -404,
    }
}

using RepetitionInfrastructure.ErrorHandling.CustomExceptions;

namespace RepetitionInfrastructure.ErrorHandling
{
    public static class ExceptionChecker
    {
        public static void CheckIfNullForDb(bool isNull, string objectType)
        {
            if (isNull)
            {
                throw new ItemNotFoundException(objectType);
            }
        }
        // not used for a while
    }
}

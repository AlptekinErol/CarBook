using CarBook.Common.Models;
using CarBook.Shared.Exceptions;

namespace CarBook.Shared.Extensions
{
    public static class ErrorCodeExtensions
    {
        public static void Throw(this ErrorCodes errorCodes)
        {
            switch (errorCodes)
            {
                case ErrorCodes.LocationNotFound:
                    throw new LocationNotFoundException();

                case ErrorCodes.LocationIdRequired:
                    throw new LocationIdRequiredException();

                case ErrorCodes.NoAvailableCars:
                    throw new NoAvailableCarsException();

                default:
                    throw new Exception("Bilinmeyen bir hata oluştu.");
            }
        }
    }
}

namespace CarBook.Shared.Exceptions
{
    public class LocationIdRequiredException : Exception
    {
        public int StatusCode { get; }

        public LocationIdRequiredException()
            : base("LocationId boş olamaz.")
        {
            StatusCode = 400;
        }
    }

    public class LocationNotFoundException : Exception
    {
        public int StatusCode { get; }

        public LocationNotFoundException()
            : base("Lokasyon bulunamadı.")
        {
            StatusCode = 404;
        }
    }

    public class NoAvailableCarsException : Exception
    {
        public int StatusCode { get; }

        public NoAvailableCarsException()
            : base("Uygun araç bulunamadı.")
        {
            StatusCode = 204;
        }
    }
}

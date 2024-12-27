using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string EMail { get; set; }
        public List<RentProcess> RentProcesses { get; set; }
    }
}

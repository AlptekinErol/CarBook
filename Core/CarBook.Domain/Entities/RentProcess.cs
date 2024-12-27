using CarBook.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBook.Domain.Entities
{
    public class RentProcess : EntityBase
    {
        public int CarId { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice{ get; set; }
        public int PickUpLocation { get; set; }
        public int DropOffLocation { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PickUpDate { get; set; }


        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }


        [DataType(DataType.Time)]
        public DateTime PickUpTime { get; set; }


        [DataType(DataType.Time)]
        public DateTime DropOffTime { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }

    }
}

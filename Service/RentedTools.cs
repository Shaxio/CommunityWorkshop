using System;
namespace Service
{
    public class RentedTools
    {
        public long ToolID { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public DateTime RentalDate { get; set; }
    }
}
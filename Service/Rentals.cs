﻿using System;
namespace Service
{
    public class Rentals
    {
        public long RentalID { get; set; }
        public long ToolID { get; set; }
        public long UserID { get; set; }
        public string RentersName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime RentalReturn { get; set; }
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
    }
}
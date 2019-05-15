namespace Service
{
    public class Staff
    {
        public long StaffID { get; set; }
        public string UserName { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
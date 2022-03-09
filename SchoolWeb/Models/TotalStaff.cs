namespace SchoolWeb.Models
{
    public class TotalStaff
    {
        public IEnumerable<Staff> Staff { get; set; }
        public IEnumerable<Administration> Administration { get; set; }
    }
}

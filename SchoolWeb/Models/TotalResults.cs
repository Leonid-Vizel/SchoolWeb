namespace SchoolWeb.Models
{
    public class TotalResults
    {
        public IEnumerable<EgeResult> Ege { get; set; }
        public IEnumerable<OgeResult> Oge { get; set; }
    }
}

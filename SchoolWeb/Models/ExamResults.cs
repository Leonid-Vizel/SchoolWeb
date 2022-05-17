namespace SchoolWeb.Models
{
    public class ExamResults
    {
        public IEnumerable<EgeResult> Ege { get; set; }
        public IEnumerable<OgeResult> Oge { get; set; }
    }
}

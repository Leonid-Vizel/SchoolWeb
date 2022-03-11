using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class ScheduleInfo
    {
        [Required]
        [DisplayName("Продолжительность учебного года для учеников 1 классов")]
        public int YearDuration1 { get; set; }
        [Required]
        [DisplayName("Продолжительность учебного года для учеников 2 - 8 классов")]
        public int YearDuration2_8 { get; set; }
        [Required]
        [DisplayName("Продолжительность учебного года для учеников 9 классов")]
        public int YearDuration9 { get; set; }
        [Required]
        [DisplayName("Продолжительность учебного года для учеников 10 классов")]
        public int YearDuration10 { get; set; }
        [Required]
        [DisplayName("Продолжительность учебного года для учеников 11 классов")]
        public int YearDuration11 { get; set; }

        [Required]
        [DisplayName("Начало осенних каникул")]
        public DateTime Holiday1Start { get; set; }
        [Required]
        [DisplayName("Конец осенних каникул")]
        public DateTime Holiday1End { get; set; }
        [Required]
        [DisplayName("Начало зимних каникул")]
        public DateTime Holiday2Start { get; set; }
        [Required]
        [DisplayName("Конец зимних каникул")]
        public DateTime Holiday2End { get; set; }
        [Required]
        [DisplayName("Начало весенних каникул")]
        public DateTime Holiday3Start { get; set; }
        [Required]
        [DisplayName("Конец весенних каникул")]
        public DateTime Holiday3End { get; set; }
        [Required]
        [DisplayName("Начало дополнительных каникул")]
        public DateTime Holiday4Start { get; set; }
        [Required]
        [DisplayName("Конец дополнительных каникул")]
        public DateTime Holiday4End { get; set; }

        [Required]
        [DisplayName("Начало I-ой четверти")]
        public DateTime Quarter1Start { get; set; }
        [Required]
        [DisplayName("Конец I-ой четверти")]
        public DateTime Quarter1End { get; set; }
        [Required]
        [DisplayName("Начало II-ой четверти")]
        public DateTime Quarter2Start { get; set; }
        [Required]
        [DisplayName("Конец II-ой четверти")]
        public DateTime Quarter2End { get; set; }
        [Required]
        [DisplayName("Начало III-ей четверти")]
        public DateTime Quarter3Start { get; set; }
        [Required]
        [DisplayName("Конец III-ой четверти")]
        public DateTime Quarter3End { get; set; }
        [Required]
        [DisplayName("Начало IV-ой четверти")]
        public DateTime Quarter4Start { get; set; }
        [Required]
        [DisplayName("Конец IV-ой четверти")]
        public DateTime Quarter4End { get; set; }
    }
}
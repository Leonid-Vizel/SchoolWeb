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
        [DisplayName("Начало")]
        public DateTime Holiday1Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Holiday1End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Holiday2Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Holiday2End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Holiday3Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Holiday3End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Holiday4Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Holiday4End { get; set; }

        [Required]
        [DisplayName("Начало")]
        public DateTime Quarter1Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Quarter1End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Quarter2Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Quarter2End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Quarter3Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Quarter3End { get; set; }
        [Required]
        [DisplayName("Начало")]
        public DateTime Quarter4Start { get; set; }
        [Required]
        [DisplayName("Конец")]
        public DateTime Quarter4End { get; set; }


        public void Copy(ScheduleInfo info)
        {
            YearDuration1 = info.YearDuration1;
            YearDuration2_8 = info.YearDuration2_8;
            YearDuration9 = info.YearDuration9;
            YearDuration10 = info.YearDuration10;
            YearDuration11 = info.YearDuration11;

            Holiday1Start = info.Holiday1Start;
            Holiday1End = info.Holiday1End;
            Holiday2Start = info.Holiday2Start;
            Holiday2End = info.Holiday2End;
            Holiday3Start = info.Holiday3Start;
            Holiday3End = info.Holiday3End;
            Holiday4Start = info.Holiday4Start;
            Holiday4End = info.Holiday4End;

            Quarter1Start = info.Holiday1Start;
            Quarter1End = info.Holiday1End;
            Quarter2Start = info.Holiday2Start;
            Quarter2End = info.Holiday2End;
            Quarter3Start = info.Holiday3Start;
            Quarter3End = info.Holiday3End;
            Quarter4Start = info.Holiday4Start;
            Quarter4End = info.Holiday4End;
        }
    }
}
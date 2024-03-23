using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.Exams
{
    /// <summary> Data Transfer Object for Exam. </summary>
	public class ExamDTO
    {
        /// <summary> SchoolId. Default value is 0. </summary>
        [Display(Name = "ExamID")]
        public long ExamId { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> SchoolId </summary>
        [Required]
        [Display(Name = "SchoolId")]
        public long SchoolId { get; set; } 
    }
}

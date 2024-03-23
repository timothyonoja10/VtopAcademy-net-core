using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using VtopAcademy.Schools;

namespace VtopAcademy.Exams
{
    public class Exam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ExamId { get; set; } 

        public string Name { get; set; } = null!;
        public int Number { get; set; }

        public long SchoolId { get; set; }

        [IgnoreDataMember]
        public virtual School School { get; set; } = null!;
    }
}

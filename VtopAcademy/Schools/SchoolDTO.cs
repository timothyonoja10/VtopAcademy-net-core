﻿using System.ComponentModel.DataAnnotations;

namespace VtopAcademy.Schools
{
    public class SchoolDTO
    {
        /// <summary> SchoolId. Default value is 0. </summary>
        [Display(Name = "SchoolId")]
        public long SchoolId { get; set; }

        /// <summary> Name </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        /// <summary> Number </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }
    }
}

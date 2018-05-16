//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _123.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
            this.Classrooms = new HashSet<Classroom>();
        }
    
        public int Teacher_ID { get; set; }
        [DisplayName("Teacher Name")]
        [Required(ErrorMessage = "This filed is required.")]
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        [Required(ErrorMessage = "This filed is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
        public virtual Unavailable_Days Unavailable_Days { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual Unavaliable_Time Unavaliable_Time { get; set; }
        public string LoginErrorMessage { get; set; }

    }
}

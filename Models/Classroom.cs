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
    
    public partial class Classroom
    {
        public int Classroom_ID { get; set; }
        public string ClassroomName { get; set; }
        public Nullable<int> Teacher_ID { get; set; }
        public Nullable<int> Capacity { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}

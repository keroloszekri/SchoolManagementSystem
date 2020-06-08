//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArmyTech.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.StudentTeachers = new HashSet<StudentTeacher>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int GovernorateId { get; set; }
        public Nullable<int> NeighborhoodId { get; set; }
        public int FieldId { get; set; }
    
        public virtual Field Field { get; set; }
        public virtual Governorate Governorate { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}

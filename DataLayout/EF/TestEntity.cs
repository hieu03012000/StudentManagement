//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayout.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestEntity()
        {
            this.Answers = new HashSet<AnswerEntity>();
        }
    
        public System.Guid TestID { get; set; }
        public string TestTitle { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string TeacherID { get; set; }
        public System.Guid ClassID { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerEntity> Answers { get; set; }
        public virtual ClassEntity Class { get; set; }
        public virtual PersonEntity Person { get; set; }
    }
}

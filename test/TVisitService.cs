//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Collections.Generic;
    
    public partial class TVisitService
    {
        public TVisitService()
        {
            this.THealthExams = new HashSet<THealthExam>();
        }
    
        public int intVisitServiceID { get; set; }
        public int intVisitID { get; set; }
        public int intServiceID { get; set; }
    
        public virtual ICollection<THealthExam> THealthExams { get; set; }
    }
}
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
    
    public partial class THealthExam
    {
        public THealthExam()
        {
            this.TAbdomenInfos = new HashSet<TAbdomenInfo>();
            this.TEarStatusInfos = new HashSet<TEarStatusInfo>();
            this.TEyeStatusInfos = new HashSet<TEyeStatusInfo>();
            this.TGIInfos = new HashSet<TGIInfo>();
            this.THeartInfos = new HashSet<THeartInfo>();
            this.TLungInfos = new HashSet<TLungInfo>();
            this.TMouthInfos = new HashSet<TMouthInfo>();
            this.TMusculoskeletalInfos = new HashSet<TMusculoskeletalInfo>();
            this.TNeurologicalInfos = new HashSet<TNeurologicalInfo>();
            this.TNoseThroatInfos = new HashSet<TNoseThroatInfo>();
            this.TSkinInfos = new HashSet<TSkinInfo>();
            this.TUrogenitalInfos = new HashSet<TUrogenitalInfo>();
        }
    
        public int intHealthExamID { get; set; }
        public double dblWeight { get; set; }
        public double dblTemperature { get; set; }
        public int intHeartRate { get; set; }
        public int intRespRate { get; set; }
        public int intCapillaryRefillTime { get; set; }
        public string strMucousMembrane { get; set; }
        public int intVisitServiceID { get; set; }
        public string strNotes { get; set; }
    
        public virtual ICollection<TAbdomenInfo> TAbdomenInfos { get; set; }
        public virtual ICollection<TEarStatusInfo> TEarStatusInfos { get; set; }
        public virtual ICollection<TEyeStatusInfo> TEyeStatusInfos { get; set; }
        public virtual ICollection<TGIInfo> TGIInfos { get; set; }
        public virtual TVisitService TVisitService { get; set; }
        public virtual ICollection<THeartInfo> THeartInfos { get; set; }
        public virtual ICollection<TLungInfo> TLungInfos { get; set; }
        public virtual ICollection<TMouthInfo> TMouthInfos { get; set; }
        public virtual ICollection<TMusculoskeletalInfo> TMusculoskeletalInfos { get; set; }
        public virtual ICollection<TNeurologicalInfo> TNeurologicalInfos { get; set; }
        public virtual ICollection<TNoseThroatInfo> TNoseThroatInfos { get; set; }
        public virtual ICollection<TSkinInfo> TSkinInfos { get; set; }
        public virtual ICollection<TUrogenitalInfo> TUrogenitalInfos { get; set; }
    }
}

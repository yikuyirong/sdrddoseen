using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_PlanManage
    {
        public Tbl_PlanManage ()
        {

        }
		
        private Int32 ID_;
        public Int32 ID
        {
            get { return ID_; }
            set { this.ID_ = value; }
        }
        
        private String PlanDate_;
        public String PlanDate
        {
            get{ return PlanDate_; }
            set{ this.PlanDate_=value;}
        }
		
        private String PlanContent_;
        public String PlanContent
        {
            get{ return PlanContent_; }
            set{ this.PlanContent_=value;}
        }
		
        private String NodeUser_;
        public String NodeUser
        {
            get{ return NodeUser_; }
            set{ this.NodeUser_=value;}
        }
		
        private String Status_;
        public String Status
        {
            get{ return Status_; }
            set{ this.Status_=value;}
        }
		
        private String DealUser_;
        public String DealUser
        {
            get{ return DealUser_; }
            set{ this.DealUser_=value;}
        }
		
        private Int32 DealFlag_;
        public Int32 DealFlag
        {
            get{ return DealFlag_; }
            set{ this.DealFlag_=value;}
        }
		
        private DateTime DealTime_;
        public DateTime DealTime
        {
            get{ return DealTime_; }
            set{ this.DealTime_=value;}
        }
		
        private DateTime AddDate_;
        public DateTime AddDate
        {
            get{ return AddDate_; }
            set{ this.AddDate_=value;}
        }
		
    }
}

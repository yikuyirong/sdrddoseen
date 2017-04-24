using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_OtherWork
    {
        public Tbl_OtherWork ()
        {

        }
		
        private Int32 ID_;
        public Int32 ID
        {
            get { return ID_; }
            set { this.ID_ = value; }
        }
        
        private Int32 ProjectID_;
        public Int32 ProjectID
        {
            get{ return ProjectID_; }
            set{ this.ProjectID_=value;}
        }

        private String ProjectName_;
        public String ProjectName
        {
            get { return ProjectName_; }
            set { this.ProjectName_ = value; }
        }
		
        private String UserName_;
        public String UserName
        {
            get{ return UserName_; }
            set{ this.UserName_=value;}
        }
		
        private String WorkType_;
        public String WorkType
        {
            get{ return WorkType_; }
            set{ this.WorkType_=value;}
        }
		
        private String WorkDay_;
        public String WorkDay
        {
            get{ return WorkDay_; }
            set{ this.WorkDay_=value;}
        }
		
        private String WorkInfo_;
        public String WorkInfo
        {
            get{ return WorkInfo_; }
            set{ this.WorkInfo_=value;}
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

using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_OutFile
    {
        public Tbl_OutFile ()
        {

        }
		
        private Int32 ID_;
        public Int32 ID
        {
            get { return ID_; }
            set { this.ID_ = value; }
        }
        
        private String ProjectID_;
        public String ProjectID
        {
            get{ return ProjectID_; }
            set{ this.ProjectID_=value;}
        }
		
        private String ClassName_;
        public String ClassName
        {
            get{ return ClassName_; }
            set{ this.ClassName_=value;}
        }
		
        private String FileName_;
        public String FileName
        {
            get{ return FileName_; }
            set{ this.FileName_=value;}
        }
		
        private String FileUrl_;
        public String FileUrl
        {
            get{ return FileUrl_; }
            set{ this.FileUrl_=value;}
        }
		
        private String FileInfo_;
        public String FileInfo
        {
            get{ return FileInfo_; }
            set{ this.FileInfo_=value;}
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

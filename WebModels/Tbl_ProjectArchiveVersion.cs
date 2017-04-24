using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectArchiveVersion
    {
        public Tbl_ProjectArchiveVersion ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int projectID;
        public int ProjectID
        {
            get{ return projectID; }
            set{ this.projectID=value;}
        }
        private int projectArchiveID;
        public int ProjectArchiveID
        {
            get{ return projectArchiveID; }
            set{ this.projectArchiveID=value;}
        }
        private string pAV_File;
        public string PAV_File
        {
            get{ return pAV_File; }
            set{ this.pAV_File=value;}
        }
        private string pAV_Info;
        public string PAV_Info
        {
            get{ return pAV_Info; }
            set{ this.pAV_Info=value;}
        }
        private int dealFlag;
        public int DealFlag
        {
            get { return dealFlag; }
            set { this.dealFlag = value; }
        }
        private string dealUser;
        public string DealUser
        {
            get { return dealUser; }
            set { this.dealUser = value; }
        }
        private DateTime dealTime;
        public DateTime DealTime
        {
            get { return dealTime; }
            set { this.dealTime = value; }
        }
        private DateTime addDate;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

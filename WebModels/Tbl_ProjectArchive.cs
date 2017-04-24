using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectArchive
    {
        public Tbl_ProjectArchive ()
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
        private string className1;

        public string ClassName1
        {
            get { return className1; }
            set { className1 = value; }
        }
        private string className2;

        public string ClassName2
        {
            get { return className2; }
            set { className2 = value; }
        }
        private string className3;

        public string ClassName3
        {
            get { return className3; }
            set { className3 = value; }
        }

        private string pA_Type1;
        public string PA_Type1
        {
            get{ return pA_Type1; }
            set{ this.pA_Type1=value;}
        }
        private string pA_Type2;
        public string PA_Type2
        {
            get { return pA_Type2; }
            set { this.pA_Type2 = value; }
        }
        private int parentID;

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private string pA_Limit;

        public string PA_Limit
        {
            get { return pA_Limit; }
            set { pA_Limit = value; }
        }
        private string pA_Name;
        public string PA_Name
        {
            get{ return pA_Name; }
            set{ this.pA_Name=value;}
        }
        private string pA_File;

        public string PA_File
        {
            get { return pA_File; }
            set { pA_File = value; }
        }
        private string pA_FileNo;

        public string PA_FileNo
        {
            get { return pA_FileNo; }
            set { pA_FileNo = value; }
        }

        private string pA_Info;
        public string PA_Info
        {
            get{ return pA_Info; }
            set{ this.pA_Info=value;}
        }
        private string status;
        public string Status
        {
            get{ return status; }
            set{ this.status=value;}
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

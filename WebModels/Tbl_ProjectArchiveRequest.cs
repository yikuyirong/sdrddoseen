using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectArchiveRequest
    {
        public Tbl_ProjectArchiveRequest ()
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
            get { return projectID; }
            set { this.projectID = value; }
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
            get { return pA_Type1; }
            set { this.pA_Type1 = value; }
        }
        private string pA_Type2;
        public string PA_Type2
        {
            get { return pA_Type2; }
            set { this.pA_Type2 = value; }
        }

        private int projectArchiveID;
        public int ProjectArchiveID
        {
            get { return projectArchiveID; }
            set { this.projectArchiveID = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string requestType;

        public string RequestType
        {
            get { return requestType; }
            set { requestType = value; }
        }

        private string statue;

        public string Statue
        {
            get { return statue; }
            set { statue = value; }
        }

        private string nodeNo;
        public string NodeNo
        {
            get { return nodeNo; }
            set { this.nodeNo = value; }
        }

        private string nodeUser;
        public string NodeUser
        {
            get { return nodeUser; }
            set { this.nodeUser = value; }
        }

        private string status;
        public string Status
        {
            get{ return status; }
            set{ this.status=value;}
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
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
        public string TextArea1;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectDocument
    {
        public Tbl_ProjectDocument ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string userName;
        public string UserName
        {
            get{ return userName; }
            set{ this.userName=value;}
        }
        private int projectID;
        public int ProjectID
        {
            get{ return projectID; }
            set{ this.projectID=value;}
        }
        private int parentID;
        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        private string pD_Type;
        public string PD_Type
        {
            get { return pD_Type; }
            set { pD_Type = value; }
        }
        private string pD_File;
        public string PD_File
        {
            get { return pD_File; }
            set { pD_File = value; }
        }
        private string pD_FileNo;
        public string PD_FileNo
        {
            get { return pD_FileNo; }
            set { pD_FileNo = value; }
        }
        private string pD_Users;
        public string PD_Users
        {
            get { return pD_Users; }
            set { pD_Users = value; }
        }
        private string pD_Name;
        public string PD_Name
        {
            get { return pD_Name; }
            set { this.pD_Name = value; }
        }
        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
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

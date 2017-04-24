using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_DesignChange
    {
        public Tbl_DesignChange ()
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
        private string contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private DateTime changeTime;

        public DateTime ChangeTime
        {
            get { return changeTime; }
            set { changeTime = value; }
        }
        private string fileNo;

        public string FileNo
        {
            get { return fileNo; }
            set { fileNo = value; }
        }
        private string changeInfo;
        public string ChangeInfo
        {
            get{ return changeInfo; }
            set{ this.changeInfo=value;}
        }
        private string changeFile;
        public string ChangeFile
        {
            get{ return changeFile; }
            set{ this.changeFile=value;}
        }
        private string changeDwg;
        public string ChangeDwg
        {
            get { return changeDwg; }
            set { this.changeDwg = value; }
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

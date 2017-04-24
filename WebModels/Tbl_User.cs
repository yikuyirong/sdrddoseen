using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_User
    {
        public Tbl_User ()
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
        private string u_DesignLimit;
        public string U_DesignLimit
        {
            get { return u_DesignLimit; }
            set { this.u_DesignLimit = value; }
        }
        private string userPwd;
        public string UserPwd
        {
            get{ return userPwd; }
            set{ this.userPwd=value;}
        }
        private string limitID;

        public string LimitID
        {
            get { return limitID; }
            set { limitID = value; }
        }
        private string u_Pic;
        public string U_Pic
        {
            get { return u_Pic; }
            set { this.u_Pic = value; }
        }
        private string u_Name;

        public string U_Name
        {
            get { return u_Name; }
            set { u_Name = value; }
        }

        private string u_Sex;
        public string U_Sex
        {
            get { return u_Sex; }
            set { this.u_Sex = value; }
        }
        private string u_Degrees;

        public string U_Degrees
        {
            get { return u_Degrees; }
            set { u_Degrees = value; }
        }
        private DateTime u_GraduateTime;

        public DateTime U_GraduateTime
        {
            get { return u_GraduateTime; }
            set { u_GraduateTime = value; }
        }
        private DateTime u_EntryTime;

        public DateTime U_EntryTime
        {
            get { return u_EntryTime; }
            set { u_EntryTime = value; }
        }
        private string u_Professional;

        public string U_Professional
        {
            get { return u_Professional; }
            set { u_Professional = value; }
        }
        private string u_Phone;
        public string U_Phone
        {
            get{ return u_Phone; }
            set{ this.u_Phone=value;}
        }
        private string u_DepartID;

        public string U_DepartID
        {
            get { return u_DepartID; }
            set { u_DepartID = value; }
        }
        private string u_JobID;

        public string U_JobID
        {
            get { return u_JobID; }
            set { u_JobID = value; }
        }
            
        private string u_Specialty;

        public string U_Specialty
        {
            get { return u_Specialty; }
            set { u_Specialty = value; }
        }
        private string u_Mobile;
        public string U_Mobile
        {
            get{ return u_Mobile; }
            set{ this.u_Mobile=value;}
        }
        private string u_WeChat;
        public string U_WeChat
        {
            get{ return u_WeChat; }
            set{ this.u_WeChat=value;}
        }
        private string u_Sign;

        public string U_Sign
        {
            get { return u_Sign; }
            set { u_Sign = value; }
        }

        private string u_SignDxf;

        public string U_SignDxf
        {
            get { return u_SignDxf; }
            set { u_SignDxf = value; }
        }

        private string u_QQ;
        public string U_QQ
        {
            get{ return u_QQ; }
            set{ this.u_QQ=value;}
        }
        private string u_Email;
        public string U_Email
        {
            get{ return u_Email; }
            set{ this.u_Email=value;}
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
            get{ return dealFlag; }
            set{ this.dealFlag=value;}
        }
        private string dealUser;
        public string DealUser
        {
            get{ return dealUser; }
            set{ this.dealUser=value;}
        }
        private DateTime dealTime;
        public DateTime DealTime
        {
            get{ return dealTime; }
            set{ this.dealTime=value;}
        }
        private DateTime addDate;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
        private string u_JobRank;
        public string U_JobRank
        {
            get { return u_JobRank; }
            set { this.u_JobRank = value; }
        }
        private string u_JobTitle;
        public string U_JobTitle
        {
            get { return u_JobTitle; }
            set { this.u_JobTitle = value; }
        }
        private DateTime u_ContractStartTime;
        public DateTime U_ContractStartTime
        {
            get { return u_ContractStartTime; }
            set { this.u_ContractStartTime = value; }
        }
        private DateTime u_ContractEndTime;
        public DateTime U_ContractEndTime
        {
            get { return u_ContractEndTime; }
            set { this.u_ContractEndTime = value; }
        }
        private DateTime u_DocumentTime;
        public DateTime U_DocumentTime
        {
            get { return u_DocumentTime; }
            set { this.u_DocumentTime = value; }
        }
        private string u_CardID;
        public string U_CardID
        {
            get { return u_CardID; }
            set { this.u_CardID = value; }
        }
        private string remark;
        public string Remark
        {
            get { return remark; }
            set { this.remark = value; }
        }
    }
}

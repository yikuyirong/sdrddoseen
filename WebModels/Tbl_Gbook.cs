using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Gbook
    {
        public Tbl_Gbook ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string g_Title;
        public string G_Title
        {
            get{ return g_Title; }
            set{ this.g_Title=value;}
        }
        private string userName;
        public string UserName
        {
            get{ return userName; }
            set{ this.userName=value;}
        }
        private string g_Content;
        public string G_Content
        {
            get{ return g_Content; }
            set{ this.g_Content=value;}
        }
        private string userPwd;
        public string UserPwd
        {
            get{ return userPwd; }
            set{ this.userPwd=value;}
        }
        private string g_Reply;
        public string G_Reply
        {
            get{ return g_Reply; }
            set{ this.g_Reply=value;}
        }
        private string g_Name;
        public string G_Name
        {
            get{ return g_Name; }
            set{ this.g_Name=value;}
        }
        private string g_Phone;
        public string G_Phone
        {
            get{ return g_Phone; }
            set{ this.g_Phone=value;}
        }
        private string g_Mobile;
        public string G_Mobile
        {
            get{ return g_Mobile; }
            set{ this.g_Mobile=value;}
        }
        private string g_QQ;
        public string G_QQ
        {
            get{ return g_QQ; }
            set{ this.g_QQ=value;}
        }
        private string g_Email;
        public string G_Email
        {
            get{ return g_Email; }
            set{ this.g_Email=value;}
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
    }
}

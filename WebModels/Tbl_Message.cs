using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Message
    {
        public Tbl_Message ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string userNameFrom;
        public string UserNameFrom
        {
            get{ return userNameFrom; }
            set{ this.userNameFrom=value;}
        }
        private string userNameTo;
        public string UserNameTo
        {
            get{ return userNameTo; }
            set{ this.userNameTo=value;}
        }
        private string messageInfo;
        public string MessageInfo
        {
            get{ return messageInfo; }
            set{ this.messageInfo=value;}
        }
        private string messageFile;
        public string MessageFile
        {
            get{ return messageFile; }
            set{ this.messageFile=value;}
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

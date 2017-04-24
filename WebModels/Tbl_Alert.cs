using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Alert
    {
        public Tbl_Alert ()
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
        private string alertType;
        public string AlertType
        {
            get{ return alertType; }
            set{ this.alertType=value;}
        }
        private string alertTitle;
        public string AlertTitle
        {
            get{ return alertTitle; }
            set{ this.alertTitle=value;}
        }
        private string alertInfo;
        public string AlertInfo
        {
            get{ return alertInfo; }
            set{ this.alertInfo=value;}
        }
        private string alertUrl;
        public string AlertUrl
        {
            get{ return alertUrl; }
            set{ this.alertUrl=value;}
        }
        private string alertMode;
        public string AlertMode
        {
            get{ return alertMode; }
            set{ this.alertMode=value;}
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

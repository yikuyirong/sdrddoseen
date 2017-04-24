using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Limit
    {
        public Tbl_Limit ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string limitName;
        public string LimitName
        {
            get{ return limitName; }
            set{ this.limitName=value;}
        }
        private string limitInfo;
        public string LimitInfo
        {
            get{ return limitInfo; }
            set{ this.limitInfo=value;}
        }
        private string remark;
        public string Remark
        {
            get{ return remark; }
            set{ this.remark=value;}
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

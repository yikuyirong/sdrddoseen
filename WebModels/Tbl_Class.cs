using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Class
    {
        public Tbl_Class ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string className;
        public string ClassName
        {
            get{ return className; }
            set{ this.className=value;}
        }
        private int parentID;
        public int ParentID
        {
            get{ return parentID; }
            set{ this.parentID=value;}
        }
        private string remark;
        public string Remark
        {
            get{ return remark; }
            set{ this.remark=value;}
        }
        private int orderNum;
        public int OrderNum
        {
            get{ return orderNum; }
            set{ this.orderNum=value;}
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

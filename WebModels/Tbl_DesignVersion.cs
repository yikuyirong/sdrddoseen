using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_DesignVersion
    {
        public Tbl_DesignVersion ()
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
        private int designTaskID;
        public int DesignTaskID
        {
            get{ return designTaskID; }
            set{ this.designTaskID=value;}
        }
        private string cadFile;
        public string CadFile
        {
            get{ return cadFile; }
            set{ this.cadFile=value;}
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

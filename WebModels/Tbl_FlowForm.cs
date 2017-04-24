using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_FlowForm
    {
        public Tbl_FlowForm ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string iF_Name;
        public string IF_Name
        {
            get{ return iF_Name; }
            set{ this.iF_Name=value;}
        }
        private string iF_Type;
        public string IF_Type
        {
            get{ return iF_Type; }
            set{ this.iF_Type=value;}
        }
        private string iF_Content;
        public string IF_Content
        {
            get{ return iF_Content; }
            set{ this.iF_Content=value;}
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

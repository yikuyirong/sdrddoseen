using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Page
    {
        public Tbl_Page ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string p_Title;
        public string P_Title
        {
            get{ return p_Title; }
            set{ this.p_Title=value;}
        }
        private string p_Keyword;
        public string P_Keyword
        {
            get{ return p_Keyword; }
            set{ this.p_Keyword=value;}
        }
        private string p_Description;
        public string P_Description
        {
            get{ return p_Description; }
            set{ this.p_Description=value;}
        }
        private string p_Content;
        public string P_Content
        {
            get{ return p_Content; }
            set{ this.p_Content=value;}
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

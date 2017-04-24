using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuilder
    {
        public Tbl_ProjectBuilder ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int projectID;
        public int ProjectID
        {
            get{ return projectID; }
            set{ this.projectID=value;}
        }
        private int projectBuilderContractID;
        public int ProjectBuilderContractID
        {
            get{ return projectBuilderContractID; }
            set{ this.projectBuilderContractID=value;}
        }
        private string pOC_Name;
        public string POC_Name
        {
            get{ return pOC_Name; }
            set{ this.pOC_Name=value;}
        }
        private string pOC_LinkMan;
        public string POC_LinkMan
        {
            get{ return pOC_LinkMan; }
            set{ this.pOC_LinkMan=value;}
        }
        private string pOC_LinkPhone;
        public string POC_LinkPhone
        {
            get{ return pOC_LinkPhone; }
            set{ this.pOC_LinkPhone=value;}
        }
        private string pOC_Email;
        public string POC_Email
        {
            get{ return pOC_Email; }
            set{ this.pOC_Email=value;}
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

using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuilderContract
    {
        public Tbl_ProjectBuilderContract ()
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
        private int pBC_CompanyID;
        public int PBC_CompanyID
        {
            get { return pBC_CompanyID; }
            set { this.pBC_CompanyID = value; }
        }
        private DateTime pBC_StartTime;

        public DateTime PBC_StartTime
        {
            get { return pBC_StartTime; }
            set { pBC_StartTime = value; }
        }
        private DateTime pBC_Time1;

        public DateTime PBC_Time1
        {
            get { return pBC_Time1; }
            set { pBC_Time1 = value; }
        }
        private DateTime pBC_Time2;

        public DateTime PBC_Time2
        {
            get { return pBC_Time2; }
            set { pBC_Time2 = value; }
        }
        private string pBC_Link;

        public string PBC_Link
        {
            get { return pBC_Link; }
            set { pBC_Link = value; }
        }
        private string pBC_LinkPhone;

        public string PBC_LinkPhone
        {
            get { return pBC_LinkPhone; }
            set { pBC_LinkPhone = value; }
        }
        private string pBC_Content;

        public string PBC_Content
        {
            get { return pBC_Content; }
            set { pBC_Content = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string pBC_File;
        public string PBC_File
        {
            get{ return pBC_File; }
            set{ this.pBC_File=value;}
        }
        private double pBC_Price;
        public double PBC_Price
        {
            get{ return pBC_Price; }
            set{ this.pBC_Price=value;}
        }
        private string pBC_FeeType;
        public string PBC_FeeType
        {
            get{ return pBC_FeeType; }
            set{ this.pBC_FeeType=value;}
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

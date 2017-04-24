using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectOuterDesign
    {
        public Tbl_ProjectOuterDesign ()
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
        private int pO_CompanyID;
        public int PO_CompanyID
        {
            get{ return pO_CompanyID; }
            set{ this.pO_CompanyID=value;}
        }
        private string pO_Content;
        public string PO_Content
        {
            get{ return pO_Content; }
            set{ this.pO_Content=value;}
        }
        private DateTime pO_StartTime;
        public DateTime PO_StartTime
        {
            get{ return pO_StartTime; }
            set{ this.pO_StartTime=value;}
        }
        private string pO_File;

        public string PO_File
        {
            get { return pO_File; }
            set { pO_File = value; }
        }

        private double pO_Price;
        public double PO_Price
        {
            get{ return pO_Price; }
            set{ this.pO_Price=value;}
        }
        private string pO_FeeType;
        public string PO_FeeType
        {
            get{ return pO_FeeType; }
            set{ this.pO_FeeType=value;}
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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

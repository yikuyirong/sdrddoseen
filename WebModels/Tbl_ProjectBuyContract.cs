using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuyContract
    {
        public Tbl_ProjectBuyContract ()
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
        private string pBC_Company;
        public string PBC_Company
        {
            get{ return pBC_Company; }
            set{ this.pBC_Company=value;}
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

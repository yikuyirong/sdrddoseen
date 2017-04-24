using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectContract
    {
        public Tbl_ProjectContract ()
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
        private string pC_Name;

        public string PC_Name
        {
            get { return pC_Name; }
            set { pC_Name = value; }
        }
        private string pC_File;
        public string PC_File
        {
            get{ return pC_File; }
            set{ this.pC_File=value;}
        }
        private double pC_Price;
        public double PC_Price
        {
            get{ return pC_Price; }
            set{ this.pC_Price=value;}
        }
        private double pC_MoneyReceive;
        public double PC_MoneyReceive
        {
            get { return pC_MoneyReceive; }
            set { this.pC_MoneyReceive = value; }
        }
        private double pC_MoneyBill;
        public double PC_MoneyBill
        {
            get { return pC_MoneyBill; }
            set { this.pC_MoneyBill = value; }
        }
        private string pC_FeeType;
        public string PC_FeeType
        {
            get{ return pC_FeeType; }
            set{ this.pC_FeeType=value;}
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

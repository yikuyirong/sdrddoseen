using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectOuter
    {
        public Tbl_ProjectOuter ()
        {

        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { this.iD = value; }
        }
        private int projectID;
        public int ProjectID
        {
            get { return projectID; }
            set { this.projectID = value; }
        }
        private int pO_CompanyID;
        public int PO_CompanyID
        {
            get { return pO_CompanyID; }
            set { this.pO_CompanyID = value; }
        }
        private DateTime pO_StartTime;

        public DateTime PO_StartTime
        {
            get { return pO_StartTime; }
            set { pO_StartTime = value; }
        }
        private DateTime pO_Time1;

        public DateTime PO_Time1
        {
            get { return pO_Time1; }
            set { pO_Time1 = value; }
        }
        private DateTime pO_Time2;

        public DateTime PO_Time2
        {
            get { return pO_Time2; }
            set { pO_Time2 = value; }
        }
        private string pO_Link;

        public string PO_Link
        {
            get { return pO_Link; }
            set { pO_Link = value; }
        }
        private string pO_LinkPhone;

        public string PO_LinkPhone
        {
            get { return pO_LinkPhone; }
            set { pO_LinkPhone = value; }
        }
        private string pO_Name;

        public string PO_Name
        {
            get { return pO_Name; }
            set { pO_Name = value; }
        }
        private string pO_Content;

        public string PO_Content
        {
            get { return pO_Content; }
            set { pO_Content = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string pO_File;
        public string PO_File
        {
            get { return pO_File; }
            set { this.pO_File = value; }
        }
        private double pO_Price;
        public double PO_Price
        {
            get { return pO_Price; }
            set { this.pO_Price = value; }
        }
        private double pO_PricePay;
        public double PO_PricePay
        {
            get { return pO_PricePay; }
            set { this.pO_PricePay = value; }
        }
        private double pO_PriceBill;
        public double PO_PriceBill
        {
            get { return pO_PriceBill; }
            set { this.pO_PriceBill = value; }
        }
        private string pO_FeeType;
        public string PO_FeeType
        {
            get { return pO_FeeType; }
            set { this.pO_FeeType = value; }
        }
        private string pO_Type;
        public string PO_Type
        {
            get { return pO_Type; }
            set { this.pO_Type = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { this.status = value; }
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
            get { return addDate; }
            set { this.addDate = value; }
        }
    }
}

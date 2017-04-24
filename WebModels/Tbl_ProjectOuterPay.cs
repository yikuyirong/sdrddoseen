using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectOuterPay
    {
        public Tbl_ProjectOuterPay ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int alert;
        public int Alert
        {
            get { return alert; }
            set { this.alert = value; }
        }
        private int projectID;
        public int ProjectID
        {
            get{ return projectID; }
            set{ this.projectID=value;}
        }
        private int projectOuterID;
        public int ProjectOuterID
        {
            get{ return projectOuterID; }
            set{ this.projectOuterID=value;}
        }
        private int pOP_Num;
        public int POP_Num
        {
            get{ return pOP_Num; }
            set{ this.pOP_Num=value;}
        }
        private string pOP_MoneyTime;

        public string POP_MoneyTime
        {
            get { return pOP_MoneyTime; }
            set { pOP_MoneyTime = value; }
        }
        private double pOP_Money;
        public double POP_Money
        {
            get{ return pOP_Money; }
            set{ this.pOP_Money=value;}
        }
        private string pOP_Type;

        public string POP_Type
        {
            get { return pOP_Type; }
            set { pOP_Type = value; }
        }
        private double pOP_Price;
        public double POP_Price
        {
            get{ return pOP_Price; }
            set{ this.pOP_Price=value;}
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

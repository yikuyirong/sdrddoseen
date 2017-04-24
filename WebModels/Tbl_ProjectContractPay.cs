using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectContractPay
    {
        public Tbl_ProjectContractPay ()
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
        private int projectContractID;
        public int ProjectContractID
        {
            get{ return projectContractID; }
            set{ this.projectContractID=value;}
        }
        private int pCP_Num;
        public int PCP_Num
        {
            get{ return pCP_Num; }
            set{ this.pCP_Num=value;}
        }
        private string pCP_MoneyTime;

        public string PCP_MoneyTime
        {
            get { return pCP_MoneyTime; }
            set { pCP_MoneyTime = value; }
        }
        private double pCP_Money;
        public double PCP_Money
        {
            get{ return pCP_Money; }
            set{ this.pCP_Money=value;}
        }
        private string pCP_Type;

        public string PCP_Type
        {
            get { return pCP_Type; }
            set { pCP_Type = value; }
        }
        private double pCP_Price;
        public double PCP_Price
        {
            get{ return pCP_Price; }
            set{ this.pCP_Price=value;}
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

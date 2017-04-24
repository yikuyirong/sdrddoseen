using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuyContractPay
    {
        public Tbl_ProjectBuyContractPay ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int projectBuyContractID;
        public int ProjectBuyContractID
        {
            get{ return projectBuyContractID; }
            set{ this.projectBuyContractID=value;}
        }
        private int payNum;
        public int PayNum
        {
            get{ return payNum; }
            set{ this.payNum=value;}
        }
        private double payMoney;
        public double PayMoney
        {
            get{ return payMoney; }
            set{ this.payMoney=value;}
        }
        private double payPrice;
        public double PayPrice
        {
            get{ return payPrice; }
            set{ this.payPrice=value;}
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

using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuilderContractPay
    {
        public Tbl_ProjectBuilderContractPay ()
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
        private int pBCP_Num;
        public int PBCP_Num
        {
            get{ return pBCP_Num; }
            set{ this.pBCP_Num=value;}
        }
        private double pBCP_Money;
        public double PBCP_Money
        {
            get{ return pBCP_Money; }
            set{ this.pBCP_Money=value;}
        }
        private double pBCP_Price;
        public double PBCP_Price
        {
            get{ return pBCP_Price; }
            set{ this.pBCP_Price=value;}
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

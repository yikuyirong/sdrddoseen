using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_ProjectBuilderLog
    {
        public Tbl_ProjectBuilderLog()
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
        private DateTime pBL_Time;

        public DateTime PBL_Time
        {
            get { return pBL_Time; }
            set { pBL_Time = value; }
        }
        private string pBL_Whether;

        public string PBL_Whether
        {
            get { return pBL_Whether; }
            set { pBL_Whether = value; }
        }
        private string pBL_Temperature;

        public string PBL_Temperature
        {
            get { return pBL_Temperature; }
            set { pBL_Temperature = value; }
        }
        private string pBL_Wind;

        public string PBL_Wind
        {
            get { return pBL_Wind; }
            set { pBL_Wind = value; }
        }
        private string pBL_Info1;

        public string PBL_Info1
        {
            get { return pBL_Info1; }
            set { pBL_Info1 = value; }
        }
        private string pBL_Info2;

        public string PBL_Info2
        {
            get { return pBL_Info2; }
            set { pBL_Info2 = value; }
        }
        private string pBL_Info3;

        public string PBL_Info3
        {
            get { return pBL_Info3; }
            set { pBL_Info3 = value; }
        }
        private string pBL_Info1File;

        public string PBL_Info1File
        {
            get { return pBL_Info1File; }
            set { pBL_Info1File = value; }
        }
        private string pBL_Info2File;

        public string PBL_Info2File
        {
            get { return pBL_Info2File; }
            set { pBL_Info2File = value; }
        }
        private string pBL_Info3File;

        public string PBL_Info3File
        {
            get { return pBL_Info3File; }
            set { pBL_Info3File = value; }
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

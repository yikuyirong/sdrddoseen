using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_DesignCorrect
    {
        public Tbl_DesignCorrect()
        {

        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { this.iD = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }
        private int designTaskID;
        public int DesignTaskID
        {
            get { return designTaskID; }
            set { this.designTaskID = value; }
        }
        private int errorNum1;
        public int ErrorNum1
        {
            get { return errorNum1; }
            set { this.errorNum1 = value; }
        }
        private int errorNum2;
        public int ErrorNum2
        {
            get { return errorNum2; }
            set { this.errorNum2 = value; }
        }
        private int errorNum3;
        public int ErrorNum3
        {
            get { return errorNum3; }
            set { this.errorNum3 = value; }
        }
        private string dC_Name;
        public string DC_Name
        {
            get { return dC_Name; }
            set { this.dC_Name = value; }
        }
        private string dC_File;
        public string DC_File
        {
            get { return dC_File; }
            set { this.dC_File = value; }
        }
        private string dC_FileInfo;
        public string DC_FileInfo
        {
            get { return dC_FileInfo; }
            set { this.dC_FileInfo = value; }
        }
        private DateTime dC_FileTime;
        public DateTime DC_FileTime
        {
            get { return dC_FileTime; }
            set { this.dC_FileTime = value; }
        }
        private string dC_File1;
        public string DC_File1
        {
            get { return dC_File1; }
            set { this.dC_File1 = value; }
        }
        private string dC_File1Correct;
        public string DC_File1Correct
        {
            get { return dC_File1Correct; }
            set { this.dC_File1Correct = value; }
        }
        private string dC_File1CorrectInfo;
        public string DC_File1CorrectInfo
        {
            get { return dC_File1CorrectInfo; }
            set { this.dC_File1CorrectInfo = value; }
        }
        private DateTime dC_File1Time;
        public DateTime DC_File1Time
        {
            get { return dC_File1Time; }
            set { this.dC_File1Time = value; }
        }
        private string dC_File2;
        public string DC_File2
        {
            get { return dC_File2; }
            set { this.dC_File2 = value; }
        }
        private string dC_File2Correct;
        public string DC_File2Correct
        {
            get { return dC_File2Correct; }
            set { this.dC_File2Correct = value; }
        }
        private string dC_File2CorrectInfo;
        public string DC_File2CorrectInfo
        {
            get { return dC_File2CorrectInfo; }
            set { this.dC_File2CorrectInfo = value; }
        }
        private DateTime dC_File2Time;
        public DateTime DC_File2Time
        {
            get { return dC_File2Time; }
            set { this.dC_File2Time = value; }
        }
        private string dC_File3;
        public string DC_File3
        {
            get { return dC_File3; }
            set { this.dC_File3 = value; }
        }
        private string dC_File3Correct;
        public string DC_File3Correct
        {
            get { return dC_File3Correct; }
            set { this.dC_File3Correct = value; }
        }
        private string dC_File3CorrectInfo;
        public string DC_File3CorrectInfo
        {
            get { return dC_File3CorrectInfo; }
            set { this.dC_File3CorrectInfo = value; }
        }
        private DateTime dC_File3Time;
        public DateTime DC_File3Time
        {
            get { return dC_File3Time; }
            set { this.dC_File3Time = value; }
        }
        private string dC_File4;
        public string DC_File4
        {
            get { return dC_File4; }
            set { this.dC_File4 = value; }
        }
        private string dC_File4Correct;
        public string DC_File4Correct
        {
            get { return dC_File4Correct; }
            set { this.dC_File4Correct = value; }
        }
        private string dC_File4CorrectInfo;
        public string DC_File4CorrectInfo
        {
            get { return dC_File4CorrectInfo; }
            set { this.dC_File4CorrectInfo = value; }
        }
        private DateTime dC_File4Time;
        public DateTime DC_File4Time
        {
            get { return dC_File4Time; }
            set { this.dC_File4Time = value; }
        }

        private string nodeUser;

        public string NodeUser
        {
            get { return nodeUser; }
            set { nodeUser = value; }
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
    }
}

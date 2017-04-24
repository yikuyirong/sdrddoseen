using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_FlowWorkLog
    {
        public Tbl_FlowWorkLog ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int parentID;
        public int ParentID
        {
            get { return parentID; }
            set { this.parentID = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }
        private string logType;
        public string LogType
        {
            get { return logType; }
            set { this.logType = value; }
        }
        private int projectID;
        public int ProjectID
        {
            get{ return projectID; }
            set{ this.projectID=value;}
        }
        private int flowID;
        public int FlowID
        {
            get{ return flowID; }
            set{ this.flowID=value;}
        }
        private int flowWorkID;
        public int FlowWorkID
        {
            get { return flowWorkID; }
            set { this.flowWorkID = value; }
        }
        private int flowNodeID;
        public int FlowNodeID
        {
            get{ return flowNodeID; }
            set{ this.flowNodeID=value;}
        }
        private string fileLog;

        public string FileLog
        {
            get { return fileLog; }
            set { fileLog = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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

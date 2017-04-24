using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_DesignTask
    {
        public Tbl_DesignTask()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }

        private double paperNum1;
        public double PaperNum1
        {
            get { return paperNum1; }
            set { this.paperNum1 = value; }
        }
        private double paperNum2;
        public double PaperNum2
        {
            get { return paperNum2; }
            set { this.paperNum2 = value; }
        }
        private double paperNum3;
        public double PaperNum3
        {
            get { return paperNum3; }
            set { this.paperNum3 = value; }
        }
        private string correctLevel;
        public string CorrectLevel
        {
            get { return correctLevel; }
            set { correctLevel = value; }
        }
        private string className1;
        public string ClassName1
        {
            get { return className1; }
            set { className1 = value; }
        }

        private string className2;
        public string ClassName2
        {
            get { return className2; }
            set { className2 = value; }
        }

        private string className3;
        public string ClassName3
        {
            get { return className3; }
            set { className3 = value; }
        }
        private int projectID;

        public int ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string projectNo;

        public string ProjectNo
        {
            get { return projectNo; }
            set { projectNo = value; }
        }
        private string designManager;

        public string DesignManager
        {
            get { return designManager; }
            set { designManager = value; }
        }
        private string designMain;

        public string DesignMain
        {
            get { return designMain; }
            set { designMain = value; }
        }
        private string dT_XuHao;

        public string DT_XuHao
        {
            get { return dT_XuHao; }
            set { dT_XuHao = value; }
        }
        private string dT_TuHao;

        public string DT_TuHao
        {
            get { return dT_TuHao; }
            set { dT_TuHao = value; }
        }

        private double dT_GuGong;

        public double DT_GuGong
        {
            get { return dT_GuGong; }
            set { dT_GuGong = value; }
        }
        private string dT_SheJiRen;

        public string DT_SheJiRen
        {
            get { return dT_SheJiRen; }
            set { dT_SheJiRen = value; }
        }
        private DateTime dT_SheJiTime;

        public DateTime DT_SheJiTime
        {
            get { return dT_SheJiTime; }
            set { dT_SheJiTime = value; }
        }
        private string dT_JiaoDuiRen;

        public string DT_JiaoDuiRen
        {
            get { return dT_JiaoDuiRen; }
            set { dT_JiaoDuiRen = value; }
        }
        private DateTime dT_JiaoDuiTime;

        public DateTime DT_JiaoDuiTime
        {
            get { return dT_JiaoDuiTime; }
            set { dT_JiaoDuiTime = value; }
        }
        private string dT_ShenHeRen;

        public string DT_ShenHeRen
        {
            get { return dT_ShenHeRen; }
            set { dT_ShenHeRen = value; }
        }
        private DateTime dT_ShenHeTime;

        public DateTime DT_ShenHeTime
        {
            get { return dT_ShenHeTime; }
            set { dT_ShenHeTime = value; }
        }

        private string dT_ShenDingRen;

        public string DT_ShenDingRen
        {
            get { return dT_ShenDingRen; }
            set { dT_ShenDingRen = value; }
        }
        private DateTime dT_ShenDingTime;

        public DateTime DT_ShenDingTime
        {
            get { return dT_ShenDingTime; }
            set { dT_ShenDingTime = value; }
        }
        private string dT_HeZhunRen;

        public string DT_HeZhunRen
        {
            get { return dT_HeZhunRen; }
            set { dT_HeZhunRen = value; }
        }
        private DateTime dT_HeZhunTime;

        public DateTime DT_HeZhunTime
        {
            get { return dT_HeZhunTime; }
            set { dT_HeZhunTime = value; }
        }
        private DateTime dT_PublishTime;

        public DateTime DT_PublishTime
        {
            get { return dT_PublishTime; }
            set { dT_PublishTime = value; }
        }

        private string nodeUser;

        public string NodeUser
        {
            get { return nodeUser; }
            set { nodeUser = value; }
        }

        private string statusLast;

        public string StatusLast
        {
            get { return statusLast; }
            set { statusLast = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
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
            get{ return dealFlag; }
            set{ this.dealFlag=value;}
        }
        private string dealUser;
        public string DealUser
        {
            get{ return dealUser; }
            set{ this.dealUser=value;}
        }
        private DateTime dealTime;
        public DateTime DealTime
        {
            get{ return dealTime; }
            set{ this.dealTime=value;}
        }
        private DateTime addDate;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

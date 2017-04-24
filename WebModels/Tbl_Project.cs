using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Project
    {
        public Tbl_Project ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }
        private string projectNo;
        public string ProjectNo
        {
            get{ return projectNo; }
            set{ this.projectNo=value;}
        }

        private string projectMW;
        public string ProjectMW
        {
            get { return projectMW; }
            set { this.projectMW = value; }
        }

        private string projectName;
        public string ProjectName
        {
            get{ return projectName; }
            set{ this.projectName=value;}
        }
        private string projectCustomContact;

        public string ProjectCustomContact
        {
            get { return projectCustomContact; }
            set { projectCustomContact = value; }
        }
        private string projectCustomPhone;

        public string ProjectCustomPhone
        {
            get { return projectCustomPhone; }
            set { projectCustomPhone = value; }
        }
        private string projectCustom;
        public string ProjectCustom
        {
            get{ return projectCustom; }
            set{ this.projectCustom=value;}
        }
        private string projectManager;
        public string ProjectManager
        {
            get{ return projectManager; }
            set{ this.projectManager=value;}
        }
        private string projectMainDesigner;

        public string ProjectMainDesigner
        {
            get { return projectMainDesigner; }
            set { projectMainDesigner = value; }
        }
        private DateTime projectStartTime;
        public DateTime ProjectStartTime
        {
            get{ return projectStartTime; }
            set{ this.projectStartTime=value;}
        }
        private DateTime projectEndTime;
        public DateTime ProjectEndTime
        {
            get{ return projectEndTime; }
            set{ this.projectEndTime=value;}
        }
        private string projectTypes;
        public string ProjectTypes
        {
            get{ return projectTypes; }
            set{ this.projectTypes=value;}
        }
        private string projectCity;
        public string ProjectCity
        {
            get{ return projectCity; }
            set{ this.projectCity=value;}
        }
        private string projectLevel;
        public string ProjectLevel
        {
            get{ return projectLevel; }
            set{ this.projectLevel=value;}
        }
        private string projectInfo;
        public string ProjectInfo
        {
            get{ return projectInfo; }
            set{ this.projectInfo=value;}
        }
        private string nodeNo;
        public string NodeNo
        {
            get { return nodeNo; }
            set { this.nodeNo = value; }
        }
        private string nodeUser;
        public string NodeUser
        {
            get { return nodeUser; }
            set { this.nodeUser = value; }
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
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

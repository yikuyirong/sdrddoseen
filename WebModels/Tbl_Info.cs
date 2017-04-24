using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Info
    {
        public Tbl_Info ()
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
            set { userName = value; }
        }
        private string classID;
        public string ClassID
        {
            get { return classID; }
            set { this.classID = value; }
        }
        private string i_Title;
        public string I_Title
        {
            get{ return i_Title; }
            set{ this.i_Title=value;}
        }
        private string i_Keyword;
        public string I_Keyword
        {
            get{ return i_Keyword; }
            set{ this.i_Keyword=value;}
        }
        private string i_Description;
        public string I_Description
        {
            get{ return i_Description; }
            set{ this.i_Description=value;}
        }
        private string i_Content;
        public string I_Content
        {
            get{ return i_Content; }
            set{ this.i_Content=value;}
        }
        private string i_Pic;
        public string I_Pic
        {
            get { return i_Pic; }
            set { this.i_Pic = value; }
        }
        private string i_File;
        public string I_File
        {
            get{ return i_File; }
            set{ this.i_File=value;}
        }
        private string i_Type;

        public string I_Type
        {
            get { return i_Type; }
            set { i_Type = value; }
        }
        private int orderNum;
        public int OrderNum
        {
            get{ return orderNum; }
            set{ this.orderNum=value;}
        }
        private string userNameTo;
        public string UserNameTo
        {
            get { return userNameTo; }
            set { this.userNameTo = value; }
        }
        private string nodeStatus;

        public string NodeStatus
        {
            get { return nodeStatus; }
            set { nodeStatus = value; }
        }
        private string status;
        public string Status
        {
            get{ return status; }
            set{ this.status=value;}
        }
        private string nodeUser;

        public string NodeUser
        {
            get { return nodeUser; }
            set { nodeUser = value; }
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

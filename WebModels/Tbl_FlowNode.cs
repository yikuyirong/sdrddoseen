using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_FlowNode
    {
        public Tbl_FlowNode()
        {

        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { this.iD = value; }
        }
        private int flowID;
        public int FlowID
        {
            get { return flowID; }
            set { this.flowID = value; }
        }
        private string nodeNo;
        public string NodeNo
        {
            get { return nodeNo; }
            set { nodeNo = value; }
        }
        private string nodeName;
        public string NodeName
        {
            get { return nodeName; }
            set { nodeName = value; }
        }
        private string nodeStage;
        public string NodeStage
        {
            get { return nodeStage; }
            set { nodeStage = value; }
        }
        private string nodeType;

        public string NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        
        private string nodeUser;
        public string NodeUser
        {
            get { return nodeUser; }
            set { nodeUser = value; }
        }
        private string nodeUserLimit;

        public string NodeUserLimit
        {
            get { return nodeUserLimit; }
            set { nodeUserLimit = value; }
        }

        private int dealFlag;

        public int DealFlag
        {
            get { return dealFlag; }
            set { dealFlag = value; }
        }
        private string dealUser;

        public string DealUser
        {
            get { return dealUser; }
            set { dealUser = value; }
        }
        private DateTime dealTime;

        public DateTime DealTime
        {
            get { return dealTime; }
            set { dealTime = value; }
        }
        //private string nodeFormArea;
        //public string NodeFormArea
        //{
        //    get { return nodeFormArea; }
        //    set { nodeFormArea = value; }
        //}
        private DateTime addDate;
        public DateTime AddDate
        {
            get { return addDate; }
            set { this.addDate = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Flow
    {
        public Tbl_Flow ()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private int formID;

        public int FormID
        {
            get { return formID; }
            set { formID = value; }
        }
        private string formContent;

        public string FormContent
        {
            get { return formContent; }
            set { formContent = value; }
        }
        private string flowType;

        public string FlowType
        {
            get { return flowType; }
            set { flowType = value; }
        }
        private string flowName;
        public string FlowName
        {
            get{ return flowName; }
            set{ this.flowName=value;}
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string dealFlag;

        public string DealFlag
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
        private DateTime addDate;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

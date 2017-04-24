using System;
using System.Collections.Generic;
using System.Text;

namespace WebModels
{
   public class Tbl_FlowWork
    {
       public Tbl_FlowWork() { }
       private int iD;

       public int ID
       {
           get { return iD; }
           set { iD = value; }
       }
       private string userName;

       public string UserName
       {
           get { return userName; }
           set { userName = value; }
       }
       private string workName;

       public string WorkName
       {
           get { return workName; }
           set { workName = value; }
       }
       private int projectID;

       public int ProjectID
       {
           get { return projectID; }
           set { projectID = value; }
       }
       private int flowID;

       public int FlowID
       {
           get { return flowID; }
           set { flowID = value; }
       }
       private string formContent;

       public string FormContent
       {
           get { return formContent; }
           set { formContent = value; }
       }
       private int nodeID;

       public int NodeID
       {
           get { return nodeID; }
           set { nodeID = value; }
       }
       private string nodeNo;

       public string NodeNo
       {
           get { return nodeNo; }
           set { nodeNo = value; }
       }
       private string nodeUser;

       public string NodeUser
       {
           get { return nodeUser; }
           set { nodeUser = value; }
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
           get { return status; }
           set { status = value; }
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
       private DateTime addDate;

       public DateTime AddDate
       {
           get { return addDate; }
           set { addDate = value; }
       }
    }
}

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignTask_Upload : System.Web.UI.Page
    {
        public string EndNode = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CID = WebCommon.Public.ToInt(Request.QueryString["cid"]);
                int TaskID = WebCommon.Public.ToInt(Request.QueryString["id"]);
                if (CID > 0)
                {
                    TaskID = WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(CID).DesignTaskID;
                }
                WebModels.Tbl_DesignTask task=WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(TaskID);
                string ClickType = WebCommon.Public.ToString(Request.QueryString["type"]);
                EndNode = "shenhe";
                if (task.DT_ShenDingRen != "") EndNode = "shending";
                if (ClickType == EndNode)
                {
                    WebModels.Tbl_DesignCorrect model=WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(CID);
                    ErrorNum1.Value = model.ErrorNum1.ToString();
                    ErrorNum2.Value = model.ErrorNum2.ToString();
                    ErrorNum3.Value = model.ErrorNum3.ToString();
                }
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            int CID = WebCommon.Public.ToInt(Request.QueryString["cid"]);
            int TaskID = WebCommon.Public.ToInt(Request.QueryString["id"]);
            if (CID > 0)
            {
                TaskID = WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(CID).DesignTaskID;
            }
            string ClickType = WebCommon.Public.ToString(Request.QueryString["type"]);
            string ActStr = "";
            string FileStr = "";
            switch (ClickType)
            {
                case "sheji":
                    ActStr = "校对";
                    FileStr = "设计";
                    break;
                case "jiaodui":
                    ActStr = "会签";
                    if (CorrectInfo.Value != "") ActStr = "设计";
                    FileStr = "校对";
                    break;
                case "huiqian":
                    ActStr = "会签";
                    if (CorrectInfo.Value != "") ActStr = "设计";
                    FileStr = "审核";
                    break;
                case "shenhe":
                    ActStr = "审定";
                    if (CorrectInfo.Value != "") ActStr = "设计";
                    FileStr = "审核";
                    break;
            }
            string FullName = WebCommon.Public.UploadFile(FileUrl, WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTasFileFullNamekByTaskId(TaskID) + " - " + FileStr + FileUrl.FileName.Remove(0, FileUrl.FileName.LastIndexOf(".")));

            string StatusStr = "等待";
            if (FullName !="")
            {
                FullName = FullName.Replace("../","/");
                WebModels.Tbl_DesignTask model = WebBLL.Tbl_DesignTaskManager.GetTbl_DesignTaskById(TaskID);
                StatusStr += ActStr;
                switch (ClickType)
                {
                    case "sheji":
                        model.NodeUser = model.DT_JiaoDuiRen;
                            if (model.StatusLast.Contains("校对")) model.NodeUser = model.DT_JiaoDuiRen;
                            if (model.StatusLast.Contains("审核")) model.NodeUser = model.DT_ShenHeRen;
                            if (model.StatusLast.Contains("审定")) model.NodeUser = model.DT_ShenDingRen;
                            if (model.StatusLast.Contains("会签")) model.NodeUser = model.DealUser;
                            if (model.StatusLast!="") StatusStr = model.StatusLast;
                        break;
                    case "jiaodui":
                        model.NodeUser = model.DT_SheJiRen;
                        if (CorrectInfo.Value != "")
                        {
                            model.NodeUser = model.DT_SheJiRen;
                            model.StatusLast = "等待校对";
                            StatusStr = "等待设计";
                        }
                        break;
                    case "shenhe":
                        model.NodeUser = model.DT_ShenDingRen;
                        if (CorrectInfo.Value != "")
                        {
                            model.NodeUser = model.DT_SheJiRen;
                            model.StatusLast = "等待审核";
                            StatusStr = "等待设计";
                        }
                        else
                        {
                            if (model.DT_ShenDingRen == "")
                            {
                                StatusStr = "结束";
                            }
                            else
                            {
                                model.NodeUser = model.DT_ShenDingRen;
                                StatusStr = "等待审定";
                            }
                        }
                        break;
                    case "shending":
                        model.NodeUser = model.DT_SheJiRen;
                        if (CorrectInfo.Value != "")
                        {
                            model.NodeUser = model.DT_SheJiRen;
                            model.StatusLast = "等待审定";
                            StatusStr = "等待设计";
                        }
                        else
                        {
                            StatusStr = "结束";
                        }
                        break;
                    case "huiqian":
                        model.NodeUser = model.DT_JiaoDuiRen;
                        if (CorrectInfo.Value != "")
                        {
                            model.NodeUser = model.DT_SheJiRen;
                            model.StatusLast = "等待会签";
                            StatusStr = "等待设计";
                        }
                        else
                        {
                            model.NodeUser = model.DT_SheJiRen;
                            StatusStr = "等待会签";
                        }
                        break;
                }
                model.Status = StatusStr;
                int count=WebBLL.Tbl_DesignTaskManager.UpdateTbl_DesignTask(model);
                if(count>0)
                {
                    int count1 = 0;
                    if (ClickType == "sheji" && model.StatusLast=="")
                    {
                        WebModels.Tbl_DesignCorrect correct = new WebModels.Tbl_DesignCorrect();
                        correct.UserName = WebCommon.Public.GetUserName();
                        correct.DesignTaskID = Convert.ToInt32(TaskID);
                        correct.DC_Name = "";
                        correct.DC_File = FullName;
                        correct.DC_FileInfo = Correct.Value ;
                        correct.DC_FileTime = DateTime.Now;
                        correct.NodeUser = model.NodeUser;
                        correct.Status = StatusStr;
                        count1 = WebBLL.Tbl_DesignCorrectManager.AddTbl_DesignCorrect(correct);
                    }
                    else
                    {
                        if (ClickType == "sheji")
                        {
                            CID = WebCommon.Public.ToInt(WebBLL.Tbl_DesignCorrectManager.GetDataTableByPage(1,1,"designtaskid=" + TaskID.ToString(),"").Rows[0][0]);
                        }
                        
                        WebModels.Tbl_DesignCorrect correct = WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(CID);
                        switch (ClickType)
                        {
                            case "sheji":
                                correct.DC_File = FullName;
                                if (model.StatusLast.Contains("校对")) correct.DC_File1Correct += Correct.Value+"<br>";
                                if (model.StatusLast.Contains("审核")) correct.DC_File2Correct += Correct.Value + "<br>";
                                if (model.StatusLast.Contains("审定")) correct.DC_File3Correct += Correct.Value + "<br>";
                                if (model.StatusLast.Contains("会签")) correct.DC_File4Correct += Correct.Value + "<br>";
                                StatusStr = model.StatusLast;
                                break;
                            case "jiaodui":
                                correct.DC_File1 = FullName;
                                correct.DC_File1CorrectInfo += CorrectInfo.Value + "<br>";
                                break;
                            case "shenhe":
                                correct.DC_File2 = FullName;
                                correct.DC_File2CorrectInfo += CorrectInfo.Value + "<br>";
                                //更新评级
                                if (model.DT_ShenDingRen=="") WebCommon.Public.ExcuteSql("update tbl_designtask set PaperNum1=" + PaperNum1.Text + ",PaperNum2=" + PaperNum2.Text + ",PaperNum3=" + PaperNum3.Text + ",CorrectLevel='" + CorrectLevel.Text + "' where id=" + TaskID.ToString());
                                break;
                            case "shending":
                                correct.DC_File3 = FullName;
                                correct.DC_File3CorrectInfo += CorrectInfo.Value + "<br>";
                                //更新评级
                                if (model.DT_ShenDingRen != "") WebCommon.Public.ExcuteSql("update tbl_designtask set PaperNum1=" + PaperNum1.Text + ",PaperNum2=" + PaperNum2.Text + ",PaperNum3=" + PaperNum3.Text + ",CorrectLevel='" + CorrectLevel.Text + "' where id=" + TaskID.ToString());
                                break;
                            case "huiqian":
                                correct.DC_File4 = FullName;
                                correct.DC_File4CorrectInfo += CorrectInfo.Value + "<br>";
                                break;
                        }
                        correct.DC_FileTime = DateTime.Now;
                        correct.ErrorNum1 += WebCommon.Public.ToInt(ErrorNum1.Value);
                        correct.ErrorNum2 += WebCommon.Public.ToInt(ErrorNum2.Value);
                        correct.ErrorNum3 += WebCommon.Public.ToInt(ErrorNum3.Value);
                        correct.NodeUser = model.NodeUser;
                        correct.Status = StatusStr;
                        count1 = WebBLL.Tbl_DesignCorrectManager.UpdateTbl_DesignCorrect(correct);
                        if (correct.Status == "结束")
                        {
                            WebModels.Tbl_ProjectArchive archive = new WebModels.Tbl_ProjectArchive();
                            archive.ProjectID = model.ProjectID;
                            archive.ClassName1 = model.ClassName1;
                            archive.ClassName2 = model.ClassName2;
                            archive.ClassName3 = model.ClassName3;
                            archive.PA_Type1 = "项目档案";
                            archive.PA_Type2 = "电子版";
                            archive.ParentID = 0;
                            archive.PA_Limit = "普通";
                            archive.PA_Name = model.ClassName3;
                            archive.PA_File = correct.DC_File;
                            archive.PA_FileNo = "";
                            archive.PA_Info = "项目流程自动存档";
                            archive.Status = "已审核";
                            archive.DealUser = WebCommon.Public.GetUserName();
                            WebBLL.Tbl_ProjectArchiveManager.AddTbl_ProjectArchive(archive);
                        }
                    }
                    if (count1 > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('上传成功!');window.external.reload();window.external.close();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('写入失败2!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('写入失败1!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('上传失败!');", true);
            }
        }
    }
}
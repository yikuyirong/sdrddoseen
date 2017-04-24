using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class DesignCorrect_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            //int ID = Convert.ToInt32(Request.QueryString["id"]);
            //WebModels.Tbl_DesignCorrect correct = WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(ID);
            //WebCommon.Public.ListBoxValuesSet(UserNameTo,correct.UserNameTo);
            //this.ProjectID.SelectedValue = correct.ProjectId.ToString();
            //this.DC_Name.Value = correct.Dc_Name;
            //this.DC_FileInfo1.InnerText = correct.Dc_File1Info1;
            //this.DC_FileInfo2.InnerText = correct.Dc_FileInfo2;
            //this.CorrectInfo.Value = correct.CorrectInfo;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string type = WebCommon.Public.ToString(Request.QueryString["type"]);
            int taskid = WebCommon.Public.ToInt(Request.QueryString["taskid"]);
            WebModels.Tbl_DesignCorrect correct = WebBLL.Tbl_DesignCorrectManager.GetTbl_DesignCorrectById(taskid);
            //判断文件格式
            if (!DC_File.FileName.Contains(" - " + type))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('您修改后的文件名不正确!');", true);
                return;
            }
            if (!DC_FileCorrect.FileName.Contains(" - " + type))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('自动校审结果DWG文件名不正确!');", true);
                return;
            }
            if (!CorrectTxt.FileName.Contains(" - " + type))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('自动校审结果TXT文件名不正确!');", true);
                return;
            }
            //获取对比txt到字段
            string txtPath = WebCommon.Public.UploadFile(CorrectTxt, "DesignCorrect", CorrectTxt.FileName.Split('.')[0]);
            string txtMapPath = Server.MapPath(txtPath);
            string DCFileCorrectInfo = WebCommon.Public.GetHtml(txtMapPath);
            string status = DCFileCorrectInfo.Substring(0, 2);
            //获取其他信息
            string DCFile = WebCommon.Public.UploadFile(DC_File, "DesignCorrect", DC_File.FileName.Split('.')[0]);
            string DCFileCorrect = WebCommon.Public.UploadFile(DC_FileCorrect, "DesignCorrect", DC_FileCorrect.FileName.Split('.')[0]);
            switch(type)
            {
                case "校对":
                    correct.DC_File1 = DCFile;
                    correct.DC_File1Correct = DCFileCorrect;
                    correct.DC_File1CorrectInfo = DCFileCorrectInfo;
                    if (status == "通过")
                    {
                        correct.Status = "等待审核";
                    }
                    else
                    {
                        correct.Status = "校对不过";
                    }
                    break;
                case "审核":
                    correct.DC_File2 = DCFile;
                    correct.DC_File2Correct = DCFileCorrect;
                    correct.DC_File2CorrectInfo = DCFileCorrectInfo;
                    if (status == "通过")
                    {
                        correct.Status = "等待审定";
                    }
                    else
                    {
                        correct.Status = "审核不过";
                    }
                    break;
                case "审定":
                    correct.DC_File3 = DCFile;
                    correct.DC_File3Correct = DCFileCorrect;
                    correct.DC_File3CorrectInfo = DCFileCorrectInfo;
                    if (status == "通过")
                    {
                        correct.Status = "审定通过";
                    }
                    else
                    {
                        correct.Status = "审定不过";
                    }
                    break;
                case "核准"://暂时项目不走这个流程
                    correct.DC_File4 = DCFile;
                    correct.DC_File4Correct = DCFileCorrect;
                    correct.DC_File4CorrectInfo = DCFileCorrectInfo;
                    break;
            }
            correct.DealUser =WebCommon.Public.GetUserName();
            int count = WebBLL.Tbl_DesignCorrectManager.UpdateTbl_DesignCorrect(correct);
            if (count > 0)
            {
                //如果审定通过文件保存到设计版本库
                string alertStr = "";
                if (correct.Status == "审定通过")
                {
                    try
                    {
                        WebModels.Tbl_DesignVersion version = new WebModels.Tbl_DesignVersion();
                        version.UserName = WebCommon.Public.GetUserName();
                        version.DesignTaskID = correct.DesignTaskID;
                        version.CadFile = correct.DC_File3;
                        version.Remark = "";
                        version.DealUser = version.UserName;
                        int num = WebBLL.Tbl_DesignVersionManager.AddTbl_DesignVersion(version);
                        if (num > 0) alertStr = "并成功提交到版本库";
                    }
                    catch
                    {
                        alertStr = "但是提交到版本库失败";
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功" + alertStr + "!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交失败!');", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string txtPath = WebCommon.Public.UploadFile(CorrectTxt, "DesignCorrect");
            string txtMapPath = Server.MapPath(txtPath);
            DC_FileCorrectInfo.Value = WebCommon.Public.GetHtml(txtMapPath);
        }
    }
}
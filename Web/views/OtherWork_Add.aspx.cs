﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class OtherWork_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定项目              
                ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectAll();
                ProjectID.DataTextField = "ProjectName";
                ProjectID.DataValueField = "ID";
                ProjectID.DataBind();
                ProjectID.Items.Insert(0, new ListItem("其他项目", "其他项目"));

                //专业
                ClassName.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName.DataTextField = "ClassName";
                ClassName.DataValueField = "ClassName";
                ClassName.DataBind();
                ClassName.Items.Insert(0, new ListItem("选择专业", ""));

                WorkType.Items.Add(new ListItem("司令图工日", "司令图工日"));
                WorkType.Items.Add(new ListItem("辅助工日", "辅助工日"));
                WorkType.Items.Add(new ListItem("归档工日", "归档工日"));
                WorkType.Items.Add(new ListItem("出差工日", "出差工日"));
                WorkType.Items.Add(new ListItem("投标工日", "投标工日"));
                WorkType.Items.Add(new ListItem("初设工日", "初设工日"));
                WorkType.Items.Add(new ListItem("咨询工日", "咨询工日"));
                WorkType.Items.Add(new ListItem("其他", "其他"));

                //遍历绑定人员列表
                WebBLL.Tbl_UserManager.GetUsersByListBox(NodeUser);

                UserName.Text = WebCommon.Public.GetUserName();
                UserName.Enabled = false;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_OtherWork model = new WebModels.Tbl_OtherWork();

            model.ProjectID = Convert.ToInt32(this.ProjectID.Text);
            model.ProjectName = Convert.ToString(this.ProjectID.SelectedItem.Text);
            model.UserName = Convert.ToString(this.UserName.Text);
            model.WorkType = Convert.ToString(this.WorkType.Text);
            model.WorkDay = Convert.ToString(this.WorkDay.Text);
            model.WorkInfo = Convert.ToString(this.WorkInfo.Text);
            model.NodeUser = Convert.ToString(this.NodeUser.Text);
            model.Status = "未审核";
            model.DealUser = WebCommon.Public.GetUserName();
            model.DealFlag = 0;
            model.DealTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            model.AddDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            int count = WebBLL.Tbl_OtherWorkManager.AddTbl_OtherWork(model);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加成功!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('添加失败!');", true);
            }
        }
    }
}
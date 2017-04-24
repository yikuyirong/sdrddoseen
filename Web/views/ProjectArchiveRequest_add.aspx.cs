using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.views
{
    public partial class ProjectArchiveRequest_add : System.Web.UI.Page
    {
        public string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = Request.QueryString["limit"];
                if (Title == "借阅申请")
                {
                    this.RequestType.SelectedValue = "借阅申请";
                }
                else
                {
                    this.RequestType.SelectedValue = "出版申请";
                }
                //项目类别
                ProjectType.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(56);
                ProjectType.DataTextField = "ClassName";
                ProjectType.DataValueField = "ClassName";
                ProjectType.DataBind();
                ProjectType.Items.Insert(0, new ListItem("选择项目类别", ""));
                ProjectID.Items.Insert(0, new ListItem("选择项目", ""));
                //专业
                ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(15);
                ClassName1.DataTextField = "ClassName";
                ClassName1.DataValueField = "ID";
                ClassName1.DataBind();
                ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
                //卷册
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
                ClassName3.Items.Insert(0, new ListItem("选择册", ""));
                PA_Name.Items.Insert(0, new ListItem("选择档案", ""));

                //如果通过借阅查询列表点过来的借阅
                //int ID = Convert.ToInt32(Request.QueryString["aid"]);
                //if (ID > 0)
                //{
                //    WebModels.Tbl_ProjectArchiveRequest project = WebBLL.Tbl_ProjectArchiveRequestManager.GetTbl_ProjectArchiveRequestById(ID);
                //    this.ProjectID.SelectedValue = project.ProjectID.ToString();
                //    this.PA_Name.SelectedValue = project.ProjectArchiveID.ToString();
                //    this.Remark.InnerText = project.Remark;
                //    this.RequestType.SelectedValue = project.RequestType;
                //    this.Status.SelectedValue = project.Status;
                //    PA_Type2.SelectedValue = project.PA_Type2;
                //}
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WebModels.Tbl_ProjectArchiveRequest archive = new WebModels.Tbl_ProjectArchiveRequest();
            archive.ProjectID = Convert.ToInt32(this.ProjectID.SelectedValue);
            archive.ClassName1 = this.ClassName1.SelectedItem.Text;
            archive.ClassName2 = this.ClassName2.SelectedItem.Text;
            archive.ClassName3 = this.ClassName3.SelectedValue;
            archive.PA_Type1 = this.PA_Type1.SelectedItem.Text;
            archive.PA_Type2 = this.PA_Type2.SelectedItem.Text;
            if (this.PA_Name.SelectedValue == "选择档案" || this.PA_Name.SelectedValue == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('该专业卷册无档案，请重新选择!');", true);
                //return;
                archive.ProjectArchiveID = 0;
            }
            else
            {
                archive.ProjectArchiveID = Convert.ToInt32(this.PA_Name.SelectedValue);
            }
            archive.Remark = this.Remark.Value;//申请用途
            archive.RequestType = this.RequestType.SelectedValue;
            if (archive.RequestType == "借阅申请")
            {
                if (archive.PA_Type1 == "项目档案")
                {
                    if (archive.ClassName3 == "")
                    {
                        archive.NodeNo = "技术院长审批";
                        archive.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set5;
                    }
                    else
                    {
                        archive.NodeNo = "室主任审批";
                        archive.NodeUser = WebBLL.Tbl_ClassManager.GetDataTableByPage(1, 1, "classname='" + archive.ClassName1 + "' and parentid=15", "").Rows[0]["Status"].ToString();
                    }
                }
                else
                {
                    archive.NodeNo = "档案管理员审批";
                    archive.NodeUser = WebBLL.Tbl_ConfigManager.GetTbl_ConfigById(1).C_Set1;
                }
            }
            else if (archive.RequestType == "出版申请")
            {
                archive.NodeNo = "设总审批";
                archive.NodeUser = WebBLL.Tbl_ProjectManager.GetTbl_ProjectById(archive.ProjectID).ProjectMainDesigner;
            }
            archive.Status = this.Status.SelectedValue;
            archive.UserName = WebCommon.Public.GetUserName();
            archive.DealUser = archive.UserName;
            int count = WebBLL.Tbl_ProjectArchiveRequestManager.AddTbl_ProjectArchiveRequest(archive);
            if (count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交成功,请等待审核!');window.external.reload();window.external.close();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('提交失败!');", true);
            }
        }

        protected void ProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectID.DataSource = WebBLL.Tbl_ProjectManager.GetTbl_ProjectByProjectTypes(this.ProjectType.SelectedValue);
            ProjectID.DataTextField = "ProjectName";
            ProjectID.DataValueField = "ID";
            ProjectID.DataBind();
            ProjectID.Items.Insert(0, "选择项目");
        }

        protected void ClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PA_Type1.SelectedValue == "项目档案")
            {
                //卷
                ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
                ClassName2.DataTextField = "ClassName";
                ClassName2.DataValueField = "ClassName";
                ClassName2.DataBind();
                ClassName2.Items.Insert(0, new ListItem("选择卷", ""));
            }
            else
            {
                //二级分类
                ClassName2.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName1.SelectedValue));
                ClassName2.DataTextField = "ClassName";
                ClassName2.DataValueField = "ID";
                ClassName2.DataBind();
                ClassName2.Items.Insert(0, new ListItem("二级分类", ""));
            }
        }

        protected void ClassName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PA_Type1.SelectedValue == "项目档案")
            {
                //册
                ClassName3.DataSource = WebBLL.Tbl_DesignVolumeManager.GetDataTableByPage(100, 1, "classname2='" + this.ClassName2.SelectedValue + "'", "");
                ClassName3.DataTextField = "VolumeName";
                ClassName3.DataValueField = "VolumeNo";
                ClassName3.DataBind();
                ClassName3.Items.Insert(0, new ListItem("选择册", ""));
            }
            else
            {
                //三级分类
                ClassName3.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(Convert.ToInt32(this.ClassName2.SelectedValue));
                ClassName3.DataTextField = "ClassName";
                ClassName3.DataValueField = "ID";
                ClassName3.DataBind();
                ClassName3.Items.Insert(0, new ListItem("三级分类", ""));
            }
            //PA_Name.Value = this.ClassName3.SelectedValue;
        }

        protected void ClassName3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //选择档案
            PA_Name.DataSource = WebBLL.Tbl_ProjectArchiveManager.GetTbl_ProjectArchiveParentName(" classname1='" + this.ClassName1.SelectedItem.Text + "' and classname2='" + this.ClassName2.SelectedItem.Text + "' and classname3='" + this.ClassName3.SelectedItem.Text + "'");
            PA_Name.DataTextField = "PA_Name";
            PA_Name.DataValueField = "ID";
            PA_Name.DataBind();
            PA_Name.Items.Insert(0, new ListItem("选择档案", ""));
        }


        //如果选择了公共档案
        protected void PA_Type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetTbl_ClassByParentID(227);
            ClassName1.DataTextField = "ClassName";
            ClassName1.DataValueField = "ID";
            ClassName1.DataBind();
            ClassName1.Items.Insert(0, new ListItem("一级分类", ""));
            ClassName2.Items[0].Text = "二级分类";
            ClassName3.Items[0].Text = "三级分类";
        }

        protected void ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassName1.DataSource = WebBLL.Tbl_ClassManager.GetDataTableByPage(20, 1, "parentid=15 and classname in(select classname from tbl_projectdesigner where projectid=" + ProjectID.SelectedValue + ")", "");
            ClassName1.DataTextField = "ClassName";
            ClassName1.DataValueField = "ID";
            ClassName1.DataBind();
            ClassName1.Items.Insert(0, new ListItem("选择专业", ""));
        }
    }
}
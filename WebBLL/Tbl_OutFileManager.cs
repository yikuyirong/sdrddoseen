using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
using System.Data;

namespace WebBLL
{

    
    public class Tbl_OutFileManager
    {
        public static int AddTbl_OutFile(Tbl_OutFile tbl_outfile)
        {
            WebCommon.Public.WriteLog("添加外来资料：" + WebCommon.Public.CutStr(tbl_outfile.ProjectID.ToString() + "|" + tbl_outfile.ClassName.ToString() + "|" + tbl_outfile.FileName.ToString() + "|" + tbl_outfile.FileUrl.ToString() + "|" + tbl_outfile.FileInfo.ToString() + "|" + tbl_outfile.DealUser.ToString() + "|" + tbl_outfile.DealFlag.ToString() + "|" + tbl_outfile.DealTime.ToString() + "|" + tbl_outfile.AddDate.ToString() + "|" + "",100));
            return new Tbl_OutFileService().AddTbl_OutFile(tbl_outfile);
        }

        public static int UpdateTbl_OutFile(Tbl_OutFile tbl_outfile)
        {
            WebCommon.Public.WriteLog("修改外来资料：" + WebCommon.Public.CutStr(tbl_outfile.ProjectID.ToString() + "|" + tbl_outfile.ClassName.ToString() + "|" + tbl_outfile.FileName.ToString() + "|" + tbl_outfile.FileUrl.ToString() + "|" + tbl_outfile.FileInfo.ToString() + "|" + tbl_outfile.DealUser.ToString() + "|" + tbl_outfile.DealFlag.ToString() + "|" + tbl_outfile.DealTime.ToString() + "|" + tbl_outfile.AddDate.ToString() + "|" + "",100));
            return new Tbl_OutFileService().UpdateTbl_OutFileById(tbl_outfile);
        }

        public static int DeleteTbl_OutFile(int ID)
        {
            Tbl_OutFile tbl_outfile = GetTbl_OutFileById(ID);
            WebCommon.Public.WriteLog("删除外来资料：" + WebCommon.Public.CutStr(tbl_outfile.ProjectID.ToString() + "|" + tbl_outfile.ClassName.ToString() + "|" + tbl_outfile.FileName.ToString() + "|" + tbl_outfile.FileUrl.ToString() + "|" + tbl_outfile.FileInfo.ToString() + "|" + tbl_outfile.DealUser.ToString() + "|" + tbl_outfile.DealFlag.ToString() + "|" + tbl_outfile.DealTime.ToString() + "|" + tbl_outfile.AddDate.ToString() + "|" + "",100));
            return new Tbl_OutFileService().DeleteTbl_OutFileById(ID);
        }

        public static Tbl_OutFile GetTbl_OutFileById(int ID)
        {
            return new Tbl_OutFileService().GetTbl_OutFileById(ID);
        }

        public static IList<Tbl_OutFile> GetTbl_OutFileAll()
        {
            return new Tbl_OutFileService().GetTbl_OutFileAll();
        }

        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_OutFileService().GetDataTableByCount(Where);
        }

        public static DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_OutFileService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}

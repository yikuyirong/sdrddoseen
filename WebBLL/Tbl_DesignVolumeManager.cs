using System;
using System.Collections.Generic;
using System.Text;
using WebDAL;
using WebModels;
namespace WebBLL
{

    
    public static class Tbl_DesignVolumeManager
    {
        public static int AddTbl_DesignVersion(Tbl_DesignVolume tbl_designvolume)
        {
            WebCommon.Public.WriteLog("Ìí¼Ó¾í²á£º" + tbl_designvolume.VolumeName);
            return new Tbl_DesignVolumeService().AddTbl_DesignVolume(tbl_designvolume);
        }

        public static int UpdateTbl_DesignVolume(Tbl_DesignVolume tbl_designvolume)
        {
            WebCommon.Public.WriteLog("ÐÞ¸Ä¾í²á£º" + tbl_designvolume.VolumeName);
            tbl_designvolume.DealUser = WebCommon.Public.GetUserName();
            tbl_designvolume.DealTime = DateTime.Now;
            return new Tbl_DesignVolumeService().UpdateTbl_DesignVolumeById(tbl_designvolume);
        }

        public static int DeleteTbl_DesignVolume(int ID)
        {
            WebCommon.Public.WriteLog("É¾³ý¾í²á£º" + ID.ToString());
            return new Tbl_DesignVolumeService().DeleteTbl_DesignVolumeById(ID);
        }

        public static Tbl_DesignVolume GetTbl_DesignVolumeById(int ID)
        {
            return new Tbl_DesignVolumeService().GetTbl_DesignVolumeById(ID);
        }

        public static IList<Tbl_DesignVolume> GetTbl_DesignVolumeAll()
        {
            return new Tbl_DesignVolumeService().GetTbl_DesignVolumeAll();
        }
        public static int GetDataTableByCount(string Where)
        {
            return new Tbl_DesignVolumeService().GetDataTableByCount(Where);
        }

        public static System.Data.DataTable GetDataTableByPage(int PageSize, int PageIndex, string Where, string Order)
        {
            return new Tbl_DesignVolumeService().GetDataTableByPage(PageSize, PageIndex, Where, Order);
        }
    }
}

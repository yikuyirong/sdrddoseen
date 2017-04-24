using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_Disk
    {
        public Tbl_Disk()
        {

        }

        private Int32 ID_;
        public Int32 ID
        {
            get { return ID_; }
            set { this.ID_ = value; }
        }

        private String D_Class_;
        public String D_Class
        {
            get { return D_Class_; }
            set { this.D_Class_ = value; }
        }

        private String D_Title_;
        public String D_Title
        {
            get { return D_Title_; }
            set { this.D_Title_ = value; }
        }

        private String D_File_;
        public String D_File
        {
            get { return D_File_; }
            set { this.D_File_ = value; }
        }

        private String Remark_;
        public String Remark
        {
            get { return Remark_; }
            set { this.Remark_ = value; }
        }

        private String DealUser_;
        public String DealUser
        {
            get { return DealUser_; }
            set { this.DealUser_ = value; }
        }

        private Int32 DealFlag_;
        public Int32 DealFlag
        {
            get { return DealFlag_; }
            set { this.DealFlag_ = value; }
        }

        private DateTime DealTime_;
        public DateTime DealTime
        {
            get { return DealTime_; }
            set { this.DealTime_ = value; }
        }

        private DateTime AddDate_;
        public DateTime AddDate
        {
            get { return AddDate_; }
            set { this.AddDate_ = value; }
        }

    }
}

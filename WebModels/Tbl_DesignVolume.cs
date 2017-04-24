using System;
using System.Collections.Generic;
using System.Text;
namespace WebModels
{
    [Serializable]
    public class Tbl_DesignVolume
    {
        public Tbl_DesignVolume()
        {

        }
        private int iD;
        public int ID
        {
            get{ return iD; }
            set{ this.iD=value;}
        }
        private string className1;

        public string ClassName1
        {
            get { return className1; }
            set { className1 = value; }
        }
        private string className2;

        public string ClassName2
        {
            get { return className2; }
            set { className2 = value; }
        }
        private string className3;

        public string ClassName3
        {
            get { return className3; }
            set { className3 = value; }
        }
        private string volumeNo;

        public string VolumeNo
        {
            get { return volumeNo; }
            set { volumeNo = value; }
        }
        private string volumeName;

        public string VolumeName
        {
            get { return volumeName; }
            set { volumeName = value; }
        }
        private int volume25MW;

        public int Volume25MW
        {
            get { return volume25MW; }
            set { volume25MW = value; }
        }
        private int volume50MW;

        public int Volume50MW
        {
            get { return volume50MW; }
            set { volume50MW = value; }
        }
        private string volumeLevel;
        public string VolumeLevel
        {
            get { return volumeLevel; }
            set { this.volumeLevel = value; }
        }
        private string remark;
        public string Remark
        {
            get{ return remark; }
            set{ this.remark=value;}
        }
        private int dealFlag;
        public int DealFlag
        {
            get { return dealFlag; }
            set { this.dealFlag = value; }
        }
        private string dealUser;
        public string DealUser
        {
            get { return dealUser; }
            set { this.dealUser = value; }
        }
        private DateTime dealTime;
        public DateTime DealTime
        {
            get { return dealTime; }
            set { this.dealTime = value; }
        }
        private DateTime addDate;
        public DateTime AddDate
        {
            get{ return addDate; }
            set{ this.addDate=value;}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.SysClass
{
    public class SysConfig
    {
        public static SysConfig systemConfig;
        private string storagePath;

        public string StorePath
        {
            get
            {
                return this.storagePath;
            }
            set
            {
                this.storagePath = value;
            }
        }

        private string[] languages;
        public string[] Languages
        {
            get
            {
                return languages;
            }
            set
            {
                this.languages = value;
            }
        }

        public SysConfig()
        {
            this.storagePath = string.Format("{0}\\Archive",System.Environment.CurrentDirectory);
            languages = new string[] { "English", "简体中文"};
        }

        public static SysConfig GetSysConfig()
        {
            if (systemConfig == null)
            {
                systemConfig = new SysConfig();
            }
            return systemConfig;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.SysClass
{
    /// <summary>
    /// Patient
    /// </summary>
    public class Patient
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string folderName;

        public string Foldername
        {
            get
            {
                return folderName;
            }
            set
            {
                this.folderName = value;
            }
        }

        public Patient(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.folderName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), id);
        }
    }
}

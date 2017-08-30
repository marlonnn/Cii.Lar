using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.ExpClass
{
    [Serializable]
    public class Frame
    {
        private string _fileFullName;

        private string _folder;

        public double ImageDiff { get; set; }

        public List<double> DiffList;

        public string FileFullName
        {
            get
            {
                return this._fileFullName;
            }
            set
            {
                this._fileFullName = value;
            }
        }

        public string Folder
        {
            get
            {
                return this._folder;
            }
            set
            {
                this._folder = value;
            }
        }

        public Frame(string fileFullName, string folder)
        {
            this._fileFullName = fileFullName;
            this._folder = folder;
        }
    }
}

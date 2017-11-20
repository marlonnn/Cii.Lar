using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Operation
{
    /// <summary>
    /// Abstract command, all command should extends this command and realize abstract method.
    /// contains IDS camera
    /// Author:Zhong Wen 2017/11/15
    /// </summary>
    public abstract class Command
    {
        protected bool isExecuteComplete = false;
        public virtual bool IsExecuteComplete
        {
            get { return this.isExecuteComplete; }
            set { this.isExecuteComplete = value; }
        }
        public string CommandName { get; set; }

        private IDSCamera idsCamera = new IDSCamera();
        protected Camera Camera
        {
            get { return this.idsCamera; }
        }

        public abstract bool Execute();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Operation
{
    public class CommandCameraStart : Command
    {
        public IntPtr IntPtr { get; set; }
        public CommandCameraStart(string name = "Start Camera")
        {
            this.CommandName = name;
        }

        public override bool Execute()
        {
            if (Camera.InitCamera())
            {
                return Camera.DisplayLive(IntPtr);
            }
            else
            {
                return false;
            }
        }
    }
}

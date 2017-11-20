using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cii.Lar.Operation
{
    public class OperationTask
    {
        private bool execute;
        public bool Execute
        {
            get { return this.execute; }
            set { this.execute = value; }
        }

        private CommandFactory commandFactory;
        public CommandFactory CommandFactory
        {
            get { return this.commandFactory; }
            set { this.commandFactory = value; }
        }

        public OperationTask()
        {
            Execute = true;
            CommandFactory = CommandFactory.GetCommandFactory();
        }

        public void ExecuteInternal()
        {
            while (Execute)
            {
                if (CommandFactory.CommandQueue != null)
                {
                    Command command = CommandFactory.CommandQueue.Pop();
                    if (command != null)
                    {
                        if (command.Execute())
                        {
                            LogHelper.GetLogger<OperationTask>().Debug(string.Format("Execute <{0}> command success", command.CommandName));
                        }
                        else
                        {
                            LogHelper.GetLogger<OperationTask>().Debug(string.Format("Execute <{0}> command fail", command.CommandName));
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Operation
{
    /// <summary>
    /// 执行任务的队列
    /// </summary>
    public class CommandQueue : ConcurrentQueue<Command>
    {
    }

    /// <summary>
    /// Command Factory
    /// Zhong wen 2017/11/15
    /// </summary>
    public class CommandFactory
    {
        private static CommandFactory commandFactory;

        //命令队列
        public CommandQueue CommandQueue { get; set; }

        //命令字典，存放所有操作指令
        public Dictionary<string, Command> CommandRepertory { private get; set; }

        private CommandFactory()
        {
            CommandQueue = new CommandQueue();

        }

        public CommandFactory(Dictionary<string, Command> CommandRepertory) : this()
        {
            this.CommandRepertory = CommandRepertory;
        }

        public static CommandFactory GetCommandFactory()
        {
            if (commandFactory == null)
            {
                commandFactory = new CommandFactory(CreateCommandRepertory());
            }
            return commandFactory;
        }

        private static Dictionary<string, Command> CreateCommandRepertory()
        {
            Dictionary<string, Command> commandDic = new Dictionary<string, Command>();
            commandDic.Add("Start Camera", new CommandCameraStart());
            commandDic.Add("Pause Camera", new CommandCameraPause());
            commandDic.Add("Close Camera", new CommandCameraClose());
            commandDic.Add("Camera Capture", new CommandCameraCapture());
            return commandDic;
        }

        /// <summary>
        /// 创建具体命令方法
        /// </summary>
        /// <typeparam name="T">命令类型</typeparam>
        /// <param name="commandName">命令名称</param>
        /// <returns></returns>
        public T CreateCommand<T>(string commandName) where T : Command
        {
            T command = (T)CommandRepertory[commandName];
            command.CommandName = commandName;
            return command;
        }
    }
}

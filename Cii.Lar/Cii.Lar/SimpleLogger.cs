using System;
using log4net;
using log4net.Config;
using System.IO;

namespace Cii.Lar
{
    /// <summary>
    /// [戴唯艺(2014-02-21): Log4net的轻量级实现方式]
    /// </summary>
    public class SimpleLogger
    {
		public static void Init ( string cfgPath )
		{
			FileInfo finfo = null;

			try
			{
				finfo = new FileInfo ( cfgPath );
			} catch ( Exception )
			{
				finfo = null;
			}

			if ( finfo != null )
				try
				{
					//配置文件修改后会立即生效，无需重启应用
					XmlConfigurator.ConfigureAndWatch ( finfo );
					
				} catch ( Exception )
				{
					//如果没有找到此文件，系统默认使用控制台方式输出
					BasicConfigurator.Configure ( );
				}
		}

		/// <summary>
		/// 使用之前确保Init过
		/// </summary>
		/// <returns></returns>
	    public static ILog GetLogger()
	    {
			ILog log = LogManager.GetLogger ( "" );
			return log;
	    }

	
    }
}

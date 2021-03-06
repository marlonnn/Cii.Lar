﻿using Cii.Lar.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Commond
{
    /// <summary>
    /// 设置频率输入量数字量
    /// </summary>
    public class LaserC73Request : LaserBaseRequest
    {
        /// <summary>
        /// 频率的最小间隔为10HZ
        /// </summary>
        private int interval = 10;

        /// <summary>
        /// 写入的脉宽数字量
        /// </summary>
        private int frequency;
        public int Frequency
        {
            get { return this.frequency; }
            private set { this.frequency = value; }
        }

        public LaserC73Request(int frequency)
        {
            this.frequency = frequency;
            this.Type = 0x73;
        }

        public override List<LaserBasePackage> Encode()
        {
            List<LaserBasePackage> bps = base.Encode();
            LaserBasePackage bp1 = new LaserBasePackage(0x8F, 0x73, new byte[] { 0x73, 0x00 });
            bps.Add(bp1);

            int digitalValue = Frequency / interval;
            byte aa = (byte)(digitalValue / 128);
            byte bb = (byte)(digitalValue % 128);
            LaserBasePackage bp2 = new LaserBasePackage(0x80, 0x73, new byte[] { aa, bb, 0x00, 0x00, 0x00, 0x00 });
            bps.Add(bp2);
            return bps;
        }
    }

    /// <summary>
    /// 80 FF 00 00 00 FF
    /// </summary>
    public class LaserC73Response : LaserBaseResponse
    {
        public LaserC73Response()
        {
            this.Type = 0x73;
        }

        public override List<LaserBaseResponse> Decode(LaserBasePackage bp, OriginalBytes obytes)
        {
            base.Decode(bp, obytes);
            if (CheckResponse(obytes.Data))
            {
                LaserC73Response c73Response = new LaserC73Response();
                c73Response.DtTime = DateTime.Now;
                c73Response.OriginalBytes = obytes;
                return CreateOneList(c73Response);
            }
            else
            {
                return null;
            }
        }
    }
}

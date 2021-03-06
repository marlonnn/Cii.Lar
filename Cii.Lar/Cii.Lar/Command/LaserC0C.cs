﻿using Cii.Lar.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.Commond
{
    /// <summary>
    /// 查询模块序列号
    /// </summary>
    public class LaserC0CRequest : LaserBaseRequest
    {
        public LaserC0CRequest()
        {
            this.Type = 0x0C;
        }

        public override List<LaserBasePackage> Encode()
        {
            List<LaserBasePackage> bps = base.Encode();
            LaserBasePackage bp = new LaserBasePackage(0x8F, 0x0C, new byte[] { 0x0C, 0x00 });
            bps.Add(bp);
            return bps;
        }
    }

    /// <summary>
    /// 返回查询模块序列号
    /// </summary>
    public class LaserC0CResponse : LaserBaseResponse
    {
        private byte sn0;
        public byte SN0
        {
            get { return this.sn0; }
            private set { this.sn0 = value; }
        }

        private byte sn1;
        public byte SN1
        {
            get { return this.sn1; }
            private set { this.sn1 = value; }
        }

        private byte sn2;
        public byte SN2
        {
            get { return this.sn2; }
            private set { this.sn2 = value; }
        }

        private byte sn3;
        public byte SN3
        {
            get { return this.sn3; }
            private set { this.sn3 = value; }
        }

        private string serial;
        public string Serial
        {
            get { return this.serial; }
            private set { this.serial = value; }
        }

        public LaserC0CResponse()
        {
            this.Type = 0x0C;
        }

        public override List<LaserBaseResponse> Decode(LaserBasePackage bp, OriginalBytes obytes)
        {
            base.Decode(bp, obytes);

            LaserC0CResponse c0CResponse = new LaserC0CResponse();
            c0CResponse.DtTime = DateTime.Now;
            c0CResponse.OriginalBytes = obytes;

            c0CResponse.SN0 = obytes.Data[1];
            c0CResponse.SN1 = obytes.Data[2];
            c0CResponse.SN2 = obytes.Data[3];
            c0CResponse.SN3 = obytes.Data[4];
            c0CResponse.Serial = string.Format("{0}{1}{2}{3}", GetSN0String(c0CResponse.SN0), c0CResponse.SN1, c0CResponse.SN2, c0CResponse.SN3);
            return CreateOneList(c0CResponse);
        }

        private string GetSN0String(byte sn0)
        {
            string sn0string = "";
            switch (sn0)
            {
                case 0x00:
                    sn0string = "EDFA";
                    break;
                case 0x01:
                    sn0string = "PEFL";
                    break;
                case 0x02:
                    sn0string = "PYEL";
                    break;
                case 0x04:
                    sn0string = "CEFL";
                    break;
                case 0x08:
                    sn0string = "CYFL";
                    break;
                case 0x10:
                    sn0string = "DFB";
                    break;
                case 0x20:
                    sn0string = "SDL";
                    break;
                case 0x40:
                    sn0string = "LD";
                    break;
                case 0x80:
                    sn0string = "ASE";
                    break;
            }
            return sn0string;
        }

    }
}

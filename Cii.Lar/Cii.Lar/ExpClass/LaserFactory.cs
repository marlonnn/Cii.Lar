using Cii.Lar.Laser;
using Cii.Lar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cii.Lar.ExpClass
{
    public class LaserFactory
    {
        private FixedLaser fixedLaser;
        public FixedLaser FixedLaser
        {
            get { return this.fixedLaser; }
        }

        private ActiveLaser activeLaser;
        public ActiveLaser ActiveLaser
        {
            get { return this.ActiveLaser; }
        }

        private AlignLaser alignLaser;
        public AlignLaser AlignLaser
        {
            get { return this.AlignLaser; }
        }

        private ZWPictureBox picturebox;
        public LaserFactory(ZWPictureBox picturebox)
        {
            this.picturebox = picturebox;
            this.fixedLaser = new FixedLaser(picturebox);
            this.activeLaser = new ActiveLaser(picturebox);
            this.alignLaser = new AlignLaser(picturebox);
            alignLaser.ZoomHandler += picturebox.ZoomHandler;
            alignLaser.ButtonStateHandler += picturebox.ButtonStateHandler;
        }

        private static LaserFactory factory;

        public static LaserFactory GetInstance(ZWPictureBox picturebox)
        {
            if (factory == null)
            {
                factory = new LaserFactory(picturebox);
            }
            return factory;
        }

        public void SetLaserByType(LaserType type)
        {
            switch (type)
            {
                case LaserType.SaturnFixed:
                    this.picturebox.Laser = fixedLaser;
                    break;
                case LaserType.SaturnActive:
                    this.picturebox.Laser = activeLaser;
                    break;
                case LaserType.Alignment:
                    this.picturebox.Laser = alignLaser;
                    break;
                default:
                    this.picturebox.Laser = fixedLaser;
                    break;
            }
        }
    }
}

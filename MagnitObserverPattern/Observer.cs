using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagnitObserverPattern
{
    public abstract class IMetal
    {
       
       public PictureBox picture;
       public int MagneticForse;
       public abstract void move(Point point);
     
    }
   public class Magnit
    {
       public Magnit(PictureBox p, int MR, Graphics g) {
            picture = p;
            MagneticRadius = MR;
            gr = g;
            
        }
        public PictureBox picture;
        public int MagneticRadius;
        Graphics gr;
        public List<IMetal> metals = new List<IMetal>();
        public void move(Point point) {
            for (int i = 0; i<7; i++) {
                gr.DrawEllipse(new Pen(Color.WhiteSmoke), this.picture.Location.X + ((this.picture.Width - MagneticRadius) / 2), this.picture.Location.Y + ((this.picture.Height - MagneticRadius) / 2), MagneticRadius, MagneticRadius);
                MagneticRadius -= 50;
            }
            this.picture.Left = point.X;
            this.picture.Top = point.Y;
            for (int i = 0; i < 7; i++)
            {
                MagneticRadius += 50;
                gr.DrawEllipse(new Pen(Color.Black), this.picture.Location.X + ((this.picture.Width - MagneticRadius) / 2), this.picture.Location.Y + ((this.picture.Height - MagneticRadius) / 2), MagneticRadius, MagneticRadius);
                
            }

            foreach (IMetal m in metals) {
              if (m.GetType().Name =="Iron" && new Rectangle(this.picture.Location.X + ((this.picture.Width - MagneticRadius) / 2), this.picture.Location.Y + ((this.picture.Height - MagneticRadius) / 2), MagneticRadius, MagneticRadius).Contains(m.picture.Location)) {
                    m.move(new Point(point.X + (this.picture.Width / 2), point.Y + (this.picture.Height / 2)));
              }
            }
        }
    }

    public class Iron: IMetal
    {
       public Iron(PictureBox p, int MF) {
            picture = p;
            MagneticForse =MF;
        }
        public override void move(Point point) {
            if (this.picture.Right- (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += MagneticForse;
            }
             if (this.picture.Left+ (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= MagneticForse;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += MagneticForse;
            }
             if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= MagneticForse;
            }
        }
    }
    public class NoIron : IMetal
    {
        public NoIron(PictureBox p, int MF)
        {
            picture = p;
            MagneticForse = MF;

        }
        public override void move(Point point)
        {
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += MagneticForse;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= MagneticForse;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += MagneticForse;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= MagneticForse;
            }
        }
    }
}

using System.Drawing.Drawing2D;

namespace flappybeard
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        PictureBox flappyBird = new PictureBox();
        PictureBox flappyBirdImage = new PictureBox();

        bool start = false;

        int gravity = -10;
        int force = 0;
        int velocity = -5;
        bool flop = false;
        int flopTime = 0;
        int flopTimeMax = 4;
        int rotDir = 1;
        int rotAngle = 0;
        int pipeSpeed = 0;
        int score = 0;

        int graceTime = 0;


        int iterPipe = 0;
        int pillarOffset = 450;
        int pillarWidth = 180;
        int pillarHeight = 500;
        int pillarYBottom = 500;
        int pillarYTop = -230;

        List<PictureBox> pipesBottom = new List<PictureBox>();
        List<PictureBox> pipesTop = new List<PictureBox>();



        public Form1()
        {
            InitializeComponent();
            initBird();
            initPillars();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (!start) { return; }

            int pipeCount = 0;
            for (int i = 0; i < pipesBottom.Count; i++)
            {
                pipesBottom[i].Left -= pipeSpeed;
                pipesTop[i].Left -= pipeSpeed;


                if (pipesBottom[i].Right < 0)
                {
                    int offsetY = rand.Next(-170, 80);
                    pipesBottom[i].Left = 3 * pillarOffset - pillarWidth;
                    pipesTop[i].Left = 3 * pillarOffset - pillarWidth;
                    pipesBottom[i].Top = pillarYBottom + offsetY;
                    pipesTop[i].Top = pillarYTop + offsetY;
                    score++;
                    if (score > 5)
                    {
                        pipeSpeed = 10;
                    }
                }
                if (flappyBird.Bounds.IntersectsWith(pipesBottom[i].Bounds) ||
                    flappyBird.Bounds.IntersectsWith(pipesTop[i].Bounds) ||
                    flappyBird.Bottom <= 10)
                {
                    //pipeSpeed = 0;
                    graceTime++;
                    if (graceTime > 5)
                        gameTimer.Stop();
                }
                else
                {
                    pipeCount++;
                    if (pipeCount >= 3)
                    {
                        pipeCount = 0;
                        graceTime = 0;
                    }
                }

            }

            flappyBird.Image = RotateImage(flappyBirdImage.Image, rotAngle);

            flappyBird.Top -= velocity;


            // gravity
            if (velocity > gravity)
            {
                velocity -= 1;
            }

            rotDir = 5;

            if (flopTime > 0)
            {
                flopTime--;
                flop = true;
                if (flopTime <= 0)
                {
                    flop = false;
                }
            }

            if (!flop && rotAngle < 60)
            {
                rotAngle += rotDir;

            }

            // this.Refresh();

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // gravity = -5;
                debugMessage.Text = "Dupa0";


            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // gravity = 5;
            }
        }

        private void gameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'q')
            {
                Application.Exit();

            }
            if (e.KeyChar == ' ')
            {
                if (!start)
                {
                    start = true;
                    pipeSpeed = 8;
                }

                velocity = 15;
                flopTime = 12;
                if (rotAngle - 30 > -50)
                {
                    rotAngle = -40;
                }
                else
                {
                    rotAngle = -50;
                }
            }
            if (e.KeyChar == 'c')
            {
                debugMessage.Text = "Making obj";
                rotDir = -rotDir;

            }
            if (e.KeyChar == 'z')
            {
                pipeSpeed -= 8;
            }
            if (e.KeyChar == 'x')
            {
                pipeSpeed += 8;
            }
        }
        private void initPillars()
        {

            int pillarX = 0;
            for (; iterPipe < 3; iterPipe++)
            {
                /// BOTTOM PIPE MODEL
                pipesBottom.Add(new PictureBox());
                pipesBottom[iterPipe].Image = Properties.Resources.pipe;
                pipesBottom[iterPipe].Location = new Point(pillarX + pillarOffset, pillarYBottom);
                pipesBottom[iterPipe].Size = new Size(pillarWidth, pillarHeight);
                pipesBottom[iterPipe].SizeMode = PictureBoxSizeMode.StretchImage;
                base.Controls.Add(pipesBottom[iterPipe]);


                /// PIPE TOP MODEL
                pipesTop.Add(new PictureBox());
                pipesTop[iterPipe].Image = Properties.Resources.pipedown;
                pipesTop[iterPipe].Location = new Point(pillarX + pillarOffset, pillarYTop);
                pipesTop[iterPipe].Size = new Size(pillarWidth, pillarHeight);
                pipesTop[iterPipe].SizeMode = PictureBoxSizeMode.StretchImage;
                base.Controls.Add(pipesTop[iterPipe]);

                pillarX += pillarOffset;

            }
        }
        private void initBird()
        {
            flappyBird.Image = Properties.Resources.bird;
            flappyBirdImage.Image = Properties.Resources.bird;
            flappyBird.Location = new Point(59, 242);
            flappyBird.Margin = new Padding(1);
            flappyBird.Name = "flappyBird";
            flappyBird.Size = new Size(80, 60);
            flappyBird.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(flappyBird);
        }

        private static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void button_click(object sender, EventArgs e)
        {

        }
    }
} 

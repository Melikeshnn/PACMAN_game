using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    public partial class Form1 : Form
    {
        public int EW = Screen.PrimaryScreen.Bounds.Width;
        public int EH = Screen.PrimaryScreen.Bounds.Height;

        public int x, y, xMax, yMax, SonTusdegeri, TDurum;
        public int x1, y1,x2,y2,x3,y3,x4,y4,x5,y5,x6,y6,x7,y7,x8,y8,x9,y9,x10,y10,x11,y11,x12,y12,
        x13,y13,x14,y14,x15,y15,x16,y16,x17,y17,x18,y18,x19,y19,x20,y20, Score;
        public int redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY,rx,ry,yx,yy,px,py ; //redGhost, yellowGhost, pinkGhost konumları


        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (TDurum == 1) { TDurum = -1; 
                PacMan.Image = Image.FromFile("ICON\\Pacman0.jpg");
                COIN1.Image = Image.FromFile("ICON\\COIN0.jpg"); 
                COIN2.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN3.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN4.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN5.Image = Image.FromFile("ICON\\COIN0.jpg"); 
                COIN6.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN6.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN7.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN8.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN9.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN10.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN11.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN12.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN13.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN14.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN15.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN16.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN17.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN18.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN19.Image = Image.FromFile("ICON\\COIN0.jpg");
                COIN20.Image = Image.FromFile("ICON\\COIN0.jpg");
            }
            if (TDurum == 0) 
            {
                if (SonTusdegeri == 37) { PacMan.Image = Image.FromFile("ICON\\PacmanL.jpg"); }
                if (SonTusdegeri == 38) { PacMan.Image = Image.FromFile("ICON\\PacmanU.jpg"); }
                if (SonTusdegeri == 39) { PacMan.Image = Image.FromFile("ICON\\PacmanR.jpg"); }
                if (SonTusdegeri == 40) { PacMan.Image = Image.FromFile("ICON\\PacmanD.jpg"); }
                COIN1.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN2.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN3.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN4.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN5.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN6.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN7.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN8.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN9.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN10.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN11.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN12.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN13.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN14.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN15.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN16.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN17.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN18.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN19.Image = Image.FromFile("ICON\\COIN1.jpg");
                COIN20.Image = Image.FromFile("ICON\\COIN1.jpg");
                //Hayaletlerin hızları. pinkGhost hem x hem y kordinatında hareket edeceği için ayrı ayrı tanımladık.
                redGhostSpeed = 50;
                yellowGhostSpeed = 50;
                pinkGhostX = 50;
                pinkGhostY = 50;

               // //kırmızı ve sarı hayaletin duvarlara çarptığında yön değiştirmesi için yazdığım.
                if (redGhost.Bounds.IntersectsWith(WALL6.Bounds) || redGhost.Bounds.IntersectsWith(WALL3.Bounds))
                {
                    redGhostSpeed = -redGhostSpeed;
                }

                yellowGhost.Left -= yellowGhostSpeed;

                if (yellowGhost.Bounds.IntersectsWith(WALL6.Bounds) || yellowGhost.Bounds.IntersectsWith(WALL1.Bounds))
                {
                    yellowGhostSpeed = -yellowGhostSpeed;
                }
               

                // pembe hayaletin iki eksende de hareket etmesi için.
                pinkGhost.Left -= pinkGhostX;
                pinkGhost.Top -= pinkGhostY;

               // //pembe hayaletin ekrandan çıkmaması için.
                if (pinkGhost.Top < 0 || pinkGhost.Top > 40)
                {
                    pinkGhostY = -pinkGhostY;
                }

                if (pinkGhost.Left < 0 || pinkGhost.Left > 100)
                {
                    pinkGhostX = -pinkGhostX;
                }


            }
            TDurum++;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(((int)e.KeyCode).ToString()); // herhangi basılan tuşun key kodunu görmek istersen!
            PacmanLocation((int)e.KeyCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Score = 0;
            //COINlerin lokasyonları.
            x1 = 50; y1 = 50;
            x2 = 39; y2 = 416;
            x3 = 1001; y3 = 108;
            x4 = 121; y4 = 416;
            x5 = 920; y5 = 108;
            x6 = 1001; y6 = 33;
            x7 = 920; y7 = 33;
            x8 = 39; y8 = 344;
            x9 = 121; x9 = 344;
            x10 = 171; y10 = 50;
            x11 = 290; y11 = 50;
            x12 = 384; y12 = 50;
            x13 = 483; y13 = 50;
            x14 = 576; y14 = 50;
            x15 = 674; y15 = 50;
            x16 = 987; y16 = 439;
            y17 = 886; y17 = 439;
            y18 = 773; y18 = 439;
            x19 = 674; y19 = 439;
            x20 = 576; y20 = 439;
            //Hayaletlerin lokasyonları.
            rx= 72;  ry = 158;
            yx= 746; ; yy = 108;
            px= 277; py = 428;

            TDurum = 0;
            xMax = EW - 40; yMax = EH - 100;     // Eğer en alttaki görev çubuğu aktif olursa 100 olmazsa 40   (PACMAN ImageBoxun ölçüsü 40!)
            x = xMax / 2; y = yMax / 2;
            PacmanLocation(39);  // Oyun başlarken PACMAN 'in yüzü Sağa dönük olsun istenirse!
            COIN1.Location = new Point(x1, y1);
            COIN2.Location = new Point(x2, y2);
            COIN3.Location = new Point(x3, y3);
            COIN4.Location = new Point(x4, y4);
            COIN5.Location = new Point(x5, y5);
            COIN6.Location = new Point(x6, y6);
            COIN7.Location = new Point(x7, y7);
            COIN8.Location = new Point(x8, y8);
            COIN9.Location = new Point(x9, y9);
            COIN10.Location = new Point(x10, y10);
            COIN11.Location = new Point(x11, y11);
            COIN12.Location = new Point(x12, y12);
            COIN13.Location = new Point(x13, y13);
            COIN14.Location = new Point(x14, y14);
            COIN15.Location = new Point(x15, y15);
            COIN16.Location = new Point(x16, y16);
            COIN17.Location = new Point(x17, y17);
            COIN18.Location = new Point(x18, y18);
            COIN19.Location = new Point(x19, y19);
            COIN20.Location = new Point(x20, y20);

            redGhost.Location = new Point(rx,ry);
            yellowGhost.Location= new Point(yx,yy);
            pinkGhost.Location= new Point(px,py);
          

            
        }

        public void PacmanLocation(int Tusdegeri)
        {
            SonTusdegeri = Tusdegeri;
            if (Tusdegeri == 27) { ActiveForm.Close(); }    // Escape Tuşuna basıldı!
            if (Tusdegeri == 37) { x = x - 5; }             // Sol    Tuşuna basıldı!
            if (Tusdegeri == 38) { y = y - 5; }             // Yukarı Tuşuna basıldı!
            if (Tusdegeri == 39) { x = x + 5; }             // Sağ    Tuşuna basıldı!
            if (Tusdegeri == 40) { y = y + 5; }             // Aşağı  Tuşuna basıldı!


            if (x > xMax) { x = 0;    }    // Ekranın sağından çıkıp soldan başlaması için kontrol!   
            if (x < 0)    { x = xMax; }    // Ekranın solundan çıkıp sağdan başlaması için kontrol!         
            if (y > yMax) { y = 0;    }    // Ekranın altından çıkıp üstden başlaması için kontrol!      
            if (y < 0)    { y = yMax; }    // Ekranın üstünden çıkıp altdan başlaması için kontrol!      

            PacMan.Location = new Point(x, y); 
            if (((x > x1 && x < x1 + 40) && (y > y1 && y < y1 + 40)) && COIN1.Visible == true) { COIN1.Visible = false;  Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString ();
            if (((x > x2 && x < x2 + 40) && (y > y2 && y < y2 + 40)) && COIN2.Visible == true) { COIN2.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x3 && x < x3 + 40) && (y > y3 && y < y3 + 40)) && COIN3.Visible == true) { COIN3.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x4 && x < x4 + 40) && (y > y4 && y < y4 + 40)) && COIN4.Visible == true) { COIN4.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x5 && x < x5 + 40) && (y > y5 && y < y5 + 40)) && COIN5.Visible == true) { COIN5.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x6 && x < x6 + 40) && (y > y6 && y < y6 + 40)) && COIN6.Visible == true) { COIN6.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x7 && x < x7 + 40) && (y > y7 && y < y7 + 40)) && COIN7.Visible == true) { COIN7.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x8 && x < x8 + 40) && (y > y8 && y < y8 + 40)) && COIN8.Visible == true) { COIN8.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x9 && x < x9 + 40) && (y > y9 && y < y9 + 40)) && COIN9.Visible == true) { COIN9.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x10 && x < x10 + 40) && (y > y10 && y < y10 + 40)) && COIN10.Visible == true) { COIN10.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x11 && x < x1 + 40) && (y > y11 && y < y1 + 40)) && COIN11.Visible == true) { COIN11.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x12 && x < x12 + 40) && (y > y12 && y < y12 + 40)) && COIN12.Visible == true) { COIN12.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x13 && x < x13 + 40) && (y > y13 && y < y13 + 40)) && COIN13.Visible == true) { COIN13.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x14 && x < x14 + 40) && (y > y14 && y < y14 + 40)) && COIN14.Visible == true) { COIN14.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x15 && x < x15 + 40) && (y > y15 && y < y15 + 40)) && COIN15.Visible == true) { COIN15.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x16 && x < x16 + 40) && (y > y16 && y < y1 + 40)) && COIN16.Visible == true) { COIN16.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x17 && x < x17 + 40) && (y > y17 && y < y1 + 40)) && COIN17.Visible == true) { COIN17.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x18 && x < x18 + 40) && (y > y18 && y < y18 + 40)) && COIN18.Visible == true) { COIN18.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x19 && x < x19 + 40) && (y > y19 && y < y19 + 40)) && COIN19.Visible == true) { COIN19.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();
            if (((x > x20 && x < x20 + 40) && (y > y20 && y < y20 + 40)) && COIN20.Visible == true) { COIN20.Visible = false; Score = Score + 10; }
            this.Text = "Pacman 2022  Copyright by XPlus Group LLC          Score : " + Score.ToString();

            //Duvarlara dokunduğunda "You Lose!" yazısı.
            if (PacMan.Bounds.IntersectsWith(WALL1.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " +Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(WALL2.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(WALL3.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(WALL4.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(WALL5.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(WALL6.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            //Hayaletlere dokunduğunda "You Lose!" yazısı.
            if (PacMan.Bounds.IntersectsWith(redGhost.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (PacMan.Bounds.IntersectsWith(yellowGhost.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
               
            }
            if (PacMan.Bounds.IntersectsWith(pinkGhost.Bounds))
            {
                MessageBox.Show("You Lose!  " + "Score: " + Score.ToString());
            }
            if (Score==200)
            {
                MessageBox.Show("You Win!  " + "Score: " + Score.ToString());
            }
        }
    }
}

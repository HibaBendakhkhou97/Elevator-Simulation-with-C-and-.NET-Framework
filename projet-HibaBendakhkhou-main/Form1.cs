using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MoveElementToMouseClickPosition
{
    public partial class MainForm : Form 
    {
        private int x1, x2, x3, x4, x5;
        private int currentIndex = 0;
        private int[] fileAttenteDemandes = new int[100];

        public MainForm()
        {
            InitializeComponent();
        }

        private void openDor_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\hiba\source\repos\projet-HibaBendakhkhou\Resources\OpenedElevator.png");
        }

        private void closeDoor_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\hiba\source\repos\projet-HibaBendakhkhou\Resources\ClosedElevator.png");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialise();
        }

        private void Initialise()
        {
            x1 = etage1.Top;
            x2 = etage2.Top;
            x3 = etage3.Top;
            x4 = etage4.Top;
            x5 = etage5.Top;
        }

        private void onEtageClick(object sender, EventArgs e)
        {
            Control control = sender as Control;

            if (control == bt1 || control == etage1)
                fileAttenteDemandes[currentIndex++] = x1;
            else if (control == bt2 || control == etage2)
                fileAttenteDemandes[currentIndex++] = x2;
            else if (control == bt3 || control == etage3)
                fileAttenteDemandes[currentIndex++] = x3;
            else if (control == bt4 || control == etage4)
                fileAttenteDemandes[currentIndex++] = x4;
            else if (control == bt5 || control == etage5)
                fileAttenteDemandes[currentIndex++] = x5;
            else
                return;

            if (currentIndex == 1)
                GestionDemande();
        }

        public void MovToTarget(int etage)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\hiba\source\repos\projet-HibaBendakhkhou\Resources\ClosedElevator.png");
            int initialY = pictureBox1.Location.Y;
            int finalY = etage;
            int targetY = finalY - pictureBox1.Height / 2;
            int totalIterations = 100;
            bool imageChanged = false;

            for (int i = 1; i <= totalIterations; i++)
            {
                int newY = initialY + (targetY - initialY) * i / totalIterations;
                pictureBox1.Location = new System.Drawing.Point(pictureBox1.Location.X, newY);

                if (!imageChanged && i == totalIterations)
                {
                    pictureBox1.Image = Image.FromFile(@"C:\Users\hiba\source\repos\projet-HibaBendakhkhou\Resources\OpenedElevator.png");
                    Thread.Sleep(1000);
                    imageChanged = true;
                }

                Application.DoEvents();
                System.Threading.Thread.Sleep(10);
            }
        }

        private void GestionDemande()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\hiba\source\repos\projet-HibaBendakhkhou\Resources\ClosedElevator.png");
                Thread.Sleep(2000);
                MovToTarget(fileAttenteDemandes[i]);
                
            }
            currentIndex = 0;
        }

    }
}

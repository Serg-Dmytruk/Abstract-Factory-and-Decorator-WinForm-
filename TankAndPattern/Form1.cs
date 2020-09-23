using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankAndPattern.AbstractFactoryClasses;
using TankAndPattern.DecoratorClasses;
using TankAndPattern.TanksClasses;

namespace TankAndPattern
{
    public partial class Form1 : Form
    {
        const int armySize = 5;
        Tank[] naziArmy = new Tank[armySize];
        Tank[] sovokArmy = new Tank[armySize];
        PictureBox[] picherBoxControler1 = new PictureBox[armySize];
        PictureBox[] picherBoxControler2 = new PictureBox[armySize];
        ShotDecorator tankNaziTmp;
        ShotDecorator tankSovokTmp;
        private int turn = 0;
        public Form1()
        {
            InitializeComponent();
            label6.Text = turn.ToString();
            battlefild.BackgroundImage = Resource1.grass;
            mainControlPanel.Enabled = false;
            Round.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //створюємо танкі за допомогою абстрактної фабрики
            for (int i = 0; i < armySize; i++)
            {
                naziArmy[i] = new NaziTankFactory().CreateTank();
                sovokArmy[i] = new SovocTankFactory().CreateTank();
            }
            //виводимо танкі на форму//
            UpdateTank();
        }
        #region //задаєм картинкі для пікер боксів прив'язуємо їх до масива та дозволяємо відображати на формі
        private void UpdateTank()
        {
            //Нациські танки
            NaziPos1.Image = ((PzKpfv)naziArmy[0]).texture;
            NaziPos2.Image = ((PzKpfv)naziArmy[1]).texture;
            NaziPos3.Image = ((PzKpfv)naziArmy[2]).texture;
            NaziPos4.Image = ((PzKpfv)naziArmy[3]).texture;
            NaziPos5.Image = ((PzKpfv)naziArmy[4]).texture;
            //Совкові танки
            SovokPos1.Image = ((T34)sovokArmy[0]).texture;
            SovokPos2.Image = ((T34)sovokArmy[1]).texture;
            SovokPos3.Image = ((T34)sovokArmy[2]).texture;
            SovokPos4.Image = ((T34)sovokArmy[3]).texture;
            SovokPos5.Image = ((T34)sovokArmy[4]).texture;
            //прив'язуємо пікчер бокси до масива для подальших маніпуляцій з відображенням
            picherBoxControler1[0] = NaziPos1;
            picherBoxControler1[1] = NaziPos2;
            picherBoxControler1[2] = NaziPos3;
            picherBoxControler1[3] = NaziPos4;
            picherBoxControler1[4] = NaziPos5;

            picherBoxControler2[0] = SovokPos1;
            picherBoxControler2[1] = SovokPos2;
            picherBoxControler2[2] = SovokPos3;
            picherBoxControler2[3] = SovokPos4;
            picherBoxControler2[4] = SovokPos5;

            EnableShowAll();
            mainControlPanel.Enabled = true;
            naziControlPanel.Enabled = true;
            sovokControlPanel.Enabled = false;

            button1.Enabled = false;
        }
        private void EnableShowAll()
        {
            foreach (PictureBox box in picherBoxControler1) { box.Visible = true; }
            foreach (PictureBox box in picherBoxControler2) { box.Visible = true; }
        }
        #endregion

        //використання декоратора
        private void button2_Click(object sender, EventArgs e)
        {

            label6.Text = (1 + turn).ToString();
            var button = sender;
            if (((Button)button).Name == nt.Name)
            {
                if (naziNormal.Checked)
                {
                    tankNaziTmp = new NormalShotDecorator();
                    tankNaziTmp.SetTank(naziArmy[turn]);
                }
                else
                {
                    tankNaziTmp = new PowerShotDecorator();
                    tankNaziTmp.SetTank(naziArmy[turn]);
                }
                naziControlPanel.Enabled = false;
                sovokControlPanel.Enabled = true;
            }
            else if (((Button)button).Name == st.Name)
            {
                if (sovokNormal.Checked)
                {
                    tankSovokTmp = new NormalShotDecorator();
                    tankSovokTmp.SetTank(sovokArmy[turn]);
                }
                else
                {
                    tankSovokTmp = new PowerShotDecorator();
                    tankSovokTmp.SetTank(sovokArmy[turn]);
                }
                sovokControlPanel.Enabled = false;
                Round.Enabled = true;
            }
        }
    
        private void TurnChange()
        {
            naziControlPanel.Enabled = !naziControlPanel.Enabled;
            //sovokControlPanel.Enabled = !sovokControlPanel.Enabled;
            Round.Enabled = !Round.Enabled;
        }
        private bool RoundResult(int attac , int deffence )
        {
            if (attac > deffence)
                return true;
            else
                return false;
        }
        private void WinCheck()
        {
            int naziScore = 0, sovocScore = 0;
            foreach (PictureBox item in picherBoxControler1)
            {
                if (item.Visible == true)
                    naziScore++;
            }
            foreach (PictureBox item in picherBoxControler2)
            {
                if (item.Visible == true)
                    sovocScore++;
            }
            if(naziScore > sovocScore)
            {
                MessageBox.Show("Nazi Win!", "Battle result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sovok Win!", "Battle result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(RoundResult(tankNaziTmp.GetTankPower(), tankSovokTmp.GetTankPower()))
            {
                picherBoxControler2[turn].Visible = false;
            }
            else 
            {
                picherBoxControler1[turn].Visible = false;
            }
            turn++;
            if(turn == 5)
            {
                WinCheck();
            }
            TurnChange();
        }
    }
}

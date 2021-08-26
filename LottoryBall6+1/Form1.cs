using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoryBall6_1
{
    public partial class FrmLotteryBalls : Form
    {
        Selector selector = new Selector();
        List<string> redBalls = new List<string>();
        List<string> blueBalls = new List<string>();
        public FrmLotteryBalls()
        {
            InitializeComponent();
        }

        #region Window Move by left mouse button draging

        private Point mouseOff; //position of mouse moving
        private bool leftFlag; //a flag if leftbutton clicked
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); // get the value of current position
                leftFlag = true; // when left button clicked, set flag to true
            }
        }

        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //set position after moving
                Location = mouseSet;
            }
        }
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag) leftFlag = false;
        }
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timerCreateNum.Start();
            this.btnStart.Enabled = false;
            this.btnSelect.Enabled = true;
        }

        private void timerCreateNum_Tick(object sender, EventArgs e)
        {
            timerCreateNum.Interval = 50;
            this.redBalls = selector.createRandomNumbers(5, selector.RedNumbers);
            this.blueBalls = selector.createRandomNumbers(0, selector.BlueNumbers);
            this.lblNum1.Text = this.redBalls[0];
            this.lblNum2.Text = this.redBalls[1];
            this.lblNum3.Text = this.redBalls[2];
            this.lblNum4.Text = this.redBalls[3];
            this.lblNum5.Text = this.redBalls[4];
            this.lblNum6.Text = this.redBalls[5];
            this.lblNum7.Text = this.blueBalls[0];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnSelect.Enabled = false;
            this.timerCreateNum.Stop();
            DualColorBalls dc = new DualColorBalls
            {
                RedBalls = this.redBalls,
                BlueBalls = this.blueBalls
            };
            this.selector.SelectedNumbers.Add(dc);
            //string list = this.lblNum1.Text + "\t" + this.lblNum2.Text + "\t" + this.lblNum3.Text + "\t" + this.lblNum4.Text + "\t" + this.lblNum5.Text + "\t" + this.lblNum6.Text + "\t" + this.lblNum7.Text;
            string list = String.Empty;
            foreach(string item in this.redBalls)
            {
                list += item + "\t";
            }
            list += this.blueBalls[0];
            this.lbNumberList.Items.Add(list);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lblNum1.Text = "00";
            this.lblNum2.Text = "00";
            this.lblNum3.Text = "00";
            this.lblNum4.Text = "00";
            this.lblNum5.Text = "00";
            this.lblNum6.Text = "00";
            this.lblNum7.Text = "00";
            this.lbNumberList.Items.Clear();
        }
    }
}

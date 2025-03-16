using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer

{
    public partial class FormEvents : Form
    {
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region Action Buttons
        private void Action1_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(1);
        }
        private void Action2_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(2);
        }
        private void Action3_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(3);
        }
        private void Action4_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(4);
        }
        private void Action5_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(5);
        }
        private void Action6_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(6);
        }
        private void Action7_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(7);
        }
        private void Action8_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(8);
        }
        private void Action9_Click(object sender, EventArgs e)
        {
            MainGameHandling game = new MainGameHandling();
            game.Button9_Pressed(9);
        }
        #endregion
          
        private void temp_Click(object sender, EventArgs e)
        {
            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            MainGameHandling.Instance.StartGameNew(this.nameInput.Text, 0, new bool[]{ false});
            StartMenuPanel.Visible = false;
            Player.Instance.CurrentState = GridButton_States.Navigation;
            //challenges will come in next update
        }

        #region Situation/Inspect
        private void Situation_Click(object sender, EventArgs e)
        {
            
        }
        private void Inspect_Click_1(object sender, EventArgs e)
        {

        }
        #endregion
        #region 9Buttons

        #endregion
    }

}
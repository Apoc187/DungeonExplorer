using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using static DungeonExplorer.MainGameHandling;

namespace DungeonExplorer
{
    internal class Program
    {

        

        private static FormEvents form1 = new FormEvents();
        static void Main()
        {
            bool[] challenges = { false, false };
            form1.InitializeComponent();
            Application.Run(form1);
           
        }
    }

    public class LogicToDisplay
    {
        private static LogicToDisplay instance = null;
        private static readonly object padlock = new object();
        FormEvents form1 = new FormEvents();
        public string DescriptionString;

        LogicToDisplay()
        { }

        public static LogicToDisplay Instance
        {

            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LogicToDisplay();
                    }
                }

                return instance;
            }
        }

        //dynamic text for popups for different states
        public Dictionary<GridButton_States, string> sits = new Dictionary<GridButton_States, string>
        {
            {GridButton_States.Navigation, "\nAction2 = North \nAction4 = West \nAction5 = Rest \nAction6 = East \nAction8 = South" },
            {GridButton_States.Misc, "\nAction1 = Interact \nAction3 = Don't Interact"},
            {GridButton_States.Inventory, "\nAction1 = Inv Slot 1 \nAction2 = Inv Slot 2 \nAction3 = Inv Slot 3 \nAction4 = Inv Slot 4 \nAction5 = Exit \nAction6 = Inv Slot 5 \nAction7 = Inv Slot 6 \nAction8 = Inv Slot 7 \nAction9 = Inv Slot 8" },
            {GridButton_States.InvItem, "\nAction1 = Use \nAction2 = Back \nAction3 = Drop"}
            //combat will be added later
        };

        //debug
        public void SwitchStates(GridButton_States State)
        {
        }

        //dynamic popup content
        public void LabelText(string text)
        {
            MessageBox.Show(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y].ImagePath+ "\n" + Player.Instance.DescriptionString + sits[Player.Instance. CurrentState] + $"\nHealth: {Player.Instance.Health} \nEnergy: {Player.Instance.Energy}");
        }

    }
}


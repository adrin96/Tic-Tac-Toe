using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Dictionary<int, PictureBox> dictionaryPictureBox = new Dictionary<int, PictureBox>();
        List<int> listOfPositionO = new List<int>();
        List<int> listOfPositionX = new List<int>();


        Player player;
        public Form1()
        {
            InitializeComponent();
            initialDictionaryPictureBox();
            stopThePicture();
        }

        public void initialDictionaryPictureBox()
        {
            dictionaryPictureBox.Add(1, pictureBox1);
            dictionaryPictureBox.Add(2, pictureBox2);
            dictionaryPictureBox.Add(3, pictureBox3);
            dictionaryPictureBox.Add(4, pictureBox4);
            dictionaryPictureBox.Add(5, pictureBox5);
            dictionaryPictureBox.Add(6, pictureBox6);
            dictionaryPictureBox.Add(7, pictureBox7);
            dictionaryPictureBox.Add(8, pictureBox8);
            dictionaryPictureBox.Add(9, pictureBox9);
        }

        private void buttonSTART_Click(object sender, EventArgs e)
        {    
            buttonSTART.Enabled = false;
            player = new Player(Type.X);

            startThePicture();       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(0).Key, player.getType());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(1).Key, player.getType());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(2).Key, player.getType());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(3).Key, player.getType());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(4).Key, player.getType());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(5).Key, player.getType());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(6).Key, player.getType());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(7).Key, player.getType());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            changingPictureBox((int)dictionaryPictureBox.ElementAt(8).Key, player.getType());
        }



        public void changingPictureBox(int x, Type type)
        {
            if (type == Type.O)
            {
              //  Console.WriteLine("Dodałem do listy listOfPostionO: " + x);
                listOfPositionO.Add(x);
                labelPlayer.Text = "Turn: X";

            }

            if (type == Type.X)
            {
              //  Console.WriteLine("Dodałem do listy listOfPostionX: " + x);
                listOfPositionX.Add(x);
                labelPlayer.Text = "Turn: O";
            }
       

            //3D OBRAZEK
            dictionaryPictureBox.ElementAt(x-1).Value.BorderStyle = BorderStyle.Fixed3D;

            //Wyświetlenie odpowiedniego obrazka
            if (type.ToString().Equals("X"))
            {
                dictionaryPictureBox.ElementAt(x-1).Value.Image = Properties.Resources.X;
            }

            if (type.ToString().Equals("O"))
            {
                dictionaryPictureBox.ElementAt(x-1).Value.Image = Properties.Resources.O;
            }

            //Wyśrodkowanie
            dictionaryPictureBox.ElementAt(x-1).Value.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            //Wyśrodkowanie
            dictionaryPictureBox.ElementAt(x - 1).Value.Enabled = false;

            checkWinner();


            //Zmiana Typu
            player.ChangeType(this.player);


        }
        public void whichPictureToChange(int x, int y, int z, string whichPlayer)
        {
            if (whichPlayer.Equals("O"))
            {
                foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
                {
                    if (item.Value == dictionaryPictureBox.ElementAt(x).Value
                       || item.Value == dictionaryPictureBox.ElementAt(y).Value
                       || item.Value == dictionaryPictureBox.ElementAt(z).Value
                        )
                    {
                        item.Value.Image = Properties.Resources.O_Winner;
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
                {
                    if (item.Value == dictionaryPictureBox.ElementAt(x).Value
                       || item.Value == dictionaryPictureBox.ElementAt(y).Value
                       || item.Value == dictionaryPictureBox.ElementAt(z).Value
                        )
                    {
                        item.Value.Image = Properties.Resources.X_Winner;
                    }

                }


            }
        }

            #region aLotOfVariables
            public void checkWinner()
        {

            //1 2 3 - O
            if (listOfPositionO.Contains(1) && listOfPositionO.Contains(2) && listOfPositionO.Contains(3))
            {
              whichPictureToChange(0, 1, 2, "O");  
              startAgain("O");
            }

            //1 2 3 - X
            if (listOfPositionX.Contains(1) && listOfPositionX.Contains(2) && listOfPositionX.Contains(3))
            {
                whichPictureToChange(0, 1, 2, "X");
                startAgain("X");
            }

            // 4 5 6 - 0
            if (listOfPositionO.Contains(4) && listOfPositionO.Contains(5) && listOfPositionO.Contains(6))
            {
                whichPictureToChange(3, 4, 5, "O");
                startAgain("O");
            }

            // 4 5 6 - X
            if (listOfPositionX.Contains(4) && listOfPositionX.Contains(5) && listOfPositionX.Contains(6))
            {
                whichPictureToChange(3, 4, 5, "X");
                startAgain("X");
            }

            // 7 8 9 - X
            if (listOfPositionX.Contains(7) && listOfPositionX.Contains(8) && listOfPositionX.Contains(9))
            {
                whichPictureToChange(6, 7, 8, "X");
                startAgain("X");
            }

            // 7 8 9 - O
            if (listOfPositionO.Contains(7) && listOfPositionO.Contains(8) && listOfPositionO.Contains(9))
            {
                whichPictureToChange(6, 7, 8, "O");
                startAgain("O");
            }

            // 1 5 9 - X
            if (listOfPositionX.Contains(1) && listOfPositionX.Contains(5) && listOfPositionX.Contains(9))
            {
                whichPictureToChange(0, 4, 8, "X");
                startAgain("X");
            }

            // 1 5 9 - 0
            if (listOfPositionO.Contains(1) && listOfPositionO.Contains(5) && listOfPositionO.Contains(9))
            {
                whichPictureToChange(0, 4, 8, "O");
                startAgain("O");
            }


            // 3 5 7 - 0
            if (listOfPositionO.Contains(3) && listOfPositionO.Contains(5) && listOfPositionO.Contains(7))
            {
                whichPictureToChange(2, 4, 6, "O");
                startAgain("O");
            }


            // 3 5 7 - X
            if (listOfPositionX.Contains(3) && listOfPositionX.Contains(5) && listOfPositionX.Contains(7))
            {
                whichPictureToChange(2, 4, 6, "X");
                startAgain("X");
            }

            // 1 4 7 - X
            if (listOfPositionX.Contains(1) && listOfPositionX.Contains(4) && listOfPositionX.Contains(7))
            {
                whichPictureToChange(0,3, 6, "X");
                startAgain("X");
            }

            // 2 5 8 - X
            if (listOfPositionX.Contains(2) && listOfPositionX.Contains(5) && listOfPositionX.Contains(8))
            {
                whichPictureToChange(1, 4, 7, "X");
                startAgain("X");
            }

            // 3 6 9 - X
            if (listOfPositionX.Contains(3) && listOfPositionX.Contains(6) && listOfPositionX.Contains(9))
            {
                whichPictureToChange(2, 5, 8, "X");
                startAgain("X");
            }

            // 1 4 7 - O
            if (listOfPositionO.Contains(1) && listOfPositionO.Contains(4) && listOfPositionO.Contains(7))
            {
                whichPictureToChange(0, 3, 6, "O");
                startAgain("O");
            }

            // 2 5 8 - O
            if (listOfPositionO.Contains(2) && listOfPositionO.Contains(5) && listOfPositionO.Contains(8))
            {
                whichPictureToChange(1, 4, 7, "O");
                startAgain("O");
            }

            // 3 6 9 - O
            if (listOfPositionO.Contains(3) && listOfPositionO.Contains(6) && listOfPositionO.Contains(9))
            {
                whichPictureToChange(2, 5, 8, "O");
                startAgain("O");
            }
       

                foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
                {
                if (listOfPositionX.Count>=5 || listOfPositionO.Count >=5)
                {
                    startAgain("REMIS");
                }
                }
            

        }
        #endregion


        public void startThePicture()
        {
            foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
            {
                item.Value.Enabled = true;
            }
        }

        public void stopThePicture()
        {
            foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
            {
                item.Value.Enabled = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            resetTheGame();
        }

        public void resetTheGame()
        {
            foreach (KeyValuePair<int, PictureBox> item in dictionaryPictureBox)
            {
                if (item.Value.Image != null)
                {
                    item.Value.Image = null;
                    startThePicture();
                    listOfPositionO.Clear();
                    listOfPositionX.Clear();

                }
            }
        }


        public void startAgain(string whichPlayer)
        {
            if (whichPlayer.Equals("X"))
            {
                MessageBox.Show("The Winner is X!!!", "The End", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (whichPlayer.Equals("O"))
            {
                MessageBox.Show("The Winner is O!!!", "The End", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (whichPlayer.Equals("DRAW"))
            {
                MessageBox.Show("DRAW", "The end", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            stopThePicture();
            listOfPositionO.Clear();
            listOfPositionX.Clear();

            DialogResult dialogResult =  MessageBox.Show("Do you want play again?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    resetTheGame();
                    break;
                case DialogResult.No:
                    Application.Exit();
                    break;
                default:
                    break;
            }

        }
    }
}

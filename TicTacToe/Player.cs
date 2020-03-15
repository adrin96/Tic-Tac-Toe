using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public enum Type
    {
        X = 'X',
        O = 'O',

    }

    class Player
    {

        private Type type;
       // private PictureBox pictureBox;

        public Player(Type type)
        {
            this.type = type;
        }

        public Type getType()
        {
            return type;
        }

        public void ChangeType(Player player)
        {

            if (player.type.ToString().Equals("O"))
            {
                player.type = Type.X;
            }
            else if (player.type.ToString().Equals("X"))
            {
                player.type = Type.O;             
            }
            
        }






    }
}

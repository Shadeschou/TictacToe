using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictacToe
{
    public class GameSystems :Bindable
    {
        private string currentTurn;

        public string CurrentTurn
        {
            get { return currentTurn; }
            set { currentTurn = "The current turn is : " + value; propertyIsChanged(); }
        }

        public GameSystems()
        {
            this.currentTurn = "Insert Name and Click on a button ";
            
        }
    }
}

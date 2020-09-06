using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TictacToe
{
    public class Player : Bindable
    {
 
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; propertyIsChanged(); }
        }

        public Player()
        {

            Name = "Insert Name";
        }
    }
}

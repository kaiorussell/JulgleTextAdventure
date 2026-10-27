using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulgleTextAdventure
{
    //PARENT CLASSES
    public class Item
    {
        public string name = "Item";
        public string inpectionText = "ItemInpectionText";

        public Item(string name, string inpectionText)
        {
            this.name = name;
            this.inpectionText = inpectionText;
        }
    }

    public class Consumable : Item
    {
        int testInt;
        public Consumable(string name, string inspectionText, int number) : base(name, inspectionText)
        {
            this.testInt = number;
        }

        public virtual void UseItem()
        {

        }

    }

    public class KeyItem : Item
    {
        public KeyItem(string Name, string InpectionText) : base(Name, InpectionText)
        {
            
        }
    }

    //LIKE THE SPECIFIC CONSUMABLES
}
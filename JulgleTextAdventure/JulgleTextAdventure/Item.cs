using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulgleTextAdventure
{
    [Flags]
    public enum ItemTypes
    { //kortlink.dk/2vbzn
        Healing,
        AttackIncrease
    }

    public class Item
    {
        public string name = "Item";
        public string inpectionText = "ItemInpectionText"; //Ik tænk på det

        public Item(string name, string inpectionText)
        {
            this.name = name;
            this.inpectionText = inpectionText;
        }
    }

    public class Consumable : Item
    {
        public ItemTypes type;
        public float itemValue;
        public Consumable(string name, string inspectionText, ItemTypes type) : base(name, inspectionText)
        {
            this.type = type;
        }
        
        public virtual float UseItem()
        {
            return itemValue;
        }

    }

    public class KeyItem : Item
    {
        public KeyItem(string Name, string InpectionText) : base(Name, InpectionText)
        {
            
        }
    }
}
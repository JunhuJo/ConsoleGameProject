using ConsoleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleProject
{
    public class Item
    {

        private static List<Item>   itemList = new List<Item>();

        
        protected string Type { get; set; }
        protected int ItemAP { get; set; }
        protected int ItemDP { get; set; }
        protected int ItemHill { get; set; }


        public string Name { get; set; }
        public Item(string name)
        {

             Name = name;
            
        }
 
    }
    public class Weapon : Item
    {
        int AP { get; set; }

        public Weapon(string WeaponName, int ap) : base("무기")
        {
            Name = WeaponName;
            AP = ap;
            
        }

    }

    public class Armor : Item
    {
        int DP { get; set; }

        public Armor(string ArmorName, int dp) : base("방어구")
        {
            Name = ArmorName;
            DP = dp;
        }


    }
    public class Potion : Item
    {
        int Heal { get; set; }

        public Potion(string PotionName, int heal) : base("물약")
        {
            Name = PotionName;
            Heal = heal;
        }


    }
}

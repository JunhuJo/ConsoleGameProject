using ConsoleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Monster
    {
        private string MonsterName { get; set; }
        private int monsterX { get; set; }
        private int monsterY { get; set; }
        private int monsterHP { get; set; }
        private int monsterAP { get; set; }
        private int monsterDP { get; set; }
        private string MonsterPotint = "◈";

        public void OrcType(string monName, int x, int y)
        {
            MonsterName = monName;

            monsterX = x;
            monsterY = y;
            Console.SetCursorPosition(monsterX, monsterY);
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(MonsterPotint);

            Console.SetCursorPosition(monsterX-2, monsterY+1);
            Console.WriteLine(monName);

        }

        public void OrcBossType(string monName, int x, int y)
        {
            MonsterName = monName;

            monsterX = x;
            monsterY = y;
            Console.SetCursorPosition(monsterX, monsterY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(MonsterPotint);

            Console.SetCursorPosition(monsterX - 5, monsterY + 1);
            Console.WriteLine(monName);

        }


    }
}

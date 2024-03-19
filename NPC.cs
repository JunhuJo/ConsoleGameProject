using ConsoleProject;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    
    public class NPC
    {
        
        private string Name { get; set; }
        private int NpcX { get; set; }
        private int NpcY { get; set; }


        public void SellNpc(string name, int x, int y)
        {
            
            Name = name;
            NpcX = x;
            NpcY = y;

            Console.SetCursorPosition(NpcX, NpcY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("●");

        }

     

    }
}

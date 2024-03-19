using ConsoleProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class chatBox
    {

        private int point { get; set; } = 0;
        private bool select { get; set; } = false;

        private string[,] Box { get; set; } = {
            { "□", "□", "□", "□", "□", "□", "□", "□","□","□","□","□","□","□","□","□","□","□","□","□","□","□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□","□", "□", "□", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ","  ", "  ", "  ", "□" },
            { "□", "□", "□", "□", "□", "□", "□", "□","□","□","□","□","□","□","□","□","□","□","□","□","□","□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□", "□","□", "□", "□", "□" },

        };

        


        public void displaychatBox()
        {
            
            for (int i = 0; i < Box.GetLength(0); i++)
            {
                for (int j = 0; j < Box.GetLength(1); j++)
                {
                    Console.Write(Box[i, j]);
                }
                Console.WriteLine();
            }

        }

        public void text01()
        {
            chatBox num = new chatBox();
            Imige imige = new Imige();  
           
            num.point = 0;
            num.select = false;
            Console.SetCursorPosition(0, 27);
            displaychatBox();
            Console.SetCursorPosition(0, 3);
            imige.displayintrocut();
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("마을밖에 오크들이 나타났다!");
            Console.SetCursorPosition(10, 31);
            Console.WriteLine("▶  그냥 나가지 말까? ");
            Console.SetCursorPosition(10, 33);
            Console.WriteLine("    밖으로 나가 보자!");
           
            while (!num.select)
            {
                
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        num.point = (num.point == 0) ? 1 : 0;
                        break;
                    case ConsoleKey.DownArrow:
                        num.point = (num.point == 1) ? 0 : 1;
                        break;
                    case ConsoleKey.Enter:
                        num.select = true;
                        break;

                }

                Console.SetCursorPosition(35, 15);
                if (num.point == 1)
                {
                    Console.SetCursorPosition(10, 29);
                    Console.WriteLine("마을밖에 오크들이 나타났다!");
                    Console.SetCursorPosition(10, 31);
                    Console.WriteLine("    그냥 나가지 말까? ");
                    Console.SetCursorPosition(10, 33);
                    Console.WriteLine("▶  밖으로 나가 보자!");
                }
                else
                {
                    Console.SetCursorPosition(10, 29);
                    Console.WriteLine("마을밖에 오크들이 나타났다!");
                    Console.SetCursorPosition(10, 31);
                    Console.WriteLine("▶  그냥 나가지 말까? ");
                    Console.SetCursorPosition(10, 33);
                    Console.WriteLine("    밖으로 나가 보자!");

                }
               

            }
            if (num.point == 1&&num.select == true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 27);
                displaychatBox();
                Console.SetCursorPosition(0, 3);
                imige.displayintrocut();
                Console.SetCursorPosition(10, 29);
                Console.WriteLine("그럼 나가 볼까?!?");
                Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0, 27);
                displaychatBox();
                Console.SetCursorPosition(0, 3);
                imige.displayintrocut();
                Console.SetCursorPosition(10, 29);
                Console.WriteLine("그래도 왠지 나가봐야 할 것 같아! 밖으로 나가자!");
                Thread.Sleep(2000);
            }
            Console.Clear();

            
        }
        public void Text02()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(29, 21);
            Console.WriteLine("◎");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 27);
            displaychatBox();
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("아직 안으로 들어오진 않았군");
            
            
            Console.SetCursorPosition(0, 27);
            //displaychatBox();
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(10, 31);
            Console.Write("장비 보급관");
            
            Console.SetCursorPosition(22, 31);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("에게서 장비를 받아 몬스터를 처리 하러 가자!");
            Thread.Sleep(2000);

        }
        public void Text03()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("밖에 몬스터들이 몰려오고 있네!!");
            Thread.Sleep(1000);
            Console.SetCursorPosition(10, 31);
            Console.WriteLine("장비를 지급 할테니 어서 받게나!");
            Thread.Sleep(1000);
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("서둘러 장비들을 가지고 몬스터들을 처리하고 오게나!");
      


        }

        
    }
}

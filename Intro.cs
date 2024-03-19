using ConsoleProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace ConsoleProject
{
    public class Intro
    {
        
        public void Into()
        {
                  
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("아주 짧은 RPG");
            Console.SetCursorPosition(33, 25);
            Console.Write("엔터 키 입력");

            Console.SetCursorPosition(33, 25);
            Console.WriteLine("    게임 시작");
            Console.SetCursorPosition(33, 30);
            Console.WriteLine("▶  게임 종료");

            int point = 0;
            bool select = false;

            
            while (!select) 
            {
                // 처음 게임 시작 종료 선택지는 키보드 입력을 받게 만들었고 입력 받은 후 스위치문을 사용하여 작동하게 만들었습니다. 
                // 또 그안에 조건문을 넣어야 했는데 if문을 쓰면 길어질 것으로 보여 삼항 연산자를 사용 했습니다.
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                 switch (keyInfo.Key)
                 {
                    case ConsoleKey.UpArrow:
                        point = (point == 0) ? 1 : 0;
                        break;
                    case ConsoleKey.DownArrow:
                        point = (point == 1) ? 0 : 1;
                        break;
                    case ConsoleKey.Enter:
                        select = true;
                        break;

                 }
                     
                Console.Clear();
                Console.SetCursorPosition(35, 15);
                
                Console.WriteLine("아주 짧은 RPG");
                
                if (point == 1)
                {
                Console.SetCursorPosition(33, 25);
                Console.WriteLine("▶  게임 시작");
                Console.SetCursorPosition(33, 30);
                Console.WriteLine("    게임 종료");
                }
                else
                {
                Console.SetCursorPosition(33, 25);
                Console.WriteLine("    게임 시작");
                Console.SetCursorPosition(33, 30);
                Console.WriteLine("▶  게임 종료");
                }
            }
            Console.Clear(); 

            if (point == 1)
            {
                StartGame();
            }
            else
            {
                ExitGame();
            }

            // 인트로 게임 시작/종료
            static void StartGame() 
            {
                Console.WriteLine("게임을 시작 합니다.");
            }
            static void ExitGame()
            {
                Console.SetCursorPosition(27, 20);
                Console.WriteLine("게임을 종료합니다. Good bye~");
                Environment.Exit(0);


            }

        }
    }
}



















     

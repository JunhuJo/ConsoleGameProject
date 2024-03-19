using ConsoleProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static ConsoleProject.Player;

namespace ConsoleProject
{
    public class Player
    {

        #region //멤버들
        private static string Name { get; set; }
        private static int HP { get; set; } = 100;
        private static int AP { get; set; } = 10;
        private static int DP { get; set; } = 5;
        private static int x { get; set; } = 29;
        private static int y { get; set; } = 21;
        private static bool Control { get; set; }
        private static bool SeenPoint { get; set; } = true; 

        #endregion

        #region //인스턴스
        Map map = new Map();
        chatBox ChatBox = new chatBox();
        NPC npc = new NPC();
        Monster monster = new Monster();
        //EventSeen evnetlist = new EventSeen();
        //PlayerEvent playerevent = new PlayerEvent();
        #endregion

        //플레이어 이름 생성 메서드
        public void PlayerName()
        {

            Console.Clear();
            Console.SetCursorPosition(25, 20);
            Console.Write("플레이어 이름 설정 : ");
            string name = Console.ReadLine();
            Player.Name = name;

        }

        //플레이어 능력치 메서드
        public void stat()
        {
            int hp = Player.HP;
            Player.HP = hp;
            Console.SetCursorPosition(33, 25);
            Console.WriteLine($"최초 HP : {hp}");
            int ap = Player.AP;
            Player.AP = ap;
            //Thread.Sleep(1300);
            Console.SetCursorPosition(33, 27);
            Console.WriteLine($"최초 AP : {ap}");
            int dp = Player.DP;
            Player.DP = dp;
            //Thread.Sleep(1300);
            Console.SetCursorPosition(33, 29);
            Console.WriteLine($"최초 DP : {dp}");
            //Thread.Sleep(1300);

        }

        //화면에 능력치 표시 메서드
        public void displaystat()
        {
            Console.SetCursorPosition(59, 4);
            Console.WriteLine($"   Name : {Player.Name}");
            Console.SetCursorPosition(59, 6);
            Console.WriteLine($"     HP : {Player.HP}");
            Console.SetCursorPosition(59, 8);
            Console.WriteLine($"     AP : {Player.AP}");
            Console.SetCursorPosition(59, 10);
            Console.WriteLine($"     DP : {Player.DP}");
            Console.SetCursorPosition(59, 12);
            Console.WriteLine("  =============");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(59, 15);
            Console.WriteLine("  ◎ : 플레이어");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(59, 17);
            Console.WriteLine("  ● : 장비보급관");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(59, 19);
            Console.WriteLine("  ◈ : 몬 스 터");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(59, 21);
            Console.WriteLine("  ★ : 마을통로");

        }


        //플레이어 컨트롤 메서드
        public void TownPlayerControl()
        {
            Player.Control = true;
            //캐릭터 화면 출력
            while (Player.Control == true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                map.DisplayMap();
                Console.SetCursorPosition(0, 27);
                ChatBox.displaychatBox();
                displaystat();
                npc.SellNpc("장비 보급관", 50, 15);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(29, 1);
                Console.WriteLine("★");

                Console.SetCursorPosition(Player.x, Player.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("◎");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Player.y = Math.Max(0, Player.y - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        y = Math.Min(Console.WindowHeight - 1, Player.y + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.x = Math.Max(0, Player.x - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        Player.x = Math.Min(Console.WindowWidth - 1, Player.x + 1);
                        break;
                }
                if ((Player.x, Player.y) == (28, 1) || (Player.x, Player.y) == (29, 1) || (Player.x, Player.y) == (30, 1))
                {
                    Player.x = 29;
                    Player.y = 22;
                    Player.Control = false;
                }

            }
            FieldPlayerControl();

        } //마을

        public void FieldPlayerControl()//사냥 필드
        {
            
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            map.DisplayMap2();

            Console.SetCursorPosition(0, 27);
            ChatBox.displaychatBox();
            displaystat();
            monster.OrcType("오크 전사", 40, 15);

            monster.OrcBossType("정예 오크 전사", 30, 5);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(29, 23);
            Console.WriteLine("★");

            Console.SetCursorPosition(Player.x, Player.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("◎");
            


            
            while (Player.SeenPoint == true)
            { 
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(10, 29);
                Console.WriteLine("벌써 바로 앞까지 오다니! 빨리 막으러 가자!@!");
                Thread.Sleep(1300);
                Console.SetCursorPosition(10, 31);
                Console.WriteLine("엔터를 눌러 계속 진행하세요");

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(10, 31);
                        Console.WriteLine("오크들을 빨리 몰아내서 마을을 지켜내자~!@!");
                        Thread.Sleep(1300);
                        Player.SeenPoint = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(10, 31);
                        Console.WriteLine("Enter를 눌러 계속 진행하세요");
                        break;

                }
            }
            Player.Control = true;
            while (Player.Control == true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                map.DisplayMap2();

                Console.SetCursorPosition(0, 27);
                ChatBox.displaychatBox();
                displaystat();
                monster.OrcType("오크 전사", 40, 15);

                monster.OrcBossType("정예 오크 전사", 30, 5);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(29, 23);
                Console.WriteLine("★");

                Console.SetCursorPosition(Player.x, Player.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("◎");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                Console.SetCursorPosition(0, 0);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Player.y = Math.Max(0, Player.y - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        y = Math.Min(Console.WindowHeight - 1, Player.y + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.x = Math.Max(0, Player.x - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        Player.x = Math.Min(Console.WindowWidth - 1, Player.x + 1);
                        break;
                }
                if ((Player.x, Player.y) == (28, 23) || (Player.x, Player.y) == (29, 23) || (Player.x, Player.y) == (30, 23))
                {
                    Player.x = 29;
                    Player.y = 3;
                    Player.Control = false;
                }
            }
            TownPlayerControl();

        }


        //===========================================================================================================     

        //<이벤트>
        //플레이어 이벤트 핸들러
        // public class PlayerEvent
        // {
        //     #region
        //Map map = new Map();
        //chatBox ChatBox = new chatBox();
        //NPC npc = new NPC();
        //Monster monster = new Monster();
        //EventSeen evnetlist = new EventSeen();
        //PlayerEvent playerevent = new PlayerEvent();
        //#endregion
        //
        //
        //     public event EventHandler EventHand;
        //     public void StartEvent(int x, int y)
        //     {
        //
        //         if ((Player.x, Player.y) == (x, y))
        //         {
        //             EventHand(this, EventArgs.Empty);
        //         }
        //
        //     }
        //
        // }
        //
        // //플레이어 이벤트
        // public class EventSeen
        // {
        //     #region
        //Player player = new Player();
        //Map map = new Map();
        //chatBox ChatBox = new chatBox();
        //NPC npc = new NPC();
        //Monster monster = new Monster();
        //EventSeen evnetlist = new EventSeen();
        //PlayerEvent playerevent = new PlayerEvent();
        //#endregion
        //
        //     public void eventseen01(bool a, EventArgs e)
        //     {
        //         SeenPoint = a;
        //         if (SeenPoint == true)
        //         {
        //             Player.Control = false;
        //             while (Player.Control == false)
        //             {
        //                 Console.ForegroundColor = ConsoleColor.White;
        //                 Console.SetCursorPosition(10, 29);
        //                 Console.WriteLine("벌써 바로 앞까지 오다니! 빨리 막으러 가자!@!");
        //                 Thread.Sleep(1300);
        //                 Console.SetCursorPosition(10, 31);
        //                 Console.WriteLine("엔터를 눌러 계속 진행하세요");
        //
        //                 ConsoleKeyInfo key = Console.ReadKey(true);
        //                 switch (key.Key)
        //                 {
        //                     case ConsoleKey.Enter:  
        //                         Console.ForegroundColor = ConsoleColor.White;
        //                         Console.SetCursorPosition(10, 31);
        //                         Console.WriteLine("오크들을 빨리 몰아내서 마을을 지켜내자~!@!");
        //                         Thread.Sleep(1300);
        //                         Player.Control = true;
        //                         break;
        //                     default:
        //                         Console.ForegroundColor = ConsoleColor.White;
        //                         Console.SetCursorPosition(10, 31);
        //                         Console.WriteLine("Enter를 눌러 계속 진행하세요");
        //                         break;
        //
        //                 }
        //             }
        //
        //         }
        //     }
        //     public void eventseen02(bool a, EventArgs e)
        //     {
        //         Console.ForegroundColor = ConsoleColor.White;
        //         Console.SetCursorPosition(0, 0);
        //         map.DisplayMap2();
        //
        //         Console.SetCursorPosition(0, 27);
        //         ChatBox.displaychatBox();
        //         player.displaystat();
        //         monster.OrcType("오크 전사", 40, 15);
        //
        //         monster.OrcBossType("정예 오크 전사", 30, 5);
        //
        //         Console.ForegroundColor = ConsoleColor.Yellow;
        //         Console.SetCursorPosition(29, 23);
        //         Console.WriteLine("★");
        //
        //         Console.SetCursorPosition(Player.x, Player.y);
        //         Console.ForegroundColor = ConsoleColor.Green;
        //         Console.WriteLine("◎");
        //
        //     }
        //
        //
        // }
        //
    }
}
using ConsoleProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static ConsoleProject.ProgramMain;

namespace ConsoleProject
{

    internal class ProgramMain
    {
        private int x { get; set; }
        private int y { get; set; }
        private bool SeenPoint { get; set; }

        static void Main(string[] args)
        {

            Map map = new Map();

            Intro intro = new Intro();
            Player player = new Player();
            chatBox chatbox = new chatBox();

            //타이틀 설정
            Console.Title = "아주 짧은 RPG";

            //화면 사이즈 설정
            Console.SetWindowSize(80, 40);
            Console.SetBufferSize(80, 40);
            Console.CursorVisible = false;
            Console.Clear();

            //인트로 화면
            intro.Into();
            Console.Clear();

            // 플레이어 이름 설정
            player.PlayerName();
            player.stat();
            Console.Clear();

            //플레이 초반 대사               
            chatbox.text01();
            map.DisplayMap();
            chatbox.Text02();
            Console.Clear();


            //플레이어 조작 (마을부터 시작)

            player.TownPlayerControl();

        }

    }
    //================================================
    //플레이어
    public class Player
    {
        //플레이어 필드
        #region 
        private static string Name { get; set; }
        private static int HP { get; set; } = 100;
        private static int AP { get; set; } = 10;
        private static int DP { get; set; } = 5;
        private static int x { get; set; } = 29;
        private static int y { get; set; } = 21;

        private static bool Control { get; set; }
        private static bool SeenPoint { get; set; } = true;
        private static int FIeldNumber { get; set; }

        #endregion
        //플레이어 인스턴스
        #region 
        Map map = new Map();
        chatBox ChatBox = new chatBox();
        NPC npc = new NPC();
        Monster monster = new Monster();
        PlayerInventory playerInventory = new PlayerInventory();
        #endregion

        //플레이어 이름 생성
        public void PlayerName()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(27, 20);
                Console.WriteLine("(최대 4자 가능)");
                Console.SetCursorPosition(25, 22);
                Console.Write("플레이어 이름 설정 : ");
                string name = Console.ReadLine();


                Console.SetCursorPosition(25, 18);

                Player.Name = name;
                if (name.Length > 5)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("글자수를 초과 하였습니다. 다시 입력 하세요.");
                    Thread.Sleep(1000);

                }
                else if (name.Length == 0)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("1글자 이상 입력해야 합니다. 다시 입력하세요.");
                    Thread.Sleep(1000);

                }
                else
                {
                    Console.SetCursorPosition(25, 20);
                    Console.WriteLine("게임을 시작합니다.          ");
                    Thread.Sleep(1000);
                    break;
                }

            }

        }

        //플레이어 능력치
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

        //화면에 능력치 표시
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


        //================================================     

        //조작 컨트롤
        public class Key
        {

            public void MoveUp()
            {
                Player.y = Math.Max(0, Player.y - 1);
                for (int i = 2; i < 56; i++)
                {
                    if ((Player.x, Player.y) == (i, 1))
                    {
                        Player.y++;
                    }
                }

            }


            public void MoveDown()
            {
                Player.y = Math.Min(Console.WindowHeight - 1, Player.y + 1);
                for (int i = 2; i < 56; i++)
                {
                    if ((Player.x, Player.y) == (i, 23))
                    {
                        Player.y--;
                    }
                }
            }

            public void MoveLeft()
            {
                Player.x = Math.Max(0, Player.x - 1);
                for (int i = 2; i < 29; i++)
                {
                    if ((Player.x, Player.y) == (3, i))
                    {
                        Player.x++;
                    }
                }
            }

            public void MoveRight()
            {
                Player.x = Math.Min(Console.WindowWidth - 1, Player.x + 1);
                for (int i = 2; i < 29; i++)
                {
                    if ((Player.x, Player.y) == (55, i))
                    {
                        Player.x--;
                    }
                }

            }

        }

        //플레이어 인벤토리
        public class PlayerInventory()
        {
            public List<Item> playerinven = new List<Item>();

        }

        //================================================    

        //보급관
        public class NPCList
        {
            public List<Item> npclist = new List<Item>();
            Player player = new Player();
            chatBox chatBox = new chatBox();
            Imige imige = new Imige();

            public void NPCinvenSet()
            {

                Weapon sword = new Weapon("장검", 10);
                Armor armor = new Armor("철제 갑옷", 10);
                Potion potion = new Potion("체력 회복 물약", 10);
                npclist.Add(sword);
                npclist.Add(armor);
                npclist.Add(potion);



            }
            //보급관 > 플레이어로 아이템 이동 메서드
            public static void MoveItem(List<Item> npclist, List<Item> playerinven, string itemName)
            {

                Item itemToMove = npclist.Find(item => item.Name == itemName);
                if (itemToMove != null)
                {
                    npclist.Remove(itemToMove);
                    playerinven.Add(itemToMove);
                    Console.SetCursorPosition(10, 33);
                    Console.WriteLine($"{itemName}을 획득 하였습니다.                    ");
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(10, 35);
                    Console.Write("아직 받을 장비가 남아 있다네!                        ");
                    Thread.Sleep(1000);
                }
                else
                {

                    Console.SetCursorPosition(10, 33);
                    Console.Write("(1. 장검(공격력 10) , 2. 철제 갑옷(방어력 10), 3. 체력 회복 물약(체력 10회복))                        ");
                    Console.SetCursorPosition(10, 33);
                    Console.WriteLine($"{itemName}은 이미 지급을 했다네 다시 확인해보게                 ");
                    Thread.Sleep(1000);

                }

            }

            //==============================================
            //보급관 상호작용
            public void NPCStore()
            {
                NPCinvenSet();
                chatBox.Text03();

                bool seenOff = false;
                while (seenOff == false)
                {
                    Console.SetCursorPosition(10, 31);
                    Console.Write("해당 숫자를 입력하면 장비를 습득 합니다.");
                    Console.SetCursorPosition(10, 33);
                    Console.Write("(1. 장검 , 2. 철제 갑옷, 3. 체력 회복 물약)                        ");


                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            MoveItem(npclist, player.playerInventory.playerinven, "장검");
                            break;
                        case 2:
                            MoveItem(npclist, player.playerInventory.playerinven, "철제 갑옷");
                            break;
                        case 3:
                            MoveItem(npclist, player.playerInventory.playerinven, "체력 회복 물약");
                            break;
                        default:
                            Console.SetCursorPosition(10, 31);
                            Console.WriteLine("잘못 입력 했습니다. 다시 입력해주세요                     ");
                            break;

                    }

                    // 보급관의 모든 아이템을 획득한 경우
                    if (npclist.Count == 0)
                    {
                        seenOff = true;
                        Console.SetCursorPosition(10, 31);
                        Console.WriteLine("장비는 모두 지급 됬으니 어서 마을 밖으로 나가 보게!                ");
                        Console.SetCursorPosition(10, 33);
                        Console.WriteLine("행운을 빌겠네!!                                                    ");
                        Console.SetCursorPosition(10, 35);
                        Console.WriteLine("                                                                   ");
                    }
                }


            }
            //플레이어 인벤토리
            public void PlayerInventoryPrint()
            {


                bool invenOff = false;

                while (invenOff == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    imige.displayplayerinventoryimige();
                    Console.SetCursorPosition(0, 27);
                    chatBox.displaychatBox();
                    player.displaystat();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(37, 3);
                    Console.WriteLine("인벤토리(i)");

                    Console.SetCursorPosition(10, 5);

                    for (int i = 0; i < player.playerInventory.playerinven.Count; i++)
                    {
                        Console.SetCursorPosition(35, 7 + i);
                        Console.WriteLine($"->  {player.playerInventory.playerinven[i].Name}");
                        if ((player.playerInventory.playerinven.Count) == 0)
                        {
                            Console.SetCursorPosition(37, 7);
                            Console.WriteLine("비어 있음");
                        }

                    }

                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.I:
                            invenOff = true;
                            Console.Clear();
                            break;
                        default:

                            break;
                    }

                }

            }


        }

        //================================================    


        //플레이어 컨트롤
        public void TownPlayerControl()
        {

            int FIeldNumber = 1;
            int Boss = 1;
            int Mon = 1;

            Player.Control = true;
            Key key = new Key();
            chatBox ChatBox = new chatBox();
            Imige imige = new Imige();
            NPCList nPCList = new NPCList();
            PlayerInventory playerInventory = new PlayerInventory();
            bool on = true;

            while (Player.Control == true)
            {
                //마을 필드
                if (FIeldNumber == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    map.DisplayMap();
                    Console.SetCursorPosition(0, 27);
                    ChatBox.displaychatBox();
                    displaystat();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(29, 2);
                    Console.WriteLine("★");

                    Console.SetCursorPosition(Player.x, Player.y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("◎");

                    npc.SellNpc("장비 보급관", 50, 15);
                    if ((Player.x, Player.y) == (48, 15) && (on == true) || (Player.x, Player.y) == (50, 14) && (on == true) || (Player.x, Player.y) == (50, 16) && (on == true))
                    {
                        nPCList.NPCStore();
                        on = false;
                    }
                    else if ((Player.x, Player.y) == (48, 15) && (on == false) || (Player.x, Player.y) == (50, 14) && (on == false) || (Player.x, Player.y) == (50, 16) && (on == false))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(10, 31);
                        Console.WriteLine("장비는 모두 지급했네 어서 밖으로 나가보게!@!                  ");

                    }
                }

                // 사냥 필드
                else if (FIeldNumber == 2)
                {

                    int blockx = Player.x;
                    int blocky = Player.y;
                    PlayerInventory inventory = new PlayerInventory();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    map.DisplayMap2();

                    Console.SetCursorPosition(0, 27);
                    ChatBox.displaychatBox();
                    displaystat();
                    monster.OrcType("슬라임", 40, 15);

                    monster.OrcBossType("킹슬라임", 30, 5);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(29, 22);
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

                        ConsoleKeyInfo Keyinfo = Console.ReadKey(true);
                        switch (Keyinfo.Key)
                        {
                            case ConsoleKey.Enter:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(10, 31);
                                Console.WriteLine("슬라임들을 빨리 몰아내서 마을을 지켜내자~!@!");
                                Thread.Sleep(1300);
                                Player.SeenPoint = false;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(10, 31);
                                Console.WriteLine("Enter를 눌러 계속 진행하세요");
                                break;

                        }
                        Player.Control = true;


                        #region
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 0);
                        map.DisplayMap2();

                        Console.SetCursorPosition(0, 27);
                        ChatBox.displaychatBox();
                        displaystat();
                        monster.OrcType("슬라임", 40, 15);

                        monster.OrcBossType("킹슬라임", 30, 5);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(29, 22);
                        Console.WriteLine("★");

                        Console.SetCursorPosition(Player.x, Player.y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("◎");
                        #endregion

                    }
                    if ((Player.x, Player.y) == (30, 5) && Boss == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        imige.displaymonsterbackimige();
                        Console.SetCursorPosition(0, 27);
                        Console.ForegroundColor = ConsoleColor.White;
                        ChatBox.displaychatBox();
                        Console.SetCursorPosition(10, 29);
                        Console.WriteLine("킹슬라임이 강력한 공격을 하기 시작 했다!");

                        Console.SetCursorPosition(10, 29);
                        Console.WriteLine("전투 승리! 아무키나 누르세요");
                        Console.ReadLine();
                        Boss--;


                    }
                    else if ((Player.x, Player.y) == (40, 15) && Mon == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.White;
                        //imige.displaymonsterbackimige();
                        //Console.SetCursorPosition(0, 0);
                        //Console.ForegroundColor = ConsoleColor.Green;
                        imige.displaymonsterimige();
                        Console.SetCursorPosition(0, 27);
                        Console.ForegroundColor = ConsoleColor.White;
                        ChatBox.displaychatBox();
                        Console.SetCursorPosition(10, 29);
                        Console.WriteLine("슬라임이 공격을 하기 시작 했다!");
                       
                        Console.SetCursorPosition(10, 31);
                        Console.WriteLine("    공격스킬");
                        Console.SetCursorPosition(10, 33);
                        Console.WriteLine("▶  전투종료");


                        int point = 0;
                        bool select = false;

                        while (!select)
                        {
                            ConsoleKeyInfo Keyinfo = Console.ReadKey(true);
                            switch (Keyinfo.Key)
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
                            if (point == 1)
                            {
                                Console.SetCursorPosition(10, 31);
                                Console.WriteLine("▶  공격스킬");
                                Console.SetCursorPosition(10, 33);
                                Console.WriteLine("    전투종료");
                            }
                            else
                            {
                                Console.SetCursorPosition(10, 31);
                                Console.WriteLine("    공격스킬");
                                Console.SetCursorPosition(10, 33);
                                Console.WriteLine("▶  전투종료");
                            }
                            
                        }
                        

                    }


                }
                //플레이어 키조작
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        key.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        key.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        key.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        key.MoveRight();
                        break;
                    case ConsoleKey.I:
                        nPCList.PlayerInventoryPrint();
                        break;

                }

                //맵 이동 조건
                #region
                if ((Player.x, Player.y) == (29, 2))
                {
                    Player.x = 29;
                    Player.y = 21;

                    FIeldNumber = 2;
                }
                else if ((Player.x, Player.y) == (29, 22))
                {
                    Player.x = 29;
                    Player.y = 4;

                    FIeldNumber = 1;
                }
                #endregion

            }

        }
    }
}

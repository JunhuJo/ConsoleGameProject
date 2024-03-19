using ConsoleProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static ConsoleProject.Player;

namespace ConsoleProject
{
    internal class AllGameMain
    { 
        private int x {  get; set; }
        private int y { get; set; }
        private bool SeenPoint{ get; set; }
      
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
        
}


﻿using ConsoleProject;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Map
    {
                
        public string[,] map01 = {

                {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","  ","  ","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","  ","  ","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"}, };


        public string[,] map02 = {
                    {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                    {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  ","■","■","  ","  ","  ","  ","  ","  ","  ","  ","■","■"},
                    {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","  ","  ","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"},
                    {"■","■","■","■","■","■","■","■","■","■","■","■","■","■","  ","  ","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■","■"}, };

        public void DisplayMap()
            {
            for (int i = 0; i < map01.GetLength(0); i++)
            {
                for (int j = 0; j < map01.GetLength(1); j++)
                {
                    Console.Write(map01[i, j]);
                }
                Console.WriteLine();
            }

            }
        
        
        public void DisplayMap2()
        {
            for (int i = 0; i < map02.GetLength(0); i++)
            {
                for (int j = 0; j < map02.GetLength(1); j++)
                {
                    Console.Write(map02[i, j]);
                }
                Console.WriteLine();
            }


        }

        



    }
       
}

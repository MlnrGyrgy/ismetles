﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace ismetles
{
    class Program
    {
        static string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };
        static int GepValasztasa()
        {
            Random vel = new Random();


            return vel.Next(0, 3);
        }
        static int JatekosValasztas()
        {
            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válassz: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static int EmberNyer(int gep, int ember)
        {
            if (ember == gep)//Döntetlen
            {
                Console.WriteLine("Döntetlen");
                return 0;
            }
            else if (
                    (ember == 0 && gep == 1)
                    ||
                    (ember == 1 && gep == 2)
                    ||
                    (ember == 2 && gep == 0)
                    )//Gép nyer

            {               
                Console.WriteLine("Gép nyert!");
                return 1;
            }
            else //Játékos nyer
            {
                Console.WriteLine("Nyertél");
                return 2;
            }
        }
        static void EredmenyKiiras(int gep, int ember)
        {
                        Console.WriteLine("Gép: {0}--- Játékos: {1}", lehetoseg[gep], lehetoseg[ember]);
            switch (EmberNyer(gep, ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen.");
                    break;
                case 1:
                    Console.WriteLine("Gép győzött.");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert.");
                    break;

            }
        }
        static void Main(string[] args)
        {
           

            //Console.WriteLine("Gép választása: {0}", lehetoseg[gepValasz]);

           
            Console.WriteLine("Játékos választása", lehetoseg[]);

            int gepValasz = GepValasztasa();

            int jatekosValasz = JatekosValasztas();

            EredmenyKiiras(gepValasz, jatekosValasz);
            
            Console.ReadKey();
   
        }
    }
}

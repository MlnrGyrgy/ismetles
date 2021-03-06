﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.IO;

namespace ismetles
{
    class Program
    {
        static int gepNyer = 0;
        static int jatekosNyer = 0;
        static int menet = 0;
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
                gepNyer++;
                return 1;
               
            }
            else //Játékos nyer
            {
                Console.WriteLine("Nyertél");
                jatekosNyer++;
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
            statisztikaFajlbol();
            bool tovabb = true;

            //Console.WriteLine("Gép választása: {0}", lehetoseg[gepValasz]);
            //Console.WriteLine("Játékos választása: {0}", lehetoseg[JatekosValasztas]);

            while (tovabb)
            {
                menet++;

                int gepValasz = GepValasztasa();

                int jatekosValasz = JatekosValasztas();

                EredmenyKiiras(gepValasz, jatekosValasz);

                tovabb = AkarJatszani();
            }
            statisztikaKiiras();
            statisztikaFajlba();
            Console.ReadKey();

        }

        private static bool AkarJatszani()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.Write("Tovább? [i/n]: ");
            string valasz = Console.ReadLine().ToLower();
            if (valasz == "i")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void statisztikaKiiras()
        {
            Console.WriteLine("Menetek száma: {0}" + "\t Játékos győzelmének száma {1}" + "\t Gép győzelmének száma {2}", menet,jatekosNyer,gepNyer);
        }
        private static void statisztikaFajlbol()
        {
            StreamReader stat = new StreamReader("Statisztika.txt");
            while (!stat.EndOfStream)
            {
                string[] szovegAdat =stat.ReadLine().Split(';');
                int[] sor = new int[3];
                for (int i = 0; i < sor.Length; i++)
                {
                    sor[i] = int.Parse(szovegAdat[i]);
                }
                Console.WriteLine("{0} {1} {2}", sor[0],sor[1],sor[2]);
            }
            stat.Close();
            Console.WriteLine("----------------> Statisztika vége <----------------");
        }
        private static void statisztikaFajlba()
        {
          string adat =  menet.ToString() + ";" + jatekosNyer.ToString() + ";" + gepNyer.ToString();
            //FileStream ki = new FileStream("Statisztika.txt",FileMode.Append);
            StreamWriter kiir = new StreamWriter("Statisztika.txt",true);
            kiir.WriteLine(adat);
            //kiir.WriteLine("{0};", menet);
            // kiir.Write("{0};", jatekosNyer);
            //kiir.Write("{0}", gepNyer);
            kiir.Close();
            

        }
    }
}

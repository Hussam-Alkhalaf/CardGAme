using System.Collections.Generic;
using System;
using System.Linq;
using CardGame;


namespace CardGame
{
    internal class Program
    {
        static void Main()
        {
            List<int> cards = new List<int>();
            for (int i = 1; i <= 21; i++)
            {
                cards.Add(i);
            }
            Random random = new Random();

            // خلط البطاقات عشوائياً
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            // توزيع البطاقات على الأعمدة
            for (int round = 0; round < 3; round++) 
                
            {
                List<int>[] columns = { new List<int>(), new List<int>(), new List<int>() };
                for (int i = 0; i < cards.Count; i++)
                {
                    columns[i % 3].Add(cards[i]);
                }

                Console.WriteLine("Die Karten sind auf 3 Spalten geteilt:");
                for (int row = 0; row < 7; row++)
                {
                    Console.WriteLine($" {columns[0][row],2} | {columns[1][row],2} | {columns[2][row],2} ");
                }

                // طلب اختيار العمود من المستخدم
                Console.Write("Wählen Sie die Spalte (1, 2, 3): ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.Write("Ungültige Eingabe. Wählen Sie die Spalte erneut (1, 2, 3): ");
                }

                // إعادة ترتيب البطاقات حسب اختيار المستخدم
                if (choice == 1)
                {
                    cards = columns[1].Concat(columns[0]).Concat(columns[2]).ToList();
                }
                else if (choice == 2)
                {
                    cards = columns[0].Concat(columns[1]).Concat(columns[2]).ToList();
                }
                else
                {
                    cards = columns[0].Concat(columns[2]).Concat(columns[1]).ToList();
                }
            }

            Console.WriteLine("Die Karte ist : " + cards[10]);
            Console.ReadLine();
        }
    }
}

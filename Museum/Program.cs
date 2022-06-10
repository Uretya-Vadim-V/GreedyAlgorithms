using System;
using System.Collections.Generic;

namespace Museum
{
    class Program
    {
        // Музей (2.5)
        static void Main()
        {
            Console.Write("Введите количество школьников (1 <= N <= 10^5)\nN = ");
            int n = Int32.Parse(Console.ReadLine());
            Random rand = new();
            List<int> start = new();
            List<int> finish = new();
            int hourS, minuteS, hourF, minuteF;
            int s = 0, f = 0, count = 0, k;
            for (int i = 0; i < n; i++)
            {
                hourS = rand.Next(0, 24);
                minuteS = rand.Next(0, 60);
                hourF = rand.Next(hourS, 24);
                minuteF = rand.Next((hourF == hourS) ? minuteS + 1 : 0, 60);
                start.Add(hourS * 60 + minuteS);
                finish.Add(hourF * 60 + minuteF);
                Console.WriteLine($"{hourS:d2}:{minuteS:d2} {hourF:d2}:{minuteF:d2}");
            }
            start.Sort();
            finish.Sort();
            while (s < n && f < n)
            {
                while (start[s] <= finish[f])
                {
                    s++;
                    if (s == n) break;
                }
                k = s - f;
                if (k > count) count = k;
                f++;
            }
            Console.WriteLine($"Максимальное количество посетителей, одновременно находящихся в музее: {count}");
        }
    }
}

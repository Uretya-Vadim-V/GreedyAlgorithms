using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithms
{
    // Прогульщики (1.5)
    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество школьников (1 <= N <= 2000)\nN = ");
            int n = Int32.Parse(Console.ReadLine());
            Random rand = new();
            SortedDictionary<int, List<KeyValuePair<int, int>>> dic = new();
            List<int> list = new();
            int h, l, count = 0;
            for (int i = 1; i <= n; i++)
            {
                // Ручной ввод
                /*
                Console.WriteLine("Введите рост (1 <= h <= 10^5)\nh = ");
                h = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите длину рук (1 <= h <= 10^5)\nl = ");
                l = Int32.Parse(Console.ReadLine());
                */
                //
                h = rand.Next(1, 1001);
                l = rand.Next(1, 1001);
                if (dic.ContainsKey(h))
                    dic[h].Add(new KeyValuePair<int, int>(i, l));
                else
                {
                    dic[h] = new();
                    dic[h].Add(new KeyValuePair<int, int>(i, l));
                }
                Console.WriteLine($"{i}) {h} {l}");
            }
            Console.Write("Введите глубину ямы (1 <= H <= 10^5)\nH = ");
            int H = int.Parse(Console.ReadLine());
            ICollection<int> keys = dic.Keys;
            foreach (int item in keys.Reverse())
            {
                foreach (KeyValuePair<int, int> keyValue in dic[item])
                {
                    count += item;
                    if ((count + keyValue.Value) < H)
                    {
                        n--;
                    }
                    else
                    {
                        count -= item;
                        list.Add(keyValue.Key);
                    }
                }
            }
            Console.WriteLine($"Наибольшее количество школьников, которые смогут выбраться из ямы: {n}");
            if (n > 0)
            {
                Console.Write("Номера тех, кто сумел выбраться из ямы: ");
                foreach (int item in list)
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}

using System;

namespace C24089036_W3_practice_2
{
    class Program
    {
        static int Main(string[] args)
        {
            int size, num;

            try
            {
                Console.Write("地圖大小(1~10):");
                size = int.Parse(Console.ReadLine());
                if (size < 0 || size > 10)
                {
                    Console.WriteLine("超出範圍");
                    Console.ReadKey();
                    return -1;
                }
                Console.Write("地雷數量(1~10):");
                num = int.Parse(Console.ReadLine());
                if (num < 0 || num > 10)
                {
                    Console.WriteLine("超出範圍");
                    Console.ReadKey();
                    return -1;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return -1;
            }

            int[,] mine = new int[size+2, size+2];

            for (int i=0; i<num; i++)
            {
                int x, y;

                Console.Write(value: $"第 {i} 個地雷的位置(以空白區隔):");
                try
                {
                    string input = Console.ReadLine();
                    string[] inputnum = input.Split(' ');
                    x = int.Parse(inputnum[1]);
                    y = int.Parse(inputnum[0]);
                    if(x<0 || x>=size || y<0 || y>=size)
                    {
                        Console.WriteLine("地雷位置超出範圍");
                        Console.ReadKey();
                        return -1;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("請輸入兩個以空白區隔的整數");
                    Console.ReadKey();
                    return -1;
                }

                mine[x+1, y+1] = -1;
            }
            DiaplayMine(mine);
            Console.ReadKey();

            return 0;
        }

        private static void DiaplayMine(int[,] mine)
        {
            CheckMineNum(mine);
            Console.WriteLine("---");
            for (int i = 1; i < mine.GetLength(0)-1; i++)
            {
                for (int j = 1; j < mine.GetLength(0)-1; j++)
                {
                    if (mine[i, j] == -1)
                        Console.Write("X");
                    else
                        Console.Write(mine[i, j].ToString());
                }
                Console.WriteLine("");
            }
        }

        private static void CheckMineNum(int[,] mine)
        {
            int num;
            for (int i = 1; i < mine.GetLength(0)-1; i++)
            {
                for (int j = 1; j < mine.GetLength(0)-1; j++)
                {
                    num = 0;
                    for (int m=i-1; m<=i+1; m++)
                    {
                        for (int n = j - 1; n <= j + 1; n++)
                        {
                            if (mine[m, n] == -1)
                                num += 1;
                            if (mine[i, j] != -1)
                                mine[i, j] = num;
                        }
                    }
                }
            }
        }

    }
}

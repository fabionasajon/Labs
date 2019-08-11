using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace Algorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //solution(new int[] { 1});

            int[] a = new int[] { 2147483647 };

            //List<int> res = CompareTriplets(new List<int> { 1, 3, 6 }, new List<int> { 4, 2, 6 });

            //int i = RetMaxOcur(7,a);

            //int i = StackMachine("13 DUP 4 POP 5 DUP + DUP + -");

            //int i = FrogJump(10,100,10);

            //int i = FindMissing(a);

            //int i = IsPermutation(a);

            //timeConversion("12:01:50AM");

            //biggerIsGreater("imllmmcslslkyoegymoa");

            //int i = ArrayDominator(a);

            //int[] i = climbingLeaderboard(new int[] { 1,2,3,4,5,6,7,8,9}, new int[] { 2,3,5,5,10});

            //int i = minimumMoves(new string[] { ". X .", ". . .", "X . ." }, 0, 0, 2, 2);

            //int maxGap = BinaryGap(1041);

            //int[] test = new int[200000];

            //Random r = new Random();

            //for (int i = 0; i < test.Length; i++)
            //{
            //    test[i] = r.Next(0, 2);
            //}

            //int pc = PassingCars(new int[]{1,0,0,1,1,1,0});

            //int pc = SliceSort(new int[] { 2,4,1,6,5,9,7 });

            //string s = solution(5, 2, new int[] { 2, 1, 1, 0, 1 });

            //int max = pickingNumbers(new List<int>{1, 2,2});

            //formingMagicSquare(null);

            //int i = nonDivisibleSubset(3, new int[]{1, 7, 2, 4});

            //int i = jumpingOnClouds(new int[]{0, 0});

            //int i = equalizeArray(new int[]{3, 3,3});

            int[][] x = new int[0][];

            //x[0] = new int[] {5,5};
            //x[1] = new int[] { 4,2 };
            //x[2] = new int[] { 2,3 };

            //string res = organizingContainers(x);

            //string time = timeInWords(12, 10);

            //int i = queensAttack(5,3,4,3,x);

            int i = chocolateFeast(6, 2, 2);

        }

        static int chocolateFeast(int n, int c, int m)
        {
            int cont = n / c;

            int wrp = cont;

            while(wrp >=m)
            {
                int bonus = wrp / m;

                int res = wrp % m;

                wrp = bonus + res;

                cont += bonus;

            }

            return cont;

        }

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            int cont = 0;

            int obs = 0;

            int[][] aux = obstacles;

            if (aux.Length > 0)
            {
                for (int r = 0; r < aux.Length; r++)
                {
                    if (aux[r][1] == c_q && aux[r][0] < r_q)
                    {
                        if (aux[r][0] > obs)
                            obs = obstacles[r][0];

                        aux[r][0] = 0;

                    }

                }

                aux = aux.Where(a => a[0] != 0).ToArray();

                cont += r_q - 1 - obs;
            }
            else
                cont += r_q - 1;

            if (aux.Length > 0)
            {
                obs = n + 1;
                for (int r = 0; r < aux.Length; r++)
                {
                    if (aux[r][1] == c_q && aux[r][0] > r_q)
                    {
                        if (aux[r][0] < obs)
                            obs = aux[r][0];

                        aux[r][0] = 0;
                    }

                }

                cont += obs - r_q - 1;

                aux = aux.Where(a => a[0] != 0).ToArray();
            }
            else
                cont += n - r_q;


            if (aux.Length > 0)
            {
                obs = n + 1;
                for (int r = 0; r < aux.Length; r++)
                {
                    if (aux[r][0] == r_q && aux[r][1] > c_q)
                    {
                        if (aux[r][1] < obs)
                            obs = aux[r][1];

                        aux[r][0] = 0;
                    }

                }

                cont += obs - c_q - 1;

                aux = aux.Where(a => a[0] != 0).ToArray();
            }
            else
                cont += n - c_q;

            if (aux.Length > 0)
            {
                obs = 0;
                for (int r = 0; r < aux.Length; r++)
                {
                    if (aux[r][0] == r_q && aux[r][1] < c_q)
                    {
                        if (aux[r][1] > obs)
                            obs = aux[r][1];

                        aux[r][0] = 0;
                    }

                }

                cont += c_q - obs - 1;

                aux = aux.Where(a => a[0] != 0).ToArray();
            }
            else
                cont += c_q - 1;


            int r_aux = r_q - 1;
            int c_aux = c_q - 1;


            if (aux.Length > 0)
            {
                while (r_aux > 0 && c_aux > 0)
                {
                    if (!temObst(ref aux, r_aux, c_aux))
                        cont++;
                    else
                        break;

                    r_aux--;
                    c_aux--;
                }
            }
            else
                cont += (r_q < c_q ? r_q : c_q) - 1;


            r_aux = r_q + 1;
            c_aux = c_q - 1;


            while (r_aux <= n && c_aux > 0)
            {
                if (!temObst(ref aux, r_aux, c_aux))
                    cont++;
                else
                    break;

                r_aux++;
                c_aux--;
            }



            r_aux = r_q + 1;
            c_aux = c_q + 1;

            while (r_aux <= n && c_aux <= n)
            {
                if (!temObst(ref aux, r_aux, c_aux))
                    cont++;
                else
                    break;

                r_aux++;
                c_aux++;
            }



            r_aux = r_q - 1;
            c_aux = c_q + 1;

            while (r_aux > 0 && c_aux <= n)
            {
                if (!temObst(ref aux, r_aux, c_aux))
                    cont++;
                else
                    break;

                r_aux--;
                c_aux++;
            }

            return cont;
            
            
        }

        public static bool temObst(ref int[][] obstacles, int r_q, int c_q)
        {
            for (int r = 0; r < obstacles.Length; r++)
            {
                if (obstacles[r][0] == r_q && obstacles[r][1] == c_q)
                {
                    obstacles[r][0] = 0;
                    obstacles = obstacles.Where(a => a[0] != 0).ToArray();
                    return true;
                }
            }

            return false;
        }

        //Ajustar performance, os resultados estão certos
        //static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        //{

        //    int cont = 0;

        //    if (r_q > 0)
        //    {
        //        for (int r = r_q - 1; r > 0; r--)
        //        {
        //            if (!temObst(obstacles, r, c_q))
        //                cont++;
        //            else
        //                break;
        //        }
        //    }

        //    if (r_q < n)
        //    {
        //        for (int r = r_q + 1; r <= n; r++)
        //        {
        //            if (!temObst(obstacles, r, c_q))
        //                cont++;
        //            else
        //                break;
        //        }
        //    }

        //    if (c_q > 0)
        //    {
        //        for (int c = c_q - 1; c > 0; c--)
        //        {
        //            if (!temObst(obstacles, r_q, c))
        //                cont++;
        //            else
        //                break;
        //        }
        //    }

        //    if (c_q < n)
        //    {
        //        for (int c = c_q + 1; c <= n; c++)
        //        {
        //            if (!temObst(obstacles, r_q, c))
        //                cont++;
        //            else
        //                break;
        //        }
        //    }

        //    int r_aux = r_q - 1;
        //    int c_aux = c_q - 1;

        //    if (r_q > 0 && c_q > 0)
        //    {
        //        while (r_aux > 0 && c_aux > 0)
        //        {
        //            if (!temObst(obstacles, r_aux, c_aux))
        //                cont++;
        //            else
        //                break;

        //            r_aux--;
        //            c_aux--;
        //        }
        //    }

        //    r_aux = r_q + 1;
        //    c_aux = c_q - 1;

        //    if (r_q <= n && c_q > 0)
        //    {
        //        while (r_aux <= n && c_aux > 0)
        //        {
        //            if (!temObst(obstacles, r_aux, c_aux))
        //                cont++;
        //            else
        //                break;

        //            r_aux++;
        //            c_aux--;
        //        }
        //    }

        //    r_aux = r_q + 1;
        //    c_aux = c_q + 1;

        //    if (r_q <= n && c_q <= n)
        //    {
        //        while (r_aux <= n && c_aux <= n)
        //        {
        //            if (!temObst(obstacles, r_aux, c_aux))
        //                cont++;
        //            else
        //                break;

        //            r_aux++;
        //            c_aux++;
        //        }
        //    }

        //    r_aux = r_q - 1;
        //    c_aux = c_q + 1;

        //    if (r_q > 0 && c_q <= n)
        //    {
        //        while (r_aux > 0 && c_aux <= n)
        //        {
        //            if (!temObst(obstacles, r_aux, c_aux))
        //                cont++;
        //            else
        //                break;

        //            r_aux--;
        //            c_aux++;
        //        }
        //    }

        //    return cont;
        //}

        static string timeInWords(int h, int m)
        {

            string hour = IntegerToWritten(h);

            if (m == 0)
                return hour + " o' clock";

            if (m == 15)
                return "quarter past " + hour;

            if(m==30)
                return "half past " + hour;

            if(m==45)
            {
                if (h == 12)
                    return "quarter to one";
                else
                {
                    hour = IntegerToWritten(h+1);
                    return "quarter to " + hour;
                }
            }

            string min = IntegerToWritten(m);

            if (m < 30)
            {
                if(m == 1)
                    return min + " minute past " + hour;
                else
                    return min + " minutes past " + hour;
            }
            else
            {
                if (h == 12)
                    hour = "one";
                else
                    hour = IntegerToWritten(h + 1);

                if(m == 59)
                    return "one minute to " + hour;

                return IntegerToWritten(60 - m) + " minutes to " + hour;
            }

        }

        static string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };

        private static string FriendlyInteger(int n, string leftDigits, int thousands)
        {
            if (n == 0)
            {
                return leftDigits;
            }

            string friendlyInt = leftDigits;

            if (friendlyInt.Length > 0)
            {
                friendlyInt += " ";
            }

            if (n < 10)
            {
                friendlyInt += ones[n];
            }
            else if (n < 20)
            {
                friendlyInt += teens[n - 10];
            }
            else if (n < 100)
            {
                friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
            }
            else if (n < 1000)
            {
                friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
            }
            else
            {
                friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands+1), 0);
                if (n % 1000 == 0)
                {
                    return friendlyInt;
                }
            }

            return friendlyInt + thousandsGroups[thousands];
        }

        public static string IntegerToWritten(int n)
        {
            if (n == 0)
            {
                return "Zero";
            }
            else if (n < 0)
            {
                return "Negative " + IntegerToWritten(-n);
            }

            return FriendlyInteger(n, "", 0);
        }


        static string organizingContainers(int[][] container)
        {
            int[] sumCol = new int[container.Length];
            int[] sumRow = new int[container.Length]; ;
            for (int i = 0; i < container.Length; i++)
            {
                for (int j = 0; j < container.Length; j++)
                {
                    sumCol[i] += container[j][i];
                    sumRow[i] += container[i][j];
                }
            }

            Array.Sort(sumCol);
            Array.Sort(sumRow);

            if (sumCol.SequenceEqual(sumRow))
                return "Possible";
            else
                return "Impossible";

            
        }

        static int equalizeArray(int[] c)
        {
            if (c.Length == 1)
                return 0;

            if (c.Length == 2)
            {
                if (c[0] == c[1])
                    return 0;
                else
                    return 1;
            }

            var aux = c.Distinct().ToArray();

            if (aux.Length == c.Length)
                return c.Length - 1;

            if (aux.Length == 1)
                return 0;

            int maxRep = 0;
            int currRep = 0;

            for (int i = 0; i < c.Length; i++)
            {
                currRep = 0;

                for (int j = i+1; j < c.Length; j++)
                {
                    if (c[i] == c[j])
                        currRep++;
                }

                if (currRep > maxRep)
                    maxRep = currRep;
            }

            return c.Length - (maxRep + 1);
        }

        static int jumpingOnClouds(int[] c)
        {
            if (c.Length < 4)
                return 1;

            int jump = 0;

            for (int i = 0; i < c.Length-2;i++)
            {
                if (c[i + 2] == 0)
                {
                    jump ++;
                    i++;

                    if (i == c.Length -3)
                        return jump + 1;
                }
                else
                    jump ++;
            }

            return jump;
        }

        static int nonDivisibleSubset(int k, int[] S)
        {

            int max = 0;

            bool brk = false;
            int curr = 0;

            for (int i = 0; i < S.Length; i++)
            {

                int[] aux = new int[S.Length];
                curr = 1;

                Array.Copy(S, aux, S.Length);

                for (int j = i+1; j < S.Length; j++)
                {
                    if ((S[i] + S[j]) % k != 0)
                    {
                        brk = false;
                        for (int z = 0; z < j; z++)
                        {
                            if ((S[z] + S[j]) % k == 0 && aux[z] != 0)
                            {
                                brk = true;
                                aux[j] = 0;
                                break;
                            }
                        }

                        if (!brk)
                            curr++;

                    }
                    else
                    {
                        aux[j] = 0;
                    }
                }

                if (curr > max)
                {
                    max = curr;

                    if (max >= S.Length - 1)
                        return max + 1;
                }
            }

            return max + 1;
        }

        //static int nonDivisibleSubset(int k, int[] S)
        //{

        //    int max = 0;

        //    int[] arr = new int[S.Length];

        //    bool brk = false;

        //    for (int i = 0; i < S.Length; i++)
        //    {
        //        arr = new int[S.Length];
        //        arr[i] = S[i];

        //        int[] aux = new int[S.Length];

        //        Array.Copy(S, aux, S.Length);

        //        for (int j = 0; j < S.Length; j++)
        //        {
        //            if ((S[i] + S[j]) % k != 0 && i != j)
        //            {
        //                brk = false;
        //                for (int z = 0; z < j; z++)
        //                {
        //                    if ((S[z] + S[j]) % k == 0 && aux[z] != 0)
        //                    {
        //                        brk = true;
        //                        aux[j] = 0;
        //                        break;
        //                    }
        //                }

        //                if (!brk)
        //                    arr[j] = S[j];

        //            }
        //            else
        //            {
        //                aux[j] = 0;
        //            }
        //        }

        //        arr = arr.Where(a => a != 0).ToArray();

        //        if (arr.Length > max)
        //        {
        //            max = arr.Length;

        //            if (max >= S.Length - 2)
        //                return max;
        //        }
        //    }

        //        return max;
        //}

        static int formingMagicSquare(int[][] s)
        {
            int[][] x = new int[3][];

            x[0] = new int[] { 4, 8, 2 };
            x[1] = new int[] { 4, 5, 7 };
            x[2] = new int[] { 6, 1, 6 };

            for (int i = 0; i < x[i].Length; i++)
            {
                for (int j = 0; j < x[i].Length; j++)
                {
                    if (isMagic(x))
                        return 1;
                    else
                    {
                        int aux = x[i][j];
                    }
                }

            }

            return 0;
        }

        static bool isMagic(int[][] s)
        {
            int sum = s[0][0] + s[0][1] + s[0][2];

            if (s[1][0] + s[1][1] + s[1][2] != sum)
                return false;
            else if (s[2][0] + s[2][1] + s[2][2] != sum)
                return false;
            else if (s[0][0] + s[1][0] + s[2][0] != sum)
                return false;
            else if (s[0][1] + s[1][1] + s[2][1] != sum)
                return false;
            else if (s[0][2] + s[1][2] + s[2][2] != sum)
                return false;
            else if (s[0][0] + s[1][1] + s[2][2] != sum)
                return false;
            else if (s[0][2] + s[1][1] + s[2][0] != sum)
                return false;

            return true;
        }

        public static int pickingNumbers(List<int> a)
        {

            int max = 0;
            int cur = 0;

            int atual = 0;

            a.Sort();


            for (int i = 0; i < a.Count; i++)
            {
                cur = 1;
                for (int j = i; j < a.Count - 1; j++)
                {
                    if (Math.Abs(a[i] - a[j+1]) < 2)
                        cur++;
                    else
                        break;
                }

                if (cur>max)
                    max = cur;
            }
            if (max > 1)
                return max;
            else
                return 0;
        }

        public string solution(int U, int L, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)


            int sum0 = 0;
            int sum1 = 0;
            string m0 = "";
            string m1 = "";

            for (int i = 0; i < C.Length; i++)
            {
                

                if (C[i] == 2)
                {
                    m0+= "1";
                    m1+= "1";

                    sum0 ++;
                    sum1++;
                }
                else if (C[i] == 0)
                {
                    m0 += "0";
                    m1 += "0";
                }
                else
                {
                    if (C[i] == 1)
                    {
                        if(sum0<U)
                        {
                            sum0++;
                            m0 += "1";
                            m1 += "0";
                        }
                        else if (sum1 < L)
                        {
                            sum1++;
                            m1 += "1";
                            m0 += "0";
                        }
                    }
                }
            }

            if(sum0<U && sum1<L)
                return "IMPOSSIBLE";

            return m0 + "," + m1;
        }

        public int SliceSort(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[][] aux = new int[A.Length][];

            int cont = 1;

            for (int i = 0; i < A.Length; i++)
            {
                aux[i] = new int[A.Length];
                for (int j = i; j < A.Length - 1; j++)
                {
                    if (j == 0)
                        aux[i][j] = A[i];
                    else
                    {
                        if (!(A[j] < A[j - 1] && A[j] < A[j + 1]))
                            aux[i][j] = A[j];
                        else
                            break;

                    }

                }
            }

            return cont;
        }

        //public int Rays(Point2D[] A)
        //{
        //    // write your code in C# 6.0 with .NET 4.5 (Mono)
        //}

        public class Point2D
        {
            public int x { get;set; }
            public int y { get;set; }
        }

        public int PassingCars(int[] A)
        {
            int cont = 0;

            int aux = 1;

            for (int i = 0; i < A.Length; i++)
            {
                aux = 0;

                bool seq0 = true;
                int contSeq0 = 1;
                int cont1After = 0;

                if (A[i] == 0)
                {
                    for (int j = i + 1; j < A.Length; j++)
                    {
                        if (A[j] == 1)
                        {
                            seq0 = false;
                            cont1After++;
                        }
                        else
                        {
                            if (seq0)
                            {
                                aux++;
                                contSeq0++;
                            }
                        }
                    }
                }

                cont += contSeq0 * cont1After;

                if (cont > 1000000000)
                    return -1;

                i += aux;
            }

            if (cont > 1000000000)
                return -1;

            return cont;
        }

        public int BinaryGap(int N)
        {
            // write your code in Java SE 8

            string aux = Convert.ToString(N, 2);

            int maxGap = 0;

            aux = "000000111001";

            if(!aux.Contains("1") || !aux.Contains("0"))
                return 0;
            if(aux.Length<3)
                return 0;

            int start1 = -1;
            int cont = 0;

            for (int i = 0; i < aux.Length; i++)
            {
                if (aux[i] == '1')
                {
                    if (start1 == -1)
                    {
                        start1 = i;
                    }
                    else
                    {
                        start1 = i;
                        
                        if(cont>maxGap)
                            maxGap = cont;

                        cont = 0;
                    }
                }
                else
                {
                    if (start1 != -1)
                        cont++;
                }
            }

            return maxGap;
        }

        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {

            string[][] mat = new string[3][];

            for (int i = 0; i < grid.Length; i++)
            {
                mat[i] = grid[i].Split(' ');
            }

            int moves = 0;

            int curX = startX;

            int curY = startY;

            while (curX < goalX && curY < goalY)
            {
                for (int i = curX; i < goalX;i++ )
                {
                    if (mat[curX+1][curY] != "X")
                    {
                        curX++;
                    }
                    else
                        break;

                }

                for (int i = curY; i < goalY; i++)
                {
                    if (mat[curY + 1][curX] != "X")
                    {
                        curY++;
                    }
                    else
                        break;

                }
            }

            return moves;
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int[] rankA = new int[alice.Length];

            Array.Sort(scores);

            int aux = (int)scores.Distinct().Count();

            int last = 0;

            for (int i = 0; i < alice.Length; i++)
            {
                rankA[i] = aux + 1;

                if(i>0)
                    rankA[i] = rankA[i - 1];

                for (int j = last; j < scores.Length; j++)
                {
                    if (j > 0)
                    {
                        if (alice[i] >= scores[j] && scores[j] != scores[j - 1])
                            rankA[i]--;
                        else if (scores[j] > alice[i])
                            break;
                    }
                    else
                    {
                        if (alice[i] >= scores[j])
                            rankA[i]--;
                        else if (scores[j] > alice[i])
                            break;
                    }

                    last++;
                }
            }

            //List<int> lst = scores.ToList();

            //int aux = (int)scores.Distinct().Count();

            //for (int i = 0; i < alice.Length; i++)
            //{
            //    rankA[i] = aux + 1;

            //    int rem = -1;

            //    if (i > 0)
            //    {
            //        if (alice[i] >= alice[i - 1])
            //            rankA[i] = rankA[i - 1];
            //    }

            //    for (int j = 0; j < lst.Count; j++)
            //    {
            //        if (alice[i] >= lst[j] && lst[j] != rem)
            //        {
            //            rankA[i]--;
            //            rem = lst[j];
            //            lst.RemoveAll(item => item == rem);
            //            j--;
            //        }
            //        else if (lst[j] > alice[i])
            //            break;
            //    }
            //}

            return rankA;
        }

        public int ArrayDominator(int[] A)
        {

            if (A.Length == 1)
                return 0;

            Dictionary<int, int> dic = new Dictionary<int, int>();

            int qtdMax = 0, ret = -1;


            for (int i = 0; i < A.Length ; i++)
            {
                if (dic.ContainsKey(A[i]))
                {
                    dic[A[i]] = dic[A[i]] + 1;

                    if (dic[A[i]] > qtdMax)
                    {
                        qtdMax = dic[A[i]];
                        ret = i;
                    }
                }
                else
                    dic.Add(A[i], 1);
            }

            double aux = (double)A.Length / (double)qtdMax;

            if (aux < 2)
                return ret;

            return -1;
        }

        // Complete the biggerIsGreater function below.
        static string biggerIsGreater(string w)
        {

            bool containsInt = w.Any(char.IsDigit);

            if (containsInt)
                return "no answer";


            char[] arr = w.ToCharArray();

            List<string> lst = new List<string>();

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] > arr[i])
                    {
                        char c = arr[j];
                        arr[j] = arr[i];
                        arr[i] = c;

                        for (int k = i +1; k < arr.Length; k++)
                        {
                            for (int l = k + 1; l < arr.Length; l++)
                            {
                                if (arr[l] < arr[k])
                                {
                                    c = arr[k];
                                    arr[k] = arr[l];
                                    arr[l] = c;
                                }
                            }
                        }
                        return string.Join("", arr);
                    }
                }
            }

            return "no answer";

        }

        public int IsPermutation(int[] A)
        {
            Array.Sort(A);

            if (A.Length == 1)
            {
                if (A[0] == 1)
                    return 1;
                else
                    return 0;
            }
            else if (A[0] > 1)
                return 0;
            else
            {
                for (int i = 0; i < A.Length - 1; i++)
                    if (A[i + 1] - A[i] > 1 || A[i + 1] == A[i])
                        return 0;
            }

            return 1;
        }

        static string timeConversion(string s)
        {
            string res = "";

            string aux = s.Substring(s.Length - 2, 2);

            int auxI = int.Parse(s.Substring(0, 2));

            if (aux == "AM")
            {
                if(auxI<12)
                    res = s.Replace("AM", "");
                else
                    res = "00" + s.Substring(2, s.Length - 4);

            }
            else
            {
                res = s.Replace("PM", "");

                if (auxI < 12)
                {
                    auxI += 12;
                    res = auxI + s.Substring(2, s.Length - 4);
                }
                else
                    res = "12" + s.Substring(2, s.Length - 4);
            }


            return res;

        }

        public List<int> CompareTriplets(List<int> a, List<int> b)
        {
            List<int> res = new List<int>();

            res.Add(0);
            res.Add(0);

            for(int i = 0; i<a.Count; i++)
            {
                if (a[i] > b[i])
                    res[0]++;
                else if (b[i] > a[i])
                    res[1]++;
            }

            return res;
        }

        public int FindMissing(int[] A)
        {
            Array.Sort(A);

            if (A.Length == 0)
                return 1;
            else if (A[0] > 1)
                return A[0] - 1;
            else
            {

                for (int i = 0; i < A.Length - 1; i++)
                {
                    if (A[i + 1] - A[i] > 1)
                        return A[i] + 1;
                }
            }

            return A[A.Length -1] + 1;
        }

        public int FirstMissingPositiveInteger(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

            Array.Sort(A);

            if (A.Length > 1)
            {
                if (A[A.Length - 1] < 1)
                    return 1;
                else if (A[0] > 1)
                    return 1;
                else
                {
                    for (int i = 0; i < A.Length - 1; i++)
                    {
                        if (A[i + 1] - A[i] > 1)
                            if (A[i] >= 0)
                                return A[i] + 1;
                            else if (A[i + 1] > 1)
                                return 1;
                    }

                    return A[A.Length - 1] + 1;
                }
            }
            else
                if (A[0] < 1 || A[0] > 1)
                    return 1;
                else
                    return A[0] + 1;

        }

        public int[] CyclicRotation(int[] A, int K)
        {

            if (A.Length == 1 || A.Length == 0)
                return A;
            
            for (int i = 0; i <K ; i++)
            {

                if(A.Length == 2)
                {
                    int aux = A[0];
                    A[0] = A[1];
                    A[1] = aux;
                }
                else
                {
                    int last = A[A.Length -1]; 

                    for (int j = 0; j < A.Length - 1; j++)
                    {
                        A[A.Length - 1 - j] = A[A.Length - 2 - j];   
                    }

                    A[0] = last;
                }
            }

            return A;
        }

        public int OddArray(int[] A)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!dic.ContainsKey(A[i]))
                    dic.Add(A[i], 1);
                else
                    dic[A[i]] = dic[A[i]] + 1;
            }

            foreach (KeyValuePair<int, int> entry in dic)
            {
                if (entry.Value % 2 != 0)
                    return entry.Key;

            }

            return 0;
        }

        int RetMaxOcur(int M, int[] A)
        {
            int N = A.Length;
            int[] count = new int[M + 1];
            for (int i = 0; i <= M; i++)
                count[i] = 0;
            int maxOccurence = 1;
            int index = -1;
            for (int i = 0; i < N; i++)
            {
                if (count[A[i]] > 0)
                {
                    int tmp = count[A[i]] + 1;
                    if (tmp > maxOccurence)
                    {
                        maxOccurence = tmp;
                        index = i;
                    }
                    count[A[i]] = tmp;
                }
                else
                {
                    count[A[i]] = 1;
                }
            }

            return index == -1 ? A[0] : A[index];
        }

        public int FrogJump(int X, int Y, int D)
        {
            //int cont = 0;

            //while (X < Y)
            //{
            //    X += D;
            //    cont++;
            //}

            double res = 0;

            res = ((double)Y - (double)X) / (double)D;

            return Convert.ToInt32(Math.Ceiling(res));

            //return (int)Math.Round(res,0,MidpointRounding.AwayFromZero);
        }

        public int StackMachine(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            Stack<int> stk = new Stack<int>();

            string[] str = S.Split(' ');

            for (int i = 0; i < str.Length; i++)
            {
                int aux = 0;
                if (int.TryParse(str[i], out aux))
                {
                    stk.Push(aux);
                }
                else
                {
                    if (str[i] == "DUP")
                    {
                        if (stk.Count == 0)
                            return -1;
                        stk.Push(stk.Peek());
                    }
                    else if (str[i] == "POP")
                    {
                        if (stk.Count == 0)
                            return -1;

                        stk.Pop();
                    }
                    else if (str[i] == "+")
                    {
                        if (stk.Count < 2)
                            return -1;

                        int sum = stk.Peek();
                        stk.Pop();

                        try
                        {
                            sum += stk.Peek();
                        }
                        catch (OverflowException ex)
                        {
                            return -1;
                        }
                        
                        stk.Pop();

                        stk.Push(sum);
                    }
                    else if (str[i] == "-")
                    {
                        if (stk.Count < 2)
                            return -1;

                        int sub1 = stk.Peek();
                        stk.Pop();
                        int sub2 = stk.Peek();
                        stk.Pop();

                        int sub = sub1 - sub2;

                        if (sub < 0)
                            return -1;

                        stk.Push(sub);

                    }

                }
            }


            if (stk.Count == 0)
                return -1;

            return stk.Peek();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ex = ex;
            }
        }
    }
}

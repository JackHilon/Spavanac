using System;

namespace Spavanac
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spavanac
            // https://open.kattis.com/problems/spavanac

            var myTime = EnterHoursMinutes();

            var result = Make24MinutesEarly(myTime);

            string str = $"{result[0]} {result[1]}";

            Console.WriteLine(str);
        }
        private static int[] Make24MinutesEarly(int[] yourTime)
        {
            // int fullTime = 24 * 60;
            var yourHours = yourTime[0];
            var yourMinutes = yourTime[1];

            var wholeMinutes = yourHours * 60 + yourMinutes;

            // var earlyWholeMinutes = Math.Abs((wholeMinutes - 45) % fullTime);
            var earlyWholeMinutes = (wholeMinutes - 45);

            int nHours=0, nMinutes=0;

            if (earlyWholeMinutes > 0)
            {
                nHours = earlyWholeMinutes / 60;
                nMinutes = earlyWholeMinutes - nHours * 60;
            }
            else
            {
                nHours = 23;
                nMinutes = 15 + wholeMinutes;
            }

            int[] result = new int[2] { nHours, nMinutes };
            return result;
        }

        private static int[] EnterHoursMinutes()
        {
            string[] arr = new string[2] { "", "" };
            int[] ans = new int[2] { 0, 0 };

            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int k = 0; k < arr.Length; k++)
                {
                    ans[k] = int.Parse(arr[k]);
                }
                if (ans[0] < 0 || ans[1] > 23)
                    throw new ArgumentException();
                if (ans[1] < 0 || ans[1] > 59)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " +ex.Message);
                return EnterHoursMinutes();
            }
            return ans;
        }
    }
}

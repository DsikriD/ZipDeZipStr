using System.Diagnostics.Metrics;
using System.Text;

namespace TestForSTRandARRAY
{
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "xzccccccccxcvcxvcxxzzzxxcccccccccc      ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccx";
            Console.WriteLine(str);

            str = Program.ZipStirng(str);
            Console.WriteLine(str);

            str = Program.DeZipString(str);
            Console.WriteLine(str);
        }

        public static string ZipStirng(string str)
        {
            str = str.Trim();

            if (str.Count() == 0)
                return str;

            var array = str.ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();

            int Chisler = 1;
            char NowChar = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (NowChar != array[i])
                {
                    stringBuilder.Append(NowChar);
                    if (Chisler != 1)
                        stringBuilder.Append(Chisler);
                    NowChar = array[i];
                    Chisler = 1;
                }
                else
                    Chisler++;
            }
            stringBuilder.Append(NowChar);
            if (Chisler != 1)
                stringBuilder.Append(Chisler);

            return stringBuilder.ToString();
        }

        public static string DeZipString(string str)
        {
            str = str.Trim();
            if (str.Count() == 0)
                return str;

            StringBuilder stringBuilder = new StringBuilder();
            var array = str.ToCharArray();
            char NowChar = array[0];
            int NowInt = -1;

            for (int i = 1; i < array.Length; i++)
            {
                if (Char.IsDigit(array[i]))//Если число
                {
                    if(NowInt==-1)
                        NowInt = (int)char.GetNumericValue(array[i]);
                    else
                        NowInt = NowInt * 10 + (int)char.GetNumericValue(array[i]);
                }
                else
                {
                    for (int j = 0; j < Math.Abs(NowInt); j++)
                        stringBuilder.Append(NowChar);

                    NowChar = array[i];
                    NowInt = -1;
                }
                
            }

            for (int j = 0; j < Math.Abs(NowInt); j++)
                stringBuilder.Append(NowChar);

            return stringBuilder.ToString();
        }

    }
}

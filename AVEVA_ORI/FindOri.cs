using System;
using System.Globalization;
using System.Text;
using Aveva.Core.PMLNet;

namespace AVEVA_ORI
{
    [PMLNetCallable]
    public partial class FindOri
    {
        [PMLNetCallable]
        public static void Main()
        {
            double x1, y1, z1, x2, y2, z2;

            CultureInfo culture = CultureInfo.InvariantCulture;

            string[] input1 = Console.ReadLine().Split();
            x1 = double.Parse(input1[0], culture);
            y1 = double.Parse(input1[1], culture);
            z1 = double.Parse(input1[2], culture);

            string[] input2 = Console.ReadLine().Split();
            x2 = double.Parse(input2[0], culture);
            y2 = double.Parse(input2[1], culture);
            z2 = double.Parse(input2[2], culture);

            Tuple<double, double> angles1 = CalculateAngles(x1, x2, y1, y2, z1, z2);
            Tuple<double, double> angles2 = CalculateAngles(x2, x1, y2, y1, z2, z1);

            Console.WriteLine($"hdir E {angles1.Item1.ToString(culture)} N {angles1.Item2.ToString(culture)} U");
            Console.WriteLine($"tdir E {angles2.Item1.ToString(culture)} N {angles2.Item2.ToString(culture)} U");
        }

        public static Tuple<double, double> CalculateAngles(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            double dz = z2 - z1;

            double horizontalAngle = Math.Atan2(dy, dx);
            double xyDistance = Math.Sqrt(dx * dx + dy * dy);
            double verticalAngle = Math.Atan2(dz, xyDistance);

            return new Tuple<double, double>(horizontalAngle, verticalAngle);
        }
    }
}
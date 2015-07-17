namespace CSharpExam_Cube
{
    using System;
    using System.Text;

    /// <summary>
    /// ::::::  <----top = bottom
    /// :    ::
    /// :    :|:
    /// :    :||:
    /// :    :|||:
    /// ::::::||||:  <-------- end of region 1
    ///  :----:|||:  <-------- beginning of region 2 
    ///   :----:||:
    ///    :----:|:
    ///     :----::  <-------- end of region 2
    ///      ::::::  <----bottom = top
    /// </summary>
    public class Cube
    {
        public static void Main()
        {
            // width = height = depth = N
            int N = int.Parse(Console.ReadLine());
            var cube = new StringBuilder();

            // top
            cube.AppendLine(new string(':', N));

            // region 1
            for (int i = 0; i < N - 2; i++)
            {
                cube.Append(':');
                cube.Append(new string(' ', N - 2));
                cube.Append(':');
                cube.Append(new string('|', i));
                cube.AppendLine(":");
            }

            // end of region 1
            cube.Append(new string(':', N));
            cube.Append(new string('|', N - 2));
            cube.AppendLine(":");

            // region 2
            for (int i = 0; i < N - 2; i++)
            {
                cube.Append(new string(' ', i + 1));
                cube.Append(':');
                cube.Append(new string('-', N - 2));
                cube.Append(':');
                cube.Append(new string('|', N - 3 - i));
                cube.AppendLine(":");
            }

            // bottom
            cube.Append(new string(' ', N - 1)); 
            cube.AppendLine(new string(':', N));

            Console.Write(cube);
        }
    }
}

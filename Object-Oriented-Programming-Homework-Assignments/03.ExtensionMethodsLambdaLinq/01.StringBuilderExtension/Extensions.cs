using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderExtension
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            var result = new StringBuilder();
            if (index + length < sb.Length)
            {
                string temp = sb.ToString().Substring(index, length);

                result.Append(temp);

                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid index and length");
            }
        }

    }
}

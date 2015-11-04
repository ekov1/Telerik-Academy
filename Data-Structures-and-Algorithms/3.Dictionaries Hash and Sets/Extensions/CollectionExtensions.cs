namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class CollectionExtensions
    {
        public static void CopyToClipboard<T>(this IEnumerable<T> collection)
        {
            var input = string.Join(Environment.NewLine, collection) + Environment.NewLine + Environment.NewLine;
            Clipboard.SetText(input);
        }

        public static void CopyToClipboard<T>(this IEnumerable<T> collection, string separator, string terminalSymbol)
        {
            var input = string.Join(separator, collection) + terminalSymbol;
            Clipboard.SetText(input);
        }

        public static void CopyStringToClipboard(this string input)
        {
            //var inputParts = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Clipboard.SetText(input);
        }
    }
}
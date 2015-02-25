using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a string from the console and prints all different letters 
//in the string along with information how many times each letter is found.

class Program
{
    static void Main()
    {
        string sample = "Eu beard Austin exercitation Marfa. Cold-pressed health goth photo booth, direct trade slow-carb squid deserunt narwhal McSweeney's veniam fap butcher pug. Letterpress literally in plaid cornhole. Est fixie gluten-free ex artisan. Vegan fap chambray vero cornhole jean shorts Vice, YOLO XOXO ullamco. Est enim you probably haven't heard of them freegan. Kale chips tattooed keytar meggings anim cold-pressed forage banh mi wayfarers, letterpress synth.";
        Console.WriteLine("Lorem hipsterum: " + sample);
        string unifiedSample = sample.ToUpper();
        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        int[] count = new int[26];

        for (int i = 0; i < unifiedSample.Length; i++) //count
        {
            if (unifiedSample[i] < 65 || unifiedSample[i] > 90)
            {
                continue;
            }

            int currentLetter = (int)unifiedSample[i] - 65;
            count[currentLetter]++;
        }

        Console.WriteLine();
        for (int i = 0; i < 26; i++) //print result
        {
            Console.WriteLine("The letter {0} has been encountered {1} time(s)", letters[i], count[i]);
        }

    }
}

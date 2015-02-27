using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _14WordDictionary
{
    class Program
    {
        static void Main()
        {
            var Dict = new Dictionary<string, string>();
            Dict.Add("ambitchous", "Striving to be more of a bitch than the average bitch.");
            Dict.Add("BDSM", "An overlapping abbrevation of Bondage and Discipline (BD), Dominance and Submission (DS), Sadism and Masochism (SM).");
            Dict.Add("cock block", "One, who prevents another from scoring sexually.");
            Dict.Add("diarrhea", "Flaming liquid shit that makes you scream with pain, clench your teeth, grab hard onto the nearest solid object so that you don't get blown away, and wonder how you're still alive when it's over.");
            Dict.Add("education", "What I have a serious lack of.");
            Dict.Add("Fakebook", "The true meaning of facebook!");
            Dict.Add("girlfriend", "Mystical creature whose known powers range from clairvoyancy to being able to bleed for a week without dying. a person to have on your side.");
            Dict.Add("horny", "When a person feels intense sexual desire.");
            Dict.Add("illuminati", "Elite masters of deception who want to control your mind, soul, and your body, and rule the entire world.");
            Dict.Add("jailbait", "An attractive person, usually a female, below the legal age of consent; so named because the penalty for adult sexual intercourse with such a person is usually imprisonment.");
            Dict.Add("Kim Kardashian", "A chick who's famous for having a big ass and a sex tape.");
            Dict.Add("loner", "A Telerik Academy student.");
            Dict.Add("minion", "BANANA!1!1!1");
            Dict.Add("Nicholas Cage Syndrome", "When you have the same facial expression no matter what emotion you're supposed to be showing.");
            Dict.Add("Omegle", "A website (omegle.com) that is an anonymous one on one chat, pretty much a feeding ground for pedos.");
            Dict.Add("psycho", "The person, who wrote this dictionary.");
            Dict.Add("qwerty", "The most used password for anything.");
            Dict.Add("reddit", "A website where time comes to die.");
            Dict.Add("sleep", "Married sex.");
            Dict.Add("twerk", "The vigorously shaking of your Gluteus Maximus.");
            Dict.Add("unique", "What this dictionary is.");
            Dict.Add("Voldemort", "A horrible wizard who tends to suck Unicorns dry of their blood and eats children (after he does YOU KNOW WHAT with them). Also, he is noseless.");
            Dict.Add("wet pussy", "A cat soaked in water.");
            Dict.Add("XXL", "The standard \"medium\" size for most Americans.");
            Dict.Add("YOLO", "The douchebag mating call.");
            Dict.Add("zombie", "A Telerik Academy student two days before exam.");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Available words: ");

                foreach (KeyValuePair<string, string> key in Dict)
                {
                    Console.WriteLine(key.Key);
                }

                Console.Write("\n\nWord: ");
                string input = Console.ReadLine();

                if (Dict.Keys.Contains(input))
                {
                    string currentWord = Dict[input];
                    Console.WriteLine("Meaning: " + currentWord);
                }
                Console.ReadLine();
            }
        }
    }
}
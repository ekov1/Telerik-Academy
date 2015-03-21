using System;
using System.Linq;

namespace _17.LongestString
{
    class LongestString
    {
        static void Main(string[] args)
        {

            string[] arrayStrings =
            {
                "People are stupid; given proper motivation, almost anyone will believe almost anything. Because people are stupid, they will believe a lie because they want to believe it's true, or because they're afraid it might be true. Peoples' heads are full of knowledge, facts and beliefs, and most of it is false, yet they think it all true. People are stupid; they can only rarely tell the difference between a lie and the truth, and yet they are confident they can, and so are all the easier to fool." ,
                "The Second Rule is that the greatest harm can result from the best intentions." ,
                "Passion rules reason." ,
                "The Wizard's Fourth Rule, he called it. He said that there was magic in sincere forgiveness, in the Fourth Rule. Magic to heal. In forgiveness you grant, and more so in the forgiveness you receive." ,
                "Mind what people do, not only what they say, for deeds will betray a lie." ,
                "The most important rule there is, the Wizard's Sixth Rule: the only sovereign you can allow to rule you is reason. The first law of reason is this: what exists, exists, what is, is and from this irreducible bedrock principle, all knowledge is built. It is the foundation from which life is embraced." ,
                "Life is the future, not the past. The past can teach us, through experience, how to accomplish things in the future, comfort us with cherished memories, and provide the foundation of what has already been accomplished. But only the future holds life. To live in the past is to embrace what is dead. To live life to its fullest, each day must be created anew. As rational, thinking beings, we must use our intellect, not a blind devotion to what has come before, to make rational choices."
            };

            var orderedRules = from rule in arrayStrings
                orderby rule.Length descending
                select rule;
            string longestString = orderedRules.FirstOrDefault();

            Console.WriteLine(longestString);
        }
    }
}

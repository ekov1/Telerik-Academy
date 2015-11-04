namespace HashTableTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using HashTableImplementation;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HashTableImplementationTests
    {
        private static readonly Random Rng = new Random();

        private static readonly string[] SampleNames =
        {
            "dentia", "dtopalov", "baretata", "pip3r4o", "kon.simeonov", "Moiraine", "sa66eto", "antoanelenkov", "M.Yankov", "Nicky94",
            "simeon.georgiev", "ivaylokenov", "cuki", "IlianaB", "Nikolay.IT", "ivan.mihov1", "saykor", "evlagbi", "borisstoyanov"
        };

        [Test]
        public void InitialCountShouldBeZero()
        {
            var hashtable = new HashTable<string, string>();

            Assert.AreEqual(0, hashtable.Count);
        }

        [Test]
        public void IndexerShouldReturnTheElementAddedWithAdd()
        {
            var hashtable = new HashTable<string, string>();

            var key = "npesheva";
            var value = "es6 promises";

            hashtable.Add(key, value);

            Assert.AreEqual(value, hashtable[key]);
        }

        [Test]
        public void CapacityShouldDoubleAtSeventyFivePercentLoad()
        {
            var hashtable = new HashTable<string, string>();
            var startingCapacity = hashtable.Capacity;

            SampleNames.Take(13).ToList().ForEach(x => hashtable.Add(x, "test"));

            Assert.AreEqual(startingCapacity * 2, hashtable.Capacity);
        }

        [Test]
        public void CapacityShouldIncreasePersistently()
        {
            var hashtable = new HashTable<string, string>();
            var lastCapacity = hashtable.Capacity;
            var counter = 16;
            var next = 0;

            while (hashtable.Count < 1024)
            {
                for (int i = 0; i < 1 + (counter * 3) / 4; i++)
                {
                    hashtable.Add((next++).ToString(), "kon.simeonov");
                }

                lastCapacity = hashtable.Capacity;
                counter *= 2;

                Assert.AreEqual(counter, lastCapacity);
            }
        }

        [Test]
        public void CapacityShouldDecreasePersistently()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i <= 768; i++)
            {
                hashtable.Add(i, "");
            }

            Assert.AreEqual(2048, hashtable.Capacity);

            for (int i = 0; i <= 384; i++)
            {
                hashtable.Remove(i);
            }

            Assert.AreEqual(1024, hashtable.Capacity);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddShouldThrowExceptionWhenTheSameKeyIsAlreadyPresent()
        {
            var hashtable = new HashTable<string, string>();

            hashtable.Add("bobi", "tosho");
            hashtable.Add("bobi", "pesho");
        }

        [Test]
        public void AddShouldStoreKeysPersistently()
        {
            var keys = new List<decimal>();
            var hashtable = new HashTable<decimal, string>();

            for (int i = 0; i < 1000; i++)
            {
                var nextKey = Rng.Next(-5000000, 5000000) / 100M;
                hashtable.Add(nextKey, "kon.simeonov");
                keys.Add(nextKey);
            }

            keys.ForEach(x => Assert.IsTrue(hashtable.Keys.Contains(x)));

            Assert.AreEqual(0, keys.Except(hashtable.Keys).Count());
            Assert.AreEqual(0, hashtable.Keys.Except(keys).Count());
        }

        [Test]
        public void AddShouldStoreDifferentKeysWithSameHashCode()
        {
            var mockRandom1 = new Mock<ICloneable>();

            mockRandom1.Setup(x => x.GetHashCode()).Returns(5);

            var mockRandom2 = new Mock<ICloneable>();

            mockRandom2.Setup(x => x.GetHashCode()).Returns(5);

            var hashtable = new HashTable<ICloneable, string>();

            hashtable.Add(mockRandom1.Object, "1");
            hashtable.Add(mockRandom2.Object, "2");

            Assert.AreEqual(2, hashtable.Count);

            Assert.AreEqual("1", hashtable[mockRandom1.Object]);
            Assert.AreEqual("2", hashtable[mockRandom2.Object]);
        }

        [Test]
        public void TryGetValueShouldReturnFalseWhenTheValueIsNotAdded()
        {
            var hashtable = new HashTable<int, string>();

            string outVar;
            Assert.IsFalse(hashtable.TryGetValue(69, out outVar));
        }

        [Test]
        public void TryGetValueShouldReturnFalsePersistently()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 1000; i += 2)
            {
                hashtable.Add(i, "");
            }

            string outVar;


            for (int i = 1; i < 1000; i += 2)
            {
                Assert.IsFalse(hashtable.TryGetValue(i, out outVar));
            }
        }

        [Test]
        public void TryGetValueShouldReturnTruePersistentlyWhenTheValueIsPresent()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 1000; i += 2)
            {
                hashtable.Add(i, i.ToString());
            }

            string outVar;


            for (int i = 0; i < 1000; i += 2)
            {
                Assert.IsTrue(hashtable.TryGetValue(i, out outVar));
                Assert.AreEqual(i.ToString(), outVar);
            }
        }

        [Test]
        public void ContainsKeyShouldReturnTruePersistentlyWhenKeyHasBeenAdded()
        {
            var hashtable = new HashTable<int, int>();

            for (int i = 0; i < 1000; i++)
            {
                hashtable.Add(i, i);
                Assert.IsTrue(hashtable.ContainsKey(i));
            }
        }

        [Test]
        public void ContainsKeyShouldReturnFalsePersistentlyWhenKeyHasNotBeenAdded()
        {
            var hashtable = new HashTable<int, int>();

            for (int i = 0; i < 2000; i += 2)
            {
                hashtable.Add(i, i);
            }

            for (int i = 1; i < 2000; i += 2)
            {
                Assert.IsFalse(hashtable.ContainsKey(i));
            }
        }

        [Test]
        public void ContainsShouldReturnTrueWhenTheGivenKeyValuePairIsPresent()
        {
            var hashtable = new HashTable<double, string>();

            hashtable.Add(1.1, "fsdfsdf");

            Assert.IsTrue(hashtable.Contains(new KeyValuePair<double, string>(1.1, "fsdfsdf")));
        }

        [Test]
        public void RemoveShouldReturnTrueWhenTheElementIsFoundAndRemoved()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            var hasBeenRemoved = hashtable.Remove(10);

            Assert.IsTrue(hasBeenRemoved);
        }

        [Test]
        public void RemoveShouldReturnFalseWhenElementIsNotFound()
        {
            var hashtable = new HashTable<int, int>();

            var hasBeenRemoved = hashtable.Remove(10);

            Assert.IsFalse(hasBeenRemoved);
        }

        [Test]
        public void RemoveShouldDeleteTheElementWithGivenKey()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            hashtable.Remove(10);

            int outVar;

            Assert.IsFalse(hashtable.TryGetValue(10, out outVar));
        }

        [Test]
        public void RemoveShouldDeleteTheMatchingKeyValuePair()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            var hasBeenRemoved = hashtable.Remove(new KeyValuePair<int, int>(10, 15));

            Assert.IsTrue(hasBeenRemoved);
        }

        [Test]
        public void RemoveShouldNotRemoveKeyValuePairWithMatchingKeyButDifferentValue()
        {
            var hashtable = new HashTable<int, int>();

            hashtable.Add(10, 15);

            Assert.AreEqual(15, hashtable[10]);

            var hasBeenRemoved = hashtable.Remove(new KeyValuePair<int, int>(10, 10));

            Assert.IsFalse(hasBeenRemoved);

            Assert.AreEqual(15, hashtable[10]);
        }

        [Test]
        public void ValuesPropertyShouldReturnAllAddedValues()
        {
            var hashtable = new HashTable<string, string>();

            var values = new HashSet<string>();

            for (int i = 0; i < 200; i++)
            {
                var nextKeyValuePair = new KeyValuePair<string, string>(i.ToString(), Rng.NextString(0, 10));

                values.Add(nextKeyValuePair.Value);

                hashtable.Add(nextKeyValuePair);
            }

            hashtable.Values.ToList().ForEach(v => Assert.IsTrue(values.Contains(v)));
        }

        [Test]
        public void ValuesPropertyShouldReturnEmptyCollectionByDefault()
        {
            var hashtable = new HashTable<Random, Random>();

            Assert.AreEqual(0, hashtable.Values.Count);
        }

        [Test]
        public void ValuesPropertyShouldNotReturnRemovedElements()
        {
            var hashtable = new HashTable<int, int>();

            for (int i = 0; i < 5; i++)
            {
                hashtable.Add(i, i);
            }

            hashtable.Remove(0);

            var values = hashtable.Values;

            for (int i = 1; i < 5; i++)
            {
                Assert.IsTrue(values.Contains(i));
            }

            Assert.IsFalse(values.Contains(0));
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void IndexerGetterShouldThrowAnExceptionWhenNoValueWithSuchKeyExists()
        {
            var hashtable = new HashTable<string, string>();

            var shouldCrash = hashtable["bobi"];
        }

        [Test]
        public void IndexerSetterShouldAddTheValueWhenTheKeyIsNotPresent()
        {
            var hashtable = new HashTable<string, string>();

            hashtable["gosho"] = "penka";

            Assert.AreEqual("penka", hashtable["gosho"]);
        }

        [Test]
        public void IdexerSetterShouldModifyTheValueWhenTheKeyIsPresent()
        {
            var hashtable = new HashTable<string, string>();

            hashtable["gosho"] = "penka";

            hashtable["gosho"] = "ivanka";

            Assert.AreEqual("ivanka", hashtable["gosho"]);
        }

        [Test]
        public void IndexerShouldSetTheElementWithTheGivenKey()
        {
            var hashtable = new HashTable<string, string>();

            hashtable.Add("gosho", "tosho");

            hashtable["gosho"] = "ivan";

            Assert.AreEqual("ivan", hashtable["gosho"]);
        }

        [Test]
        public void ForeachShouldIterateOverAllAddedValues()
        {
            var addedValues = new HashSet<int>();
            var hashtable = new HashTable<string, int>();

            SampleNames.ToList().ForEach(n =>
            {
                hashtable.Add(n, n.Length);
                addedValues.Add(n.Length);
            });

            hashtable.ToList().ForEach(kvp => Assert.IsTrue(addedValues.Contains(kvp.Value)));
        }
    }
}
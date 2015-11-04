namespace HashTableTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using HashSetImplementation;
    using HashTableImplementation;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HashedSetTests
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
            var hashedset = new HashedSet<string>();

            Assert.AreEqual(0, hashedset.Count);
        }

        [Test]
        public void AddShouldNotThrowExceptionWhenTheSameKeyIsAlreadyPresent()
        {
            var hashedset = new HashedSet<string>();

            hashedset.Add("gosho");
            hashedset.Add("gosho");
        }

        [Test]
        public void AddShouldStoreDifferentKeysWithSameHashCode()
        {
            var mock1 = new Mock<ICloneable>();

            mock1.Setup(x => x.GetHashCode()).Returns(5);
            mock1.Setup(x => x.Equals(It.IsAny<object>())).Returns(false);
            var mock2 = new Mock<ICloneable>();

            mock2.Setup(x => x.GetHashCode()).Returns(5);
            mock2.Setup(x => x.Equals(It.IsAny<object>())).Returns(false);
            var hashedset = new HashedSet<ICloneable>();

            hashedset.Add(mock1.Object);
            hashedset.Add(mock2.Object);

            Assert.AreEqual(2, hashedset.Count);
        }

        [Test]
        public void ContainsShouldReturnTruePersistentlyWhenKeyHasBeenAdded()
        {
            var hashedset = new HashedSet<int>();

            for (int i = 0; i < 1000; i++)
            {
                hashedset.Add(i);
                Assert.IsTrue(hashedset.Contains(i));
            }
        }

        [Test]
        public void ContainsKeyShouldReturnFalsePersistentlyWhenKeyHasNotBeenAdded()
        {
            var hashedset = new HashedSet<int>();

            for (int i = 0; i < 2000; i += 2)
            {
                hashedset.Add(i);
            }

            for (int i = 1; i < 2000; i += 2)
            {
                Assert.IsFalse(hashedset.Contains(i));
            }
        }

        [Test]
        public void RemoveShouldReturnTrueWhenTheElementIsFoundAndRemoved()
        {
            var hashedset = new HashedSet<int>();

            hashedset.Add(10);

            var hasBeenRemoved = hashedset.Remove(10);

            Assert.IsTrue(hasBeenRemoved);
            Assert.IsFalse(hashedset.Contains(10));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenElementIsNotFound()
        {
            var hashedset = new HashedSet<int>();

            var hasBeenRemoved = hashedset.Remove(10);

            Assert.IsFalse(hasBeenRemoved);
        }

        [Test]
        public void RemoveShouldDeleteTheElement()
        {
            var hashedset = new HashedSet<int>();

            hashedset.Add(10);

            Assert.IsTrue(hashedset.Contains(10));

            var removed = hashedset.Remove(10);

            Assert.IsTrue(removed);
        }

        [Test]
        public void ForeachShouldIterateOverAllAddedValues()
        {
            var addedValues = new HashSet<int>();
            var hashedset = new HashedSet<int>();

            SampleNames.ToList().ForEach(n =>
            {
                hashedset.Add(n.Length);
                addedValues.Add(n.Length);
            });

            hashedset.ToList().ForEach(v => Assert.IsTrue(addedValues.Contains(v)));
        }

        [Test]
        public void UnionShouldProduceSetContainingElementsFromBothSets()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var hashedset = new HashedSet<int>();

            SampleNames.ToList().ForEach(n => hashedset.Add(n.Length));

            var result = hashedset.UnionWith(numbers);

            numbers.ForEach(x => Assert.IsTrue(result.Contains(x)));

            hashedset.ToList().ForEach(x => Assert.IsTrue(result.Contains(x)));
        }

        [Test]
        public void UnionShouldReturnUniqueValues()
        {
            var numbers = new List<int> { 1, 2, 2, 2, 3, 3, 4, 4, 5 };
            var hashedset = new HashedSet<int>();

            new List<int> { 6, 2, 6, 7, 3 }.ForEach(n => hashedset.Add(n));

            var result = hashedset.UnionWith(numbers);

            Assert.AreEqual(7, result.Count);
        }

        [Test]
        public void IntersectShouldProducesSetContainingCommonUniqueItems()
        {
            ICollection<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var hashset = new HashedSet<int>();

            new List<int> { 6, 7, 6, 6, 8, 9, 10, 11, 12 }.ForEach(x => hashset.Add(x));

            var result = hashset.IntersectWith(numbers);

            new List<int> { 6, 7, 8 }.ForEach(x => Assert.IsTrue(result.Contains(x)));

            Assert.AreEqual(3, result.Count);
        }
    }
}

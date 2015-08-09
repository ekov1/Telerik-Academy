namespace SchoolTest
{
    using System;
    using School;
    using NUnit.Framework;

    [TestFixture]
    public class TestStudent
    {
        [Test]
        public void StudentShouldBeCreated()
        {
            var student = new Student("Captain Blackbeard", 55123);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentWithInvalidNameShouldThrow()
        {
            var student = new Student("", 22222);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentWithInvalidIdShouldThrow()
        {
            var student = new Student("Captain Blackbeard", 5617);
        }


    }
}

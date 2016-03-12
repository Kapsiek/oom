using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    public class Tests
    {
        //Case 1
        [Test]
        public void emptyFirstNameEntry()
        {
            Assert.Catch(() => { var FamMember = new brothers("", "male", 33); });
        }

        //Case 2
        [Test]
        public void emptySexEntry()
        {
            Assert.Catch(() => { var FamMember = new brothers("Fabian", "", 33); });
        }

        //Case 3
        [Test]
        public void wrongSexEntry()
        {
            Assert.Catch(() => { var FamMember = new brothers("Fabian", "nothing", 33); });
        }

        //Case 4
        [Test]
        public void emptyFirstName()
        {
            Assert.Catch(() => { var FamMember = new brothers("", "male", 33); });
        }

        //Case 5
        [Test]
        public void wrongAgeValue()
        {
            Assert.Catch(() => { var FamMember = new brothers("", "male", -3); });
        }

        //Case 6
        [Test]
        public void wrongAgeType()
        {
            Assert.Catch(() => { var FamMember = new brothers("", "male", Convert.ToChar("")); });
        }

        //Case 7
        [Test]
        public void emptyNameANDsex()
        {
            Assert.Catch(() => { var FamMember = new brothers("", "", 33); });
        }

        //Case 8
        [Test]
        public void ToLongName()
        {
            var FamMember = new brothers("Fabian Somthing More Chars ....", "male", 33);
            Assert.IsTrue(FamMember.First_Name.Length >= 15);

        }
    }
}

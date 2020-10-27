using CarDealership.Data.ADO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual(1, states[0].StateId);
            Assert.AreEqual("Ohio", states[0].StateName);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new ColorRepositoryADO();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);

            Assert.AreEqual(1, colors[0].ColorId);
            Assert.AreEqual("Red", colors[0].ColorName);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStyleRepositoryADO();

            var styles = repo.GetAll();

            Assert.AreEqual(3, styles.Count);

            Assert.AreEqual(1, styles[0].BodyStyleId);
            Assert.AreEqual("Car", styles[0].Style);
        }
    }
}

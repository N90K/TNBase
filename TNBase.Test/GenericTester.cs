using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TNBase.DataStorage;
using TNBase.Objects;
using System.Collections.Generic;

namespace TNBase.Test
{
    [TestClass]
    public class GenericTester
    {
        [TestMethod]
        public void Generic_BasicTimeTest()
        {
            ModuleGeneric.saveStartTime();
            ModuleGeneric.saveEndTime();
            ModuleGeneric.getStartTimeString();
            ModuleGeneric.getEndTimeString();
            Assert.AreEqual("00:00:00", ModuleGeneric.getElapsedTimeString());
        }

        [TestMethod]
        public void Generic_DateToUK()
        {
            string dateStr = "2015-10-20";
            string expected = "20/10/2015";

            Assert.AreEqual(expected, ModuleGeneric.getUKFormatDate(dateStr));
        }

        [TestMethod]
        public void Generic_TestAppName()
        {
            Assert.AreEqual("TNBase.exe", ModuleGeneric.getAppName());
        }

        /// <summary>
        /// Base for the weekly stat test methods
        /// </summary>
        /// <param name="newStatsWeek">Is it a new stats week?</param>
        /// <param name="expectingInOuts">Should the in out bits be updated?</param>
        private void WeekStatTest_Base(bool newStatsWeek, bool expectingInOuts)
        {
            Mock<IServiceLayer> mockServiceLayer = new Mock<IServiceLayer>();
            mockServiceLayer.Setup(x => x.GetCurrentWeekNumber()).Returns(100);
            mockServiceLayer.Setup(x => x.GetCurrentListenerCount()).Returns(10);
            mockServiceLayer.Setup(x => x.GetListenersByStatus(It.IsAny<ListenerStates>())).Returns(new List<Listener>() { });
            mockServiceLayer.Setup(x => x.WeeklyStatExistsForWeek(100)).Returns(newStatsWeek);
            mockServiceLayer.Setup(x => x.GetCurrentWeekStats()).Returns(new WeeklyStats());

            ModuleGeneric.UpdateStatsWeek(mockServiceLayer.Object, expectingInOuts);

            // Check we add/update the week stats
            if (newStatsWeek)
            {
                mockServiceLayer.Verify(x => x.UpdateWeeklyStats(It.Is<WeeklyStats>(y => y.TotalListeners == 10 && y.WeekNumber == 100 && y.PausedCount == 0)), Times.Once);
            }
            else
            {
                mockServiceLayer.Verify(x => x.SaveWeekStats(It.Is<WeeklyStats>(y => y.TotalListeners == 10 && y.WeekNumber == 100 && y.PausedCount == 0)), Times.Once);
            }

            // Check we call to update in outs
            if (expectingInOuts)
            {
                mockServiceLayer.Verify(x => x.UpdateListenerInOuts(), Times.Once);
            }
            else
            {
                mockServiceLayer.Verify(x => x.UpdateListenerInOuts(), Times.Never);
            }
        }

        /// <summary>
        /// Test our week stat update method.
        /// We should update the in/outs
        /// </summary>
        [TestMethod]
        public void Generic_WeekStatSave_UpdateInOuts()
        {
            WeekStatTest_Base(false, true);
        }

        /// <summary>
        /// Test our week stat update method.
        /// We shouldn't update the in/outs
        /// </summary>
        [TestMethod]
        public void Generic_WeekStatSave_DontUpdateInOuts()
        {
            WeekStatTest_Base(true, false);
        }

        [TestMethod]
        public void Generic_CheckWeArentGeneratingDummyData()
        {
            Assert.IsFalse(ModuleGeneric.CreateDummyData());
        }
    }
}

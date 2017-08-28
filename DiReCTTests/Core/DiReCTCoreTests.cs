using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiReCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiReCT.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DiReCT.Tests
{
    [TestClass()]
    public class DiReCTCoreTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod()]
        public void SaveRecordToBufferTest()
        {
            DiReCTCore target = new DiReCTCore();
            dynamic record = DllFileLoader.CreateAnInstance();

            record.waterLevel = 12;
            record.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record.currentLongitude = "121.23";
            record.currentLatitude = "23.5";
            record.currentTimeStamp = "2017/1/23";
            int actual = target.SaveRecordToBuffer(record);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetRecordFromBufferTest()
        {

            DiReCTCore target = new DiReCTCore();

            dynamic record1 = DllFileLoader.CreateAnInstance();
            record1.waterLevel = 12;
            record1.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record1.currentLongitude = "121.23";
            record1.currentLatitude = "23.5";
            record1.currentTimeStamp = "2017/1/23";
            target.SaveRecordToBuffer(record1);

            dynamic record2 = DllFileLoader.CreateAnInstance();
            record2.waterLevel = 12;
            record2.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record2.currentLongitude = "123.23";
            record2.currentLatitude = "23.5";
            record2.currentTimeStamp = "2017/1/23";
            target.SaveRecordToBuffer(record2);

            dynamic record3;

            bool actual = DiReCTCore.GetRecordFromBuffer(0, out record3);
            bool expected = true;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(record1, record3);

            actual = DiReCTCore.GetRecordFromBuffer(1, out record3);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(record2, record3);

            actual = DiReCTCore.GetRecordFromBuffer(2, out record3);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(null, record3);
        }

        [TestMethod()]
        public void CoreSaveRecordTest()
        {
            // Initialize DiReCTCore first in order to initialize CoreWorkQueue as well
            DiReCTCore target = new DiReCTCore();

            dynamic record = DllFileLoader.CreateAnInstance();
            record.waterLevel = 12;
            record.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record.currentLongitude = "121.23";
            record.currentLatitude = "23.5";
            record.currentTimeStamp = "2017/1/23";

            bool actual = DiReCTCore.CoreSaveRecord(record, null, null);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
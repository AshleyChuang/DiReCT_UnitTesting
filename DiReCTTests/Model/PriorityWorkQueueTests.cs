using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiReCT.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;

namespace DiReCT.Model.Utilities.Tests
{
    [TestClass()]
    public class PriorityWorkQueueTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            dynamic record = DllFileLoader.CreateAnInstance();
            record.waterLevel = 12;
            record.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record.currentLongitude = "121.23";
            record.currentLatitude = "23.5";
            record.currentTimeStamp = "2017/1/23";
            CancellationToken cancellationToken = new CancellationToken();

            WorkItem workItem
                    = new WorkItem(FunctionGroupName.DataManagementFunction,
                                   AsyncCallName.SaveRecord,
                                   (Object)record,
                                   null,
                                   null);
            Utilities.PriorityWorkQueue<WorkItem> target = new Utilities.PriorityWorkQueue<WorkItem>((int)WorkPriority.NumberOfPriorities);
            bool actual = target.Enqueue(workItem, (int)WorkPriority.Normal, cancellationToken);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            dynamic record = DllFileLoader.CreateAnInstance();
            record.waterLevel = 12;
            record.PossibleCauseOfDisaster = new ObservableCollection<string>() { "123" };
            record.currentLongitude = "121.23";
            record.currentLatitude = "23.5";
            record.currentTimeStamp = "2017/1/23";
            CancellationToken cancellationToken = new CancellationToken();

            WorkItem workItem
                    = new WorkItem(FunctionGroupName.DataManagementFunction,
                                   AsyncCallName.SaveRecord,
                                   (Object)record,
                                   null,
                                   null);
            Utilities.PriorityWorkQueue<WorkItem> target = new Utilities.PriorityWorkQueue<WorkItem>((int)WorkPriority.NumberOfPriorities);
            int expected = (int)WorkPriority.Normal;
            target.Enqueue(workItem, expected, cancellationToken);
            WorkItem workItem2;
            int actual = target.Dequeue(out workItem2);
            Assert.AreEqual(expected, actual);
        }
    }
}
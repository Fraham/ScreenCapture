using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Threading;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class CaptureWorkerTests
    {

        private CaptureWorker capture;

        [TestInitialize()]
        public void Initialize()
        {
            capture = new CaptureWorker(new Options.Option(100, 100, new Point(3, 4)), @"C:\");
        }

        [TestMethod()]
        public void CaptureWorkerConstructors()
        {
            capture = new CaptureWorker(new Options.Option(100, 100, new Point(3, 4)), @"C:\");
        }

        [TestMethod()]
        public void CaptureWorkerStartFeed()
        {
            capture.Start();

            Assert.IsTrue(capture.Started);
            Assert.IsTrue(capture.Capturing);
        }

        [TestMethod()]
        public void CaptureWorkerPauseFeed()
        {
            capture.Start();
            capture.Pause();

            Assert.IsTrue(capture.Started);
            Assert.IsFalse(capture.Capturing);
        }

        [TestMethod()]
        public void CaptureWorkerStopFeed()
        {
            capture.Start();
            capture.Stop();

            Assert.IsFalse(capture.Started);
            Assert.IsFalse(capture.Capturing);
        }

        [TestMethod()]
        public void CaptureWorkerResumeFeed()
        {
            capture.Start();
            capture.Pause();
            capture.Resume();

            Assert.IsTrue(capture.Started);
            Assert.IsTrue(capture.Capturing);
        }

        [TestMethod()]
        public void CaptureWorkerFrames()
        {
            Assert.IsTrue(capture.Frames == 0);

            capture.Start();

            Thread.Sleep(500);

            //Assert.IsTrue(capture.Frames > 0);

            capture.Pause();

            int frames1 = capture.Frames;

            capture.Resume();

            Thread.Sleep(500);

            //Assert.IsTrue(capture.Frames > frames1);

            capture.Pause();
        }

        [TestMethod()]
        public void CaptureWorkerCaptureTime()
        {
            Assert.IsTrue(capture.CaptureTime.ElapsedMilliseconds == 0);

            capture.Start();

            Thread.Sleep(500);

            Assert.IsTrue(capture.CaptureTime.ElapsedMilliseconds > 0);

            capture.Pause();

            long elapsedTime1 = capture.CaptureTime.ElapsedMilliseconds;

            capture.Resume();

            Thread.Sleep(500);

            Assert.IsTrue(capture.CaptureTime.ElapsedMilliseconds > elapsedTime1);

            capture.Pause();
        }
    }
}
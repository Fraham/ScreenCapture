using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture.ScreenCapture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenCapture.ScreenCapture.Tests
{
    [TestClass()]
    public class frmFeedTests
    {
        private frmFeed feed;
        [TestInitialize()]
        public void Initialize()
        {
            feed = new frmFeed(new Options.Options(100, 100, new Point(3, 4)));
        }

        [TestMethod()]
        public void CaptureOptions()
        {
            Assert.AreEqual(new Options.Options(100, 100, new Point(3, 4)), feed.UsersOptions);
            Assert.AreNotEqual(new Options.Options(101, 100, new Point(3, 4)), feed.UsersOptions);
        }

        [TestMethod()]
        public void startFeed()
        {
            feed.startFeed();

            Assert.IsTrue(feed.FeedWorker.Started);
            Assert.IsTrue(feed.FeedWorker.Capturing);
        }

        [TestMethod()]
        public void pauseFeed()
        {
            feed.startFeed();
            feed.pauseFeed();

            Assert.IsTrue(feed.FeedWorker.Started);
            Assert.IsFalse(feed.FeedWorker.Capturing);
        }

        [TestMethod()]
        public void stopFeed()
        {
            feed.startFeed();
            feed.stopFeed();

            Assert.IsFalse(feed.FeedWorker.Started);
            Assert.IsFalse(feed.FeedWorker.Capturing);
        }

        [TestMethod()]
        public void resumeFeed()
        {
            feed.startFeed();
            feed.pauseFeed();
            feed.resumeFeed();

            Assert.IsTrue(feed.FeedWorker.Started);
            Assert.IsTrue(feed.FeedWorker.Capturing);
        }

        [TestMethod()]
        public void Frames()
        {
            Assert.IsTrue(feed.FeedWorker.Frames == 0);

            feed.startFeed();

            Thread.Sleep(500);

            Assert.IsTrue(feed.FeedWorker.Frames > 0);

            feed.pauseFeed();

            int frames1 = feed.FeedWorker.Frames;

            feed.resumeFeed();

            Thread.Sleep(500);

            Assert.IsTrue(feed.FeedWorker.Frames > frames1);

            feed.pauseFeed();
        }
    }
}
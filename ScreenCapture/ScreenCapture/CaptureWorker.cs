namespace ScreenCapture
{
    internal class CaptureWorker
    {
        private int captureWidth;
        private int captureHeight;

        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;

        public CaptureWorker(int captureWidth, int captureHeight)
        {

        }

        /// <summary>
        ///
        /// </summary>
        public void DoCapture()
        {

        }

        public void RequestStop()
        {
            
        }
    }
}
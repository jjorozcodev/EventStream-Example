using System;
using System.Threading.Tasks;

namespace SSE_Demo_Async
{
    public static class PoolTimer
    {
        public static DateTime nextUpdate;

        static PoolTimer()
        {
            Task.Run(() =>
            {
                nextUpdate = DateTime.Now;
                nextUpdate = nextUpdate.AddSeconds(60 - nextUpdate.Second);
                nextUpdate = nextUpdate.AddMilliseconds(-nextUpdate.Millisecond);

                while (true)
                {
                    DateTime timeNow = DateTime.Now;
                    timeNow = timeNow.AddMilliseconds(-timeNow.Millisecond);

                    if (timeNow.Second % 10 == 0 && timeNow.ToLongTimeString() == nextUpdate.ToLongTimeString())
                    {
                        nextUpdate = timeNow.AddSeconds(10);

                        System.Diagnostics.Debug.WriteLine(nextUpdate.ToString("HH:mm:ss.fff") + " ... " + timeNow.ToString("HH:mm:ss.fff"));
                    }
                }
            });
        }        
    }
}

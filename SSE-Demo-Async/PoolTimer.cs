using System;
using System.Threading.Tasks;

namespace SSE_Demo_Async
{
    public static class PoolTimer
    {

        public static async Task SyncEvent()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}
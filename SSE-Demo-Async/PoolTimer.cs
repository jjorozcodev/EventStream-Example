using System;
using System.Threading.Tasks;

namespace SSE_Demo_Async
{
    public static class PoolTimer
    {
        private static DateTime timeUpdated;

        public static async Task<string> GetServerTime(string name)
        {
            string resp = string.Empty;
            DateTime timeNow;

            await Task.Run(() =>
            {
                while (true)
                {
                    timeNow = DateTime.Now;

                    if ((timeNow.ToLongTimeString() != timeUpdated.ToLongTimeString()) && timeNow.Second % 5 == 0)
                    {
                        timeUpdated = timeNow;
                        resp = "data: " + name + ", the server time is> " + timeUpdated.ToLongTimeString();
                        break;
                    }
                }
            });

            return resp;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace CustomRandom
{
    /// <summary>
    /// Cloudflare has a public API for Drand, which gives random values periodically which are unpredictable and mathematically random
    /// </summary>
    public static class CloudflareDrand
    {
        private class DrandResponse
        {
            public string randomness { get; set; } = "";
        }

        public static async Task<ulong> SendRequestToCloudflare()
        {
            using HttpClient client = new HttpClient();

            string json = await client.GetStringAsync("https://drand.cloudflare.com/public/latest");

            DrandResponse result = JsonSerializer.Deserialize<DrandResponse>(json) ?? throw new Exception("Invalid response");

            return BitConverter.ToUInt64(Convert.FromHexString(result.randomness), 0);
        }
    }
}

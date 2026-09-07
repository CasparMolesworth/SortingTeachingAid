using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomRandom
{
    public class CustomRandomGenerator
    {
        private ulong currentValue;

        public CustomRandomGenerator(ulong seed = 0)
        {
            currentValue = seed == 0 ? GenerateSeed() : seed;
        }

        private ulong GenerateSeed()
        {
            ulong seed = 0;

            // First value is the current time in ticks
            ulong value1 = (ulong)DateTime.Now.Ticks;

            // Second value is a random number generated using RandomNumberGenerator from .NET
            byte[] randomBytes = new byte[8];
            RandomNumberGenerator.Fill(randomBytes);
            ulong value2 = BitConverter.ToUInt64(randomBytes, 0);

            // Third value is a random number from Cloudflare Drand
            // ulong value3 = CloudflareDrand.SendRequestToCloudflare().Result; THIS LINE CAUSES THE PROGRAM TO CRASH - I'M WORKING ON A FIX FOR IT

            seed = value1 ^ value2;

            return seed;
        }

        private ulong Next()
        {
            currentValue = 6364136223846793005UL * currentValue + 1442695040888963407UL;
            return currentValue;
        }

        public int Next(int min, int max)
        {
            if (min >= max)
                throw new ArgumentException("Silly billy. Min must be less than max.");

            ulong value = Next();

            return (int)(value % (ulong)(max - min)) + min;
        }

    }


}


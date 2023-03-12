using System;

namespace Forum.Services
{
    public class RandomGeneratorId
    {
        public static int GetRndNumber()
        {
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            return random.Next();
        }
    }
}
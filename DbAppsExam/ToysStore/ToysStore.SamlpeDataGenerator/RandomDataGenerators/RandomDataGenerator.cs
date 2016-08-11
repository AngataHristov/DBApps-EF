namespace ToysStore.SamlpeDataGenerator.RandomDataGenerators
{
    using System;
    using System.Text;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private static IRandomDataGenerator randomDataGenerator;
        private readonly Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            var result = this.random.Next(min, max + 1);

            return result;
        }

        public string GetRandomString(int length)
        {
            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[this.GetRandomNumber(0, Alphabet.Length - 1)]);
            }

            return result.ToString();
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            int randomLength = this.GetRandomNumber(min, max);

            return this.GetRandomString(randomLength);
        }
    }
}

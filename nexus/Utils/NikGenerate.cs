namespace nexus.Utils
{
    public class NikGenerate
    {
        private static readonly NikGenerate _instance = new NikGenerate();
        private Random _random = new Random();

        public static NikGenerate Instance
        {
            get
            {
                return _instance;
            }
        }

        public int SixDigit()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // Use seconds for less precision
            int lastSixDigits = (int)(timestamp % 1000000); // Extract last six digits

            return lastSixDigits + _random.Next(0, 1000000) % 1000000; // Add random value to ensure uniqueness
        }
        
        public int EightDigit()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // Use seconds for less precision
            int lastEightDigits = (int)(timestamp % 100000000); // Extract last eight digits

            return lastEightDigits + _random.Next(0, 100000000) % 100000000; // Add random value to ensure uniqueness
        }

        public long TenDigit()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // Generate a ten-digit ID based on the timestamp
            long tenDigitId = timestamp % 10000000000L; // Take last ten digits of the timestamp

            
            return tenDigitId + _random.NextInt64(0, 1000000000) % 10000000000L; // Ensure the ID is ten digits by potentially adding a random component
        }
    }
}

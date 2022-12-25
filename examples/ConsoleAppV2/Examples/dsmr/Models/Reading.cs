namespace ConsoleAppV2.Examples.DSMR.Models
{
    public class Reading
    {
        public int Count { get; set; }

        // http://api.example.org/accounts/?offset=400&limit=100
        public string? Next { get; set; }

        // http://api.example.org/accounts/?offset=200&limit=100
        public string? Previous { get; set; }

        public DsmrReading[] Results { get; set; } = null!;
    }
}
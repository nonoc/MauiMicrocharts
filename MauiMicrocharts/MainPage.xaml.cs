using Microcharts;
using SkiaSharp;

namespace MauiMicrocharts
{
    public partial class MainPage : ContentPage
    {
        public BarChart BarChart { get; set; }

        public MainPage()
        {
            InitializeComponent();

            BarChart = GenerateBarChart(new DateTime(2024, 11, 1), new DateTime(2024, 11, 8));

            BindingContext = this;
        }
              

        public BarChart GenerateBarChart(DateTime startDate, DateTime endDate)
        {
            var entries = GenerateEntries(startDate, endDate);

            return new BarChart
            {
                Entries = entries,
                LabelTextSize = 30,
                BackgroundColor = SKColors.White,
                MaxValue = 10,  // Customize as needed
                MinValue = -5   // Customize as needed
            };
        }

        private List<ChartEntry> GenerateEntries(DateTime startDate, DateTime endDate)
        {
            var entries = new List<ChartEntry>();
            var random = new Random();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var value = random.Next(-5, 10);  // Random value for the bar
                entries.Add(new ChartEntry(value)
                {
                    Label = date.ToString("MMM dd"),
                    ValueLabel = value.ToString(),
                    Color = value >= 0 ? SKColor.Parse("#2E8B57") : SKColor.Parse("#DC143C")
                });
            }

            return entries;
        }
    }

}

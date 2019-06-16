using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork24_06_19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PairAnalyzeButtonClick(object sender, RoutedEventArgs e)
        {
            Pair pair = new Pair();
            string maleName = maleNameTextBox.Text.Trim();
            string femaleName = femaleNameTextBox.Text.Trim();

            Task.Run(() =>
            {
                string result;

                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers.Add("X-RapidAPI-Host", "love-calculator.p.rapidapi.com");
                        client.Headers.Add("X-RapidAPI-Key", "e2ba7ffa30msh02aca4913ced372p15e70ajsn7a3200da9671");
                        result = client.DownloadString($@"https://love-calculator.p.rapidapi.com/getPercentage?fname={maleName}&sname={femaleName}");
                    }

                    pair = JsonConvert.DeserializeObject<Pair>(result);
                }
                catch (WebException)
                {
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.Headers.Add("X-RapidAPI-Host", "love-calculator.p.rapidapi.com");
                            client.Headers.Add("X-RapidAPI-Key", "e2ba7ffa30msh02aca4913ced372p15e70ajsn7a3200da9671");
                            result = client.DownloadString($@"https://love-calculator.p.rapidapi.com/getPercentage?fname={maleName}&sname={femaleName}");
                        }

                        pair = JsonConvert.DeserializeObject<Pair>(result);
                    }
                    catch(WebException)
                    {
                        MessageBox.Show("This pair can't be analyzed");
                    }
                }
            });

            percentTextBlock.Text = pair.Percentage;
            commentTextBlock.Text = pair.Comment;
        }
    }
}

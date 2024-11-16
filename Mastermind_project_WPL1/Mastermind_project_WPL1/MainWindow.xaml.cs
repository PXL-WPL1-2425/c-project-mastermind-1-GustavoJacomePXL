using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermind_project_WPL1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = generateRandomColorCode();

            // Vul de ComboBoxen met kleuren
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            ComboBox1.ItemsSource = colors;
            ComboBox2.ItemsSource = colors;
            ComboBox3.ItemsSource = colors;
            ComboBox4.ItemsSource = colors;

            // event handlers voor kleurenselectie
            ComboBox1.SelectionChanged += (s, e) => updateLabel(Label1, ComboBox1.SelectedItem.ToString());
            ComboBox2.SelectionChanged += (s, e) => updateLabel(Label2, ComboBox2.SelectedItem.ToString());
            ComboBox3.SelectionChanged += (s, e) => updateLabel(Label3, ComboBox3.SelectedItem.ToString());
            ComboBox4.SelectionChanged += (s, e) => updateLabel(Label4, ComboBox4.SelectedItem.ToString());
        }

        // methode om random kleurencode te genereren
        private string generateRandomColorCode()
        {
            // beschikbare kleuren
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();
            string[] randomColors = new string[4];

            // genereer vier willekeurige kleuren
            for (int i = 0; i < 4; i++)
            {
                randomColors[i] = colors[random.Next(colors.Length)];
            }

            // combineer de kleuren met een scheidingsteken
            return string.Join(" - ", randomColors);
        }

        // methode om de achtergrondkleur te tonen
        private void updateLabel(Label label, string color)
        {
            label.Content = color;
            label.Background = color switch
            {
                "Rood" => Brushes.Red,
                "Geel" => Brushes.Yellow,
                "Oranje" => Brushes.Orange,
                "Wit" => Brushes.White,
                "Groen" => Brushes.Green,
                "Blauw" => Brushes.Blue,
                _ => Brushes.Transparent
            };
        }

    }
}
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

            // Vul de comboBoxen met kleuren
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            comboBox1.ItemsSource = colors;
            comboBox2.ItemsSource = colors;
            comboBox3.ItemsSource = colors;
            comboBox4.ItemsSource = colors;

            // Event handlers voor kleurenselectie
            comboBox1.SelectionChanged += (s, e) => updateLabel(label1, comboBox1.SelectedItem.ToString());
            comboBox2.SelectionChanged += (s, e) => updateLabel(label2, comboBox2.SelectedItem.ToString());
            comboBox3.SelectionChanged += (s, e) => updateLabel(label3, comboBox3.SelectedItem.ToString());
            comboBox4.SelectionChanged += (s, e) => updateLabel(label4, comboBox4.SelectedItem.ToString());
        }

        // Methode om random kleurencode te genereren
        private string generateRandomColorCode()
        {
            // Beschikbare kleuren
            string[] colors = { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };
            Random random = new Random();
            string[] randomColors = new string[4];

            // Genereer vier willekeurige kleuren
            for (int i = 0; i < 4; i++)
            {
                randomColors[i] = colors[random.Next(colors.Length)];
            }

            // Combineer de kleuren met een scheidingsteken
            return string.Join(" - ", randomColors);
        }

        // Methode om de achtergrondkleur te tonen
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

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            // Haal de geselecteerde kleuren op uit de comboBoxen
            string[] selectedColors = {
                comboBox1.SelectedItem?.ToString(),
                comboBox2.SelectedItem?.ToString(),
                comboBox3.SelectedItem?.ToString(),
                comboBox4.SelectedItem?.ToString()
            };

            // Haal de gegenereerde kleurencode op
            string[] targetColors = Title.Split(" - ");

            // Maak een array van booleans om bij te houden welke kleuren al als correct gemarkeerd zijn
            bool[] correctPositions = new bool[4];
            Array.Fill(correctPositions, false);

            // Controleer de geselecteerde kleuren en pas de randkleur aan
            updateBorder(label1, selectedColors[0], targetColors, 0, ref correctPositions);
            updateBorder(label2, selectedColors[1], targetColors, 1, ref correctPositions);
            updateBorder(label3, selectedColors[2], targetColors, 2, ref correctPositions);
            updateBorder(label4, selectedColors[3], targetColors, 3, ref correctPositions);
        }

        // Methode om de randen de juiste kleur te geven op basis van de ingevulde kleur
        private void updateBorder(Label label, string selectedColor, string[] targetColors, int index, ref bool[] correctPositions)
        {
            // Controleer of de kleur op de juiste plaats staat
            if (targetColors[index] == selectedColor)
            {
                label.BorderBrush = Brushes.DarkRed;
                label.BorderThickness = new Thickness(4);
                correctPositions[index] = true;
            }
            // Als de kleur niet op de juiste plaats staat, maar wel voorkomt in de code
            else if (Array.Exists(targetColors, color => color == selectedColor) && !correctPositions.Contains(true))
            {
                label.BorderBrush = Brushes.Wheat;
                label.BorderThickness = new Thickness(4);
            }
            else
            {
                label.BorderBrush = Brushes.Transparent;
                label.BorderThickness = new Thickness(0);
            }
        }
    }
}
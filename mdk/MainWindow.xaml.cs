using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mdk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            int dice1Faces = int.Parse(Dice1FacesTextBox.Text);
            int dice2Faces = int.Parse(Dice2FacesTextBox.Text);

            int result1 = random.Next(1, dice1Faces + 1);
            int result2 = random.Next(1, dice2Faces + 1);

            Dice1ResultLabel.Content = $"Кубик 1: {result1}";
            Dice2ResultLabel.Content = $"Кубик 2: {result2}";

            int total = result1 + result2;
            TotalResultLabel.Content = $"Общее значение: {total}";

            int userGuess = int.Parse(UserGuessTextBox.Text);
            double probability = CalculateProbability(dice1Faces, dice2Faces, userGuess);
            ProbabilityLabel.Content = $"Вероятность угадывания: {probability:P}";
        }

        private double CalculateProbability(int dice1Faces, int dice2Faces, int userGuess)
        {
            int favorableOutcomes = 0;
            int possibleOutcomes = dice1Faces * dice2Faces;

            for (int i = 1; i <= dice1Faces; i++)
            {
                for (int j = 1; j <= dice2Faces; j++)
                {
                    if (i + j == userGuess)
                    {
                        favorableOutcomes++;
                    }
                }
            }

            return (double)favorableOutcomes / possibleOutcomes;
        }
    }
}

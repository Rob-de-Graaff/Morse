using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Morse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> encodeDictionary = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            encodeDictionary.Add(" ", " ");
            encodeDictionary.Add("A", ".-");
            encodeDictionary.Add("B", "-...");
            encodeDictionary.Add("C", "-.-.");
            encodeDictionary.Add("D", "-..");
            encodeDictionary.Add("E", ".");
            encodeDictionary.Add("F", "..-.");
            encodeDictionary.Add("G", "--.");
            encodeDictionary.Add("H", "....");
            encodeDictionary.Add("I", "..");
            encodeDictionary.Add("J", ".---");
            encodeDictionary.Add("K", "-.-");
            encodeDictionary.Add("L", ".-..");
            encodeDictionary.Add("M", "--");
            encodeDictionary.Add("N", "-.");
            encodeDictionary.Add("O", "---");
            encodeDictionary.Add("P", ".--.");
            encodeDictionary.Add("Q", "--.-");
            encodeDictionary.Add("R", ".-.");
            encodeDictionary.Add("S", "...");
            encodeDictionary.Add("T", "-");
            encodeDictionary.Add("U", "..-");
            encodeDictionary.Add("V", "...-");
            encodeDictionary.Add("W", ".--");
            encodeDictionary.Add("X", "-..-");
            encodeDictionary.Add("Y", "-.--");
            encodeDictionary.Add("Z", "--..");

            encodeDictionary.Add("1", ".----");
            encodeDictionary.Add("2", "..---");
            encodeDictionary.Add("3", "...--");
            encodeDictionary.Add("4", "....-");
            encodeDictionary.Add("5", ".....");
            encodeDictionary.Add("6", "-....");
            encodeDictionary.Add("7", "--...");
            encodeDictionary.Add("8", "---..");
            encodeDictionary.Add("9", "----.");
            encodeDictionary.Add("0", "-----");
        }

        private void ButtonEncryption_Click(object sender, RoutedEventArgs e)
        {
            string morse = string.Empty;
            textboxRight.Clear();

            if (textboxLeft.Text != "")
            {
                foreach (char character in textboxLeft.Text)
                {
                    morse += encodeDictionary[character.ToString().ToUpper()] + " ";
                }

                textboxRight.AppendText(morse);
            }
            else
            {
                MessageBox.Show("Text must be entered");
            }
        }

        private void ButtonDecryption_Click(object sender, RoutedEventArgs e)
        {
            string text = string.Empty;
            textboxLeft.Clear();

            if (textboxRight.Text != "")
            {
                foreach (string morseSign in textboxRight.Text.Split(' '))
                {
                    if (!Regex.IsMatch(morseSign, @"^[a-zA-Z0-9]*$"))
                    {
                        text += encodeDictionary.FirstOrDefault(x => x.Value == morseSign).Key + " ";
                    }
                    else
                    {
                        MessageBox.Show("Only morse code must be entered");
                        break;
                    }

                }

                textboxLeft.AppendText(text);
            }
            else
            {
                MessageBox.Show("Text must be entered");
            }
        }
    }
}

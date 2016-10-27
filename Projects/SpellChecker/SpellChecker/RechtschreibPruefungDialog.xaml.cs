using System;
using System.Collections.Generic;
using System.Windows;

namespace SpellChecker.UI
{
    /// <summary>
    /// Interaction logic for RechtschreibPrüfungDialog.xaml
    /// </summary>
    public partial class RechtschreibPruefungDialog : Window
    {
        public RechtschreibPruefungDialog()
        {
            InitializeComponent();
        }

        public event Action RechtschreibprüfungStarten;

        public string Eingabe => Text.Text;

        private void RechtschreibprüfungStarten_Click(object sender, RoutedEventArgs e)
        {
            RechtschreibprüfungStarten();
        }

        public void FehlerhafteWörterSetzen(IEnumerable<string> fehlerhafteWörter)
        {
            FehlerhafteWörter.ItemsSource = fehlerhafteWörter;
        }
    }
}

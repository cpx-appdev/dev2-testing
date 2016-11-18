using System.Windows;
using SpellChecker.Resourcen;

namespace SpellChecker.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dialog = new RechtschreibPruefungDialog();

            var interaktor = new Interaktor(new TextInWörterZerleger(), new WörterbuchProvider(new DateiLeser(), new WörterErmittler()), new TextAnalyse(),
                new WortAufbereiter());

            dialog.RechtschreibprüfungStarten += () => dialog.FehlerhafteWörterSetzen(interaktor.Prüfen(dialog.Eingabe));

            dialog.Show();
        }
    }
}

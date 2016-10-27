using System.Windows;

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
            dialog.RechtschreibprüfungStarten += () => dialog.FehlerhafteWörterSetzen(Interaktor.Prüfen(dialog.Eingabe));

            dialog.Show();
        }
    }
}

using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public interface IWörterbuchProvider
    {
        HashSet<string> WörterbuchAuslesen();
    }

    public class WörterbuchProvider : IWörterbuchProvider
    {
        private readonly IDateiLeser _dateiLeser;
        private readonly IWörterErmittler _wörterErmittler;

        public WörterbuchProvider(IDateiLeser dateiLeser, IWörterErmittler wörterErmittler)
        {
            _dateiLeser = dateiLeser;
            _wörterErmittler = wörterErmittler;
        }
        public HashSet<string> WörterbuchAuslesen()
        {
            var zeilen = _dateiLeser.DateiLesen();
            return _wörterErmittler.WörterErmitteln(zeilen);
        }
    }
}
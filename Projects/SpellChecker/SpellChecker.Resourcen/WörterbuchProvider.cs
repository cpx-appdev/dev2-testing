using System.Collections.Generic;

namespace SpellChecker.Resourcen
{
    public interface IW�rterbuchProvider
    {
        HashSet<string> W�rterbuchAuslesen();
    }

    public class W�rterbuchProvider : IW�rterbuchProvider
    {
        private readonly IDateiLeser _dateiLeser;
        private readonly IW�rterErmittler _w�rterErmittler;

        public W�rterbuchProvider(IDateiLeser dateiLeser, IW�rterErmittler w�rterErmittler)
        {
            _dateiLeser = dateiLeser;
            _w�rterErmittler = w�rterErmittler;
        }
        public HashSet<string> W�rterbuchAuslesen()
        {
            var zeilen = _dateiLeser.DateiLesen();
            return _w�rterErmittler.W�rterErmitteln(zeilen);
        }
    }
}
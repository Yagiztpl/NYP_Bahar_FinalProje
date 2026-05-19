using ColortextFunction;
using Mahzen.Common.Config;

namespace Mahzen.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Eklentilerimi yüklüyor
            Mahzen.Common.Config.Eklentiler.Yukle();
            ColorText.CWriteLine("g", "Mahzen'e Hoş Geldin...");
        }
    }
}

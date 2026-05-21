using ColortextFunction;
using Mahzen.Business.Managers;
using Mahzen.Common.Config;
using Mahzen.Entities.Concrete;

namespace Mahzen.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleArayuz arayuz = new ConsoleArayuz();
            arayuz.OyunuBaslat();
        }
    }
}

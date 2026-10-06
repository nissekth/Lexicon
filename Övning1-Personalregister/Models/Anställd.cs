
namespace Personalregister.Models
{
    internal class Anställd(string förnamn, string efternamn, double lön = 0)
    {
        private string förnamn = förnamn;
        public string Förnamn => förnamn;
        private string efternamn = efternamn;
        public string Efternamn => efternamn;
        private double lön = lön;
        public double Lön => lön;

    }

}
using Personalregister.Models;

namespace Personalregister.DBHandler
{
    internal class Register
    {
        
        List<Anställd> personalRegister = new List<Anställd>();

        public void LäggTillAnställd(Anställd person)
        {

            foreach (Anställd anställd in personalRegister)
            {
                if(anställd.Förnamn.Equals(person.Förnamn) && anställd.Efternamn.Equals(person.Efternamn))
                {
                    throw new Exception("Personen finns redan i registret.");
                }
            }

            personalRegister.Add(person); 
            
        }
        
        public List<Anställd> HämtaAllaAnställda()
        {
            if (personalRegister.Count == 0)
            {
                throw new Exception("Registret är tomt.");
            }
            return personalRegister;
        }

        public Anställd HämtaSpecifikAnställd(string förnamn, string efternamn)
        {
            for(int i = 0; i < personalRegister.Count; i++)
            {
                if(personalRegister[i].Förnamn.Equals(förnamn) && personalRegister[i].Efternamn.Equals(efternamn))
                {
                    return personalRegister[i];
                }
            }

            throw new Exception("Personen finns inte i registret.");
        }

    }

}
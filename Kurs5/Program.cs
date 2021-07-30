using System;

namespace Kurs5
{
    class Program
    {
        static void Main(string[] args)
        {
            GamerManager gamerManager = new GamerManager(new UserValidationManager());
            Gamer gamer = new Gamer();
            gamer.Name = "Ege";
            gamer.LastName = "Tali";
            gamer.Id = 1;
            gamer.BirthYear = 2000;
            gamer.IdentityNumber = 12345;
            gamerManager.Add(gamer);
        }
    }
}

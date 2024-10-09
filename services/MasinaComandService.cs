using InterfaceExersare.models;
using InterfaceExersare.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare.services
{
    public class MasinaComandService : IMasinaComandService
    {
        private IMasinaRepository _mRepository;

        public MasinaComandService( IMasinaRepository masinaRepository)
        {
            _mRepository = masinaRepository;           
        }


        //CRUD

        public Masina RemoveMasina(Masina masina)
        {
            _mRepository.Remove(masina);

            return masina;
        }

        public Masina UpdateMasina(Masina masina)
        {
            if (masina != null)
            {
                Console.WriteLine("Ce vrei sa modifici la masina?");
                Console.WriteLine("1. Brand");
                Console.WriteLine("2. Greutate");
                Console.WriteLine("3. Viteza maxima");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.WriteLine("Introdu noul brand:");
                        masina.Brand = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Introdu noua greutate:");
                        masina.Weight = Int32.Parse(Console.ReadLine());
                        break;

                    case "3":
                        Console.WriteLine("Introdu noua viteza maxima:");
                        masina.topSpeed = Int32.Parse(Console.ReadLine());
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        return null;
                }

                _mRepository.UpdateCar(masina);
            }

            return null;
        }

        public Masina AddMasina(Masina masina)
        {
            _mRepository.Add(masina);

            return masina;
        }
    }
}

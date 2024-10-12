using InterfaceExersare.models;
using InterfaceExersare.repository;
using InterfaceExersare.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare
{
    public class View
    {
        private IMasinaQueryService _masinaQueryService;
        private IMasinaComandService _masinaComandService;
 
      

        public View(IMasinaQueryService masinaQueryService, IMasinaComandService masinaComandService, IMasinaRepository masinaRepository)
        {
            _masinaQueryService = masinaQueryService;
            _masinaComandService = masinaComandService;
        }

        public void Meniu()
        {
            Console.WriteLine("Apasa tasta 1 pentru a vedea toate masinile");
            Console.WriteLine("Apasa tasta 2 pentru a vedea toate masinile dupa Brand, weight, top speed");
            Console.WriteLine("Apasa tasta 3 pentru a adauga o masina!");
            Console.WriteLine("Apasa tasta 4 pentru a edita o masina!");
            Console.WriteLine("Apasa tasta 5 pentru a sterge o masina");
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                Meniu();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        AfisareMasini();
                        break;

                    case "2":
                        AfisareMasiniByFilter();
                        break;

                    case "3":
                        AddMasina();
                        break;

                    case "4":
                        EditMasina();
                        break;

                    case "5":
                        RemoveMasina();
                        break;

                    default:
                        running = false;
                        break;
                }
            }
        }

        public void AfisareMasini()
        {

            if (this._masinaQueryService.getAll() == null)
            {
                Console.WriteLine("Nu avem masini");
            }
            else
            {

                foreach(Masina m in this._masinaQueryService.getAll())
                {
                    Console.WriteLine(m);
                }
            }
        }

        public void AfisareMasiniByFilter()
        {
            Console.WriteLine("Dupa ce vrei sa cauti masina: brand, weight, top speed?");
            string filterType = Console.ReadLine().ToLower();

            string filterValueString = null;
            int filterValueInt = 0;
            bool isValidFilter = true;

            if (filterType == "brand")
            {
                Console.WriteLine("Introdu brand-ul dupa care vrei sa cauti masina:");
                filterValueString = Console.ReadLine();

                if (filterValueString == null)
                {
                    Console.WriteLine("Valoare invalida.");
                    isValidFilter = false;
                }
            }
            else if (filterType == "weight")
            {
                Console.WriteLine("Introdu valoarea numerica pentru greutate:");
                filterValueInt = Int32.Parse(Console.ReadLine());

                if (filterValueInt == -1)
                {
                    Console.WriteLine("Valoare invalida.");
                    isValidFilter = false;
                }
            }
            else if (filterType == "topspeed")
            {
                Console.WriteLine("Introdu valoarea numerica pentru viteza maxima:");
                filterValueInt = Int32.Parse(Console.ReadLine());

                if (filterValueInt == -1)
                {
                    Console.WriteLine("Valoare invalida.");
                    isValidFilter = false;
                }
            }
            else
            {
                Console.WriteLine("Filtru necunoscut.");
                return;
            }

            if (!isValidFilter) return;

            foreach (Masina m in this._masinaQueryService.getAll())
            {
                bool matchFound = false;

                if (filterType == "brand" && m.Brand.ToLower() == filterValueString.ToLower())
                {
                    matchFound = true;
                }
                else if (filterType == "weight" && m.Weight == filterValueInt)
                {
                    matchFound = true;
                }
                else if (filterType == "top speed" && m.topSpeed == filterValueInt)
                {
                    matchFound = true;
                }

                if (matchFound)
                {
                    Console.WriteLine($"Id-ul masinii este {m.Id}, brand-ul este {m.Brand}, greutatea este {m.Weight}, top speed-ul este {m.topSpeed}");
                }
            }
        }

        public int GeneratorId()
        {
            Random rnd = new Random();

            int id = rnd.Next(1, 1000000);

            while ((id) != null)
            {
                id = rnd.Next(1, 1000000);

            }

            return id;
        }

        public void AddMasina()
        {
            Console.WriteLine("Generare ID pentru noua mașină...");
            int id = GeneratorId();

            Console.WriteLine("Care este brandul mașinii?");
            string brand = Console.ReadLine();

            Console.WriteLine("Care este greutatea mașinii?");
            int weight = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Care este viteza maximă a mașinii?");
            int topSpeed = Int32.Parse(Console.ReadLine());

            Masina newMasina = new Masina(id, brand, weight, topSpeed);

            _masinaComandService.AddMasina(newMasina);

            if (newMasina != null)
            {
                Console.WriteLine("Mașina a fost adăugată cu succes.");
            }
            else
            {
                Console.WriteLine("Mașina cu acest ID există deja.");
            }

        }

        public string EditMasina()
        {
            Console.WriteLine("Introdu ID-ul mașinii pe care vrei să o editezi:");
            int id = Int32.Parse(Console.ReadLine());

            Masina masina = _masinaQueryService.FindCarById(id);

            bool updateMasina = false;

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
                        updateMasina = true;
                        _masinaComandService.UpdateCar(masina);
                        break;

                    case "2":
                        Console.WriteLine("Introdu noua greutate:");
                        masina.Weight = Int32.Parse(Console.ReadLine());
                        _masinaComandService.UpdateCar(masina);
                        updateMasina = true;
                        break;

                    case "3":
                        Console.WriteLine("Introdu noua viteza maxima:");
                        masina.topSpeed = Int32.Parse(Console.ReadLine());
                        _masinaComandService.UpdateCar(masina);
                        updateMasina = true;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        return null;
                }
            }

            if (updateMasina == true)
            {
                Console.WriteLine("Mașina a fost actualizată cu succes.");
            }
            else
            {
                Console.WriteLine("Mașina cu acest ID nu a fost găsită.");
            }

            return null;
        }

        public void RemoveMasina()
        {
            Console.WriteLine("Introdu ID-ul mașinii pe care vrei să o ștergi:");
            int id = Int32.Parse(Console.ReadLine());

            Masina masina = _masinaQueryService.FindCarById(id);

            Masina removeMasina = _masinaComandService.RemoveMasina(masina);

            if (removeMasina != null)
            {
                Console.WriteLine("Mașina a fost ștearsă cu succes.");
            }
            else
            {
                Console.WriteLine("Mașina cu acest ID nu a fost găsită.");
            }
        }


    }
}

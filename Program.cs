using InterfaceExersare;
using InterfaceExersare.models;
using InterfaceExersare.repository;
using InterfaceExersare.services;

public class Program
{
    private static void Main(string[] args)
    {

        MasinaRepository repository = new MasinaRepository();

        MasinaQueryService masinaQueryService = new MasinaQueryService(repository);
        MasinaComandService masinaComandService = new MasinaComandService(repository);

        View view = new View(masinaQueryService, masinaComandService, repository);

        view.play();

        //repository.SaveData();

        //view.AfisareMasini();



        //masinaComandService.AddMasina(new Masina(6, "dwada", 1500, 240));
        //repository.SaveData();
        //view.AfisareMasini();




        //masinaComandService.UpdateMasina(5);
        //repository.SaveData();
        //view.AfisareMasini();



        //masinaComandService.RemoveMasina(5);
        //repository.SaveData();
        //view.AfisareMasini();

        //Masina masina = new Masina(1, "Xiaomi", 900, 900);

        //repository.UpdateCar(masina);


        //Masina masina = repository.FindById(1);
        //Console.WriteLine(masina);
    }
}
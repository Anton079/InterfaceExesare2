using InterfaceExersare.models;
using InterfaceExersare.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Repository -->Acces direct la fisier

//Query->Repo -->punem conditii de existenta

//view->Query 

namespace InterfaceExersare.repository
{
    public class MasinaRepository : IMasinaRepository
    {
        private List<Masina> masinaList;
    
        public MasinaRepository()
        { 
            masinaList = new List<Masina>();
            Load();
        }

        public void Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina masina = new Masina(line);
                        this.masinaList.Add(masina);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "Masina");

            return file;
        }

        public string ToSaveAll()
        {
            string save = "";

            for(int i = 0; i < masinaList.Count; i++)
            {
                save += masinaList[i].ToString();

                if(i< masinaList.Count - 1)
                {
                    save += "\n";
                }
            }

            return save;
        }


        //CRUD

        public List<Masina> getAll()
        {
            return masinaList;
        }

        public Masina Add(Masina masina)
        {
            this.masinaList.Add(masina);

            return masina;
        }

        public Masina Remove(Masina masina)
        {
            masinaList.Remove(masina);

            return masina;
        }

        public Masina UpdateCar(Masina masina)
        {
            for (int i = 0; i < masinaList.Count; i++)
            {
                if (masinaList[i].Id == masina.Id)
                {
                    masinaList[i] = masina;

                    return masina;
                }
            }
            return null;
        }

    }
}

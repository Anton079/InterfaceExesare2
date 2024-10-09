using InterfaceExersare.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare.repository
{
    public interface IMasinaRepository
    {
       


        Masina Add(Masina masina);

        List<Masina> getAll();
        
       Masina Remove(Masina masina);

       Masina  UpdateCar(Masina masina);
    }
}

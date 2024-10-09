using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceExersare.models;

namespace InterfaceExersare.services
{
    public interface IMasinaComandService 
    {
        Masina AddMasina(Masina masina);

        Masina RemoveMasina(Masina masina);

        Masina UpdateMasina(Masina masina);

    }
}

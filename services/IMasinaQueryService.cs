using InterfaceExersare.models;
using InterfaceExersare.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare.services
{
    //query se fac instrcutiunile ce nu afecteaza datele (interogari)
    public interface IMasinaQueryService 
    {
        List<Masina> getAll();

        Masina FindCarById(int id);

    }
}
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
            if(masina != null && _mRepository.FindById(masina.Id) != null)
            {
                _mRepository.Remove(masina);
                return masina;
            }

            return null;
        }

        public Masina AddMasina(Masina masina)
        {
            //  conditii de existenta
            if(masina != null && _mRepository.FindById(masina.Id) == null)
            {
                _mRepository.Add(masina);
                return masina;
            }

            return null;
        }

        public Masina UpdateCar(Masina masina)
        {
            if (masina != null && _mRepository.FindById(masina.Id) != null)
            {
                _mRepository.UpdateCar(masina);
                return masina;
            }
            return null;
        }
    }
}

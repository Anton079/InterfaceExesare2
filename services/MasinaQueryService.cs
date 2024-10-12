using InterfaceExersare.models;
using InterfaceExersare.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare.services
{
    public class MasinaQueryService : IMasinaQueryService
    {
        private IMasinaRepository _masinaRepository;

        public MasinaQueryService(IMasinaRepository masinaRepository)
        {
            _masinaRepository = masinaRepository;
        }


        //CRUD
        public List<Masina> getAll()
        {

            List<Masina> masinas = this._masinaRepository.getAll();

            if (masinas.Count == 0)
            {

                return null;
            }

            return masinas;
        }

        public Masina FindCarById(int id)
        {
            Masina masina = _masinaRepository.FindById(id);

            return masina;
        }
    }
}

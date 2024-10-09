using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExersare.models
{
    public class Masina
    {
        private int _id;
        private string _brand;
        private int _weight;
        private int _topSpeed;

        public Masina(string proprietati)
        {
            string[] tokne = proprietati.Split(',');

            _id = int.Parse(tokne[0]);
            _brand = tokne[1];
            _weight = int.Parse(tokne[2]);
            _topSpeed = int.Parse(tokne[3]);
        }

        public Masina(int id, string brand, int weight, int topSpeed)
        {
            _id = id;
            _brand = brand;
            _weight = weight;
            _topSpeed = topSpeed;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int topSpeed
        {
            get { return _topSpeed; }
            set { _topSpeed = value; }
        }

        public override string ToString()
        {
            return $"{Id},{Brand},{Weight},{topSpeed}";
        }

        public override bool Equals(object? obj)
        {
            Masina masina = obj as Masina;
            return _id == masina._id;
        }

        public string ToSave()
        {
            return Id + "," + Brand + "," + Weight + "," + topSpeed;
        }
    }
}

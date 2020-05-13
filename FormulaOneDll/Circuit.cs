using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Circuit
    {
        #region Attributes
        private int id;
        private string name;
        private int length;
        private int nLaps;
        private Country extCountry;
        private string recordLap;
        private string img;
        #endregion

        #region Constructors
        public Circuit() { }
        public Circuit(int id, string name, int length, int nLaps, Country extCountry, string recordLap, string img)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.NLaps = nLaps;
            this.ExtCountry = extCountry;
            this.RecordLap = recordLap;
            this.Img = img;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Length { get => length; set => length = value; }
        public int NLaps { get => nLaps; set => nLaps = value; }
        public Country ExtCountry { get => extCountry; set => extCountry = value; }
        public string RecordLap { get => recordLap; set => recordLap = value; }
        public string Img { get => img; set => img = value; }

        #endregion

        #region Methods
        public override string ToString() => $"{this.name}";
        #endregion
    }
}

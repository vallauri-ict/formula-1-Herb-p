using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Race
    {
        #region Attributes
        private int id;
        private string name;
        private Circuit extCircuit;
        private DateTime date;
        #endregion

        #region Constructors
        public Race() {}

        public Race(int id, string name, Circuit extCircuit, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.extCircuit = extCircuit;
            this.date = date;
        }

        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Circuit ExtCircuit { get => extCircuit; set => extCircuit = value; }
        public DateTime Date { get => date; set => date = value; }
        #endregion

        #region Methods
        public override string ToString() => $"{this.name}";
        #endregion
    }
}

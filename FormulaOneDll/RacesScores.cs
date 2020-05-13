using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class RacesScores
    {
        #region Attributes
        private int id;
        private Driver extDriver;
        private Scores extpos;
        private Race extRace;
        private string fastestLap;
        #endregion

        #region Constructors
        public RacesScores() { }
        public RacesScores(int id, Driver extDriver, Scores extpos, Race extRace, string fastestLap)
        {
            this.Id = id;
            this.ExtDriver = extDriver;
            this.Extpos = extpos;
            this.ExtRace = extRace;
            this.FastestLap = fastestLap;
        }

        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public Driver ExtDriver { get => extDriver; set => extDriver = value; }
        public Scores Extpos { get => extpos; set => extpos = value; }
        public Race ExtRace { get => extRace; set => extRace = value; }
        public string FastestLap { get => fastestLap; set => fastestLap = value; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Scores
    {
        #region Attributes
        private int score;
        private int pos;
        private string description;


        #endregion

        #region Constructors
        public Scores() { }
        public Scores(int score, int pos, string description)
        {
            this.score = score;
            this.pos = pos;
            this.description = description;
        }
        #endregion

        #region Properties
        public int Score { get => score; set => score = value; }
        public int Pos { get => pos; set => pos = value; }
        public string Description { get => description; set => description = value; }

        #endregion

        #region Methods
        public override string ToString() => $"{this.pos} {this.score} {this.description}";
        #endregion
    }
}

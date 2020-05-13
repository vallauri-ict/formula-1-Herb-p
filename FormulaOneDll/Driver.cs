using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDll
{
    public class Driver
    {
        #region Attributes
        private readonly int id;
        private string firstname;
        private string lastname;
        private DateTime dob;
        private string placeOfBirthday;
        private Country country;
        private string img;
        private string description;
        #endregion

        #region Constructors
        public Driver(int id) { this.id = id; }

        public Driver(int id, string firstname, string lastname, DateTime dob, string placeOfBirthday, Country country) : this (id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Dob = dob;
            this.PlaceOfBirthday = placeOfBirthday;
            this.Country = country;
        }
        public Driver(int id, string firstname, string lastname, DateTime dob, string placeOfBirthday, Country country,string img,string description) : this(id)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Dob = dob;
            this.PlaceOfBirthday = placeOfBirthday;
            this.Country = country;
            this.Img = img;
            this.Description = description;
        }
        #endregion

        #region Properties
        public int ID { get => id; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PlaceOfBirthday { get => placeOfBirthday; set => placeOfBirthday = value; }
        public Country Country { get => country; set => country = value; }
        public string Img { get => img; set => img = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Methods
        public override string ToString() => $"{this.Firstname} {this.lastname}";
        #endregion
    }
}

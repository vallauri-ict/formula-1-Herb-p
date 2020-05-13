using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.IO;

// Cercare questi pacchetti su nuget
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel;

using Newtonsoft.Json;

namespace FormulaOneDll
{
    public class DbTools
    {
        private const string WORKINGPATH = @"C:\Users\Alberto\Documents\GitHub\formula-1-Herb-p\Dati\";
        private string CONNECTION_STRING = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True";

        private Dictionary<int, Driver> drivers;
        private Dictionary<string, Country> countries;
        private List<Team> teams;
        private Dictionary<int,Circuit> circuits;
        private Dictionary<int, Race> races;
        private Dictionary<int, RacesScores> racesScores;
        private Dictionary<int, Scores> scrores;

        public Dictionary<int, Driver> Drivers
        {
            get
            {
                if (this.drivers == null || this.drivers.Count == 0)
                    this.GetDrivers();
                return this.drivers;
            }
            set => drivers = value;
        }
        public Dictionary<string, Country> Countries
        {
            get
            {
                if (this.countries == null || this.countries.Count==0)
                    this.GetCountries();
                return this.countries;
            }
            set => countries = value;
        }
        public List<Team> Teams
        {
            get
            {
                if (teams == null || teams.Count == 0)
                    this.LoadTeams();
                return teams;
            }
            set => teams = value;
        }

        public Dictionary<int, Circuit> Circuits
        {
            get
            {
                if (circuits == null || circuits.Count == 0)
                    this.LoadCircuits();
                return circuits;
            }
            set => circuits = value;
        }

        public Dictionary<int, Race> Races
        {
            get
            {
                if (races == null || races.Count == 0)
                    this.LoadRaces();
                return races;
            }
            set => races = value;
        }

        public Dictionary<int, RacesScores> RacesScores
        {
            get
            {
                if (racesScores == null || racesScores.Count == 0)
                    this.LoadRacesScores();
                return racesScores;
            }
            set => racesScores = value;
        }

        public Dictionary<int, Scores> Scores
        {
            get
            {
                if (scrores == null || scrores.Count == 0)
                    this.LoadScores();
                return scrores;
            }
            set => scrores = value;
        }

        //public void CreateCountriesWithSmo()
        //{
        //    string sqlConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; 
        //        AttachDbFilename =C:\Users\loren\OneDrive\Desktop\_Scuola\2019-2020\INFORMATICA\CAMBIERI\FormulaOneSolution\FormulaOne.mdf; Integrated Security = True";
        //    FileInfo file = new FileInfo(@"Countries.sql");
        //    string script = file.OpenText().ReadToEnd();
        //    SqlConnection conn = new SqlConnection(sqlConnectionString);
        //    Server server = new Server(new ServerConnection(conn));

        //    try
        //    {
        //        server.ConnectionContext.ExecuteNonQuery(script);
        //        file.OpenText().Close();
        //        conn.Close();
        //        Console.WriteLine("CreateCountries: SUCCESS");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex);
        //    }
        //}

        public void ExecuteSqlScript(string sqlScriptPath)
        {
            var fileContent = File.ReadAllText($"{WORKINGPATH}{sqlScriptPath}");
            fileContent = fileContent
                .Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var sqlQueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            var cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in sqlQueries)
            {
                cmd.CommandText = query;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Errore in esecuzione della query numero: {ex.LineNumber}");
                    Console.WriteLine($"Errore: {ex.Number} {ex.Message}");
                }
            }
            con.Close();
            con.Dispose();
            SqlConnection.ClearAllPools();
        }

        //public void MakeBackup()
        //{
        //    StreamReader sr = new StreamReader($"{WORKINGPATH}FormulaOne.mdf");
        //    StreamWriter sw = new StreamWriter($"{WORKINGPATH}FormulaOneBackup.mdf");
        //    sw.Write(sr.ReadToEnd());
        //    sr.Close();
        //    sw.Close();
        //}
        //public void Restore()
        //{
        //    StreamReader sr = new StreamReader($"{WORKINGPATH}FormulaOneBackup.mdf");
        //    StreamWriter sw = new StreamWriter($"{WORKINGPATH}FormulaOne.mdf");
        //    sw.Write(sr.ReadToEnd());
        //    sr.Close();
        //    sw.Close();
        //}

        //public void DropTable(string tableName)
        //{
        //    var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
        //    var cmd = new SqlCommand($"Drop Table {tableName};", con);
        //    con.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"Errore: {ex.Number} {ex.Message}");
        //    }
        //    con.Close();
        //    con.Dispose();
        //}

        public void GetCountries()
        {
            if (this.countries == null)
            {
                this.countries = new Dictionary<string, Country>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Countries;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string countryIsoCode = reader.GetString(0);
                        Country c = new Country()
                        {
                            CountryCode = countryIsoCode,
                            CountryName = reader.GetString(1)
                        };
                        this.countries.Add(countryIsoCode, c);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }


        public void GetDrivers(bool forceReload = false)
        {
            if (forceReload/* || this.countries == null*/)
                this.GetCountries();
            if (forceReload || this.drivers == null)
            {
                this.Drivers = new Dictionary<int, Driver>();
                var con = new SqlConnection(CONNECTION_STRING);
                using (con)
                {
                    con.Open();
                    var command = new SqlCommand("SELECT * FROM Drivers;", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int driverIsoCode = reader.GetInt32(0);
                        Driver d = new Driver(driverIsoCode)
                        {
                            Firstname = reader.GetString(1),
                            Lastname = reader.GetString(2),
                            Dob = reader.GetDateTime(3),
                            PlaceOfBirthday = reader.GetString(4),
                            Country = Countries[reader.GetString(5)],
                            Img = reader.GetString(6),
                            Description = reader.GetString(7)
                        };
                        this.Drivers.Add(driverIsoCode, d);
                    }
                    con.Close();
                    con.Dispose();
                }
                SqlConnection.ClearAllPools();
            }
        }

        public void LoadTeams()
        {
            GetCountries();
            GetDrivers(true);
            teams = new List<Team>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM Teams;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Team t = new Team()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FullTeamName = reader.GetString(2),
                        Country = this.Countries[reader.GetString(3)],
                        PowerUnit = reader.GetString(4),
                        TechnicalChief = reader.GetString(5),
                        Chassis = reader.GetString(6),
                        FirstDriver = this.Drivers[reader.GetInt32(7)],
                        SecondDriver = this.Drivers[reader.GetInt32(8)],
                        Logo = reader.GetString(9),
                        Img = reader.GetString(10)
                    };
                    teams.Add(t);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }
        public void LoadCircuits()
        {
            GetCountries();
            circuits = new Dictionary<int, Circuit>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM Circuits;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Circuit c = new Circuit();
                    /*{
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Legth = Convert.ToInt32(reader.GetString(2)),
                        NLaps = Convert.ToInt32(reader.GetString(3)),
                        ExtCountry = this.Countries[reader.GetString(4)],
                        RecordLap = reader.GetString(5),
                        Img = reader.GetString(6),
                    };*/
                    c.Id = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    c.Length = reader.GetInt32(2);
                    c.NLaps = reader.GetInt32(3);
                    c.ExtCountry = this.Countries[reader.GetString(4)];
                    c.RecordLap = reader.GetString(5);
                    c.Img = reader.GetString(6);
                    circuits.Add(reader.GetInt32(0), c);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }

        public void LoadRaces()
        {
            LoadCircuits();
            races = new Dictionary<int, Race>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM Races;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Race r = new Race()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ExtCircuit = this.circuits[reader.GetInt32(2)],
                        Date = reader.GetDateTime(3),
                    };
                    races.Add(reader.GetInt32(0), r);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }

        public void LoadRacesScores()
        {
            GetDrivers();
            LoadRaces();
            LoadScores();
            racesScores = new Dictionary<int, RacesScores>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM RacesScores;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RacesScores r = new RacesScores()
                    {
                        Id = reader.GetInt32(0),
                        ExtDriver = this.drivers[reader.GetInt32(1)],
                        Extpos = this.Scores[reader.GetInt32(2)], 
                        ExtRace = this.races[reader.GetInt32(3)],
                        FastestLap = reader.GetString(4).ToString()
                    };
                    racesScores.Add(reader.GetInt32(0),r);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }

        public void LoadScores()
        {
            races = new Dictionary<int,Race>();
            var con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={WORKINGPATH}FormulaOne.mdf;Integrated Security=True");
            using (con)
            {
                con.Open();
                var command = new SqlCommand("SELECT * FROM Scores;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Scores s = new Scores()
                    {
                        Pos = reader.GetInt32(0),
                        Score = reader.GetInt32(1),
                        Description = reader.GetString(2)
                    };
                    Scores.Add(reader.GetInt32(0),s);
                }
                con.Close();
                con.Dispose();
            }
            SqlConnection.ClearAllPools();
        }

        public bool SerializeToJSON<T>(IEnumerable<T> list, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                new StreamWriter(path, false).Write(json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

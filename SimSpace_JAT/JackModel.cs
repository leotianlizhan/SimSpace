using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimSpace_JAT
{
    class JackModel
    {
        private SharedVariables _variables;
        public JackModel(PlanetModelWrapper p, SharedVariables v) {
            _variables = v;
        }
        public bool BuildEmergencyServices(int a, int s)
        {
            return false;
        }
        public bool BuildSchool(int a, int s)
        {
            _variables.Facilities[a, s] = new School();
            return true;
        }
        public bool BuildMedicalFacility(int a, int s)
        {
            return false;
        }
        public bool BuildGovernmentFacility(int a, int s)
        {
            return false;
        }
        public bool BuildPowerPlant(int a, int s)
        {
            if (_variables.Facilities[a, s] is Dirt)
            {
                _variables.Facilities[a, s] = new Powerplant();
                return true;
            }
            return false;
        }
        public bool BuildFactory(int a, int s)
        {
            if (_variables.Facilities[a, s] is Dirt)
            {
                _variables.Facilities[a, s] = new Factory();
                return true;
            }
            return false;
        }
        public bool BuildEnvironmentalFacility(int a, int s)
        {
            return false;
        }
        public int CalculatePollution()
        {
            return 5000;
        }
        public int CalculateScore()
        {
            return 6000;
        }
        public void SaveHighScore()
        {
        }
        public void LoadHighScore()
        {
        }
    }
}

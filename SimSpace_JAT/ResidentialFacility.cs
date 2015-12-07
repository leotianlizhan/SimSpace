//Tianli Zhan
//December 2, 2015
//Abstract ResidentialFacility contains variables such as population that are shared by all child classes, such as LuxuryHome
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSpace_JAT
{
    abstract class ResidentialFacility : Facility
    {
        //stores the range this type of facility has to be within essential facility
        public const int RANGE_LIMIT = 8;
        //stores the maximum population for certain facility
        protected int _maxPopulation;
        //stores the amount of population
        protected int _population;
        //stores the factor to divide the population by, to get the happy population
        protected int _happyPopulationFactor;
        //stores the factor to divide the max population by, to get the increase for population
        protected const int POPULATION_GROWTH_FACTOR = 10;

        /// <summary>
        /// Called by child classes' constructors to create a residential facility with an initial population, used in loading the game
        /// </summary>
        /// <param name="population">Population the facility starts with</param>
        protected ResidentialFacility(int population)
        {
            Population = population;
        }
        /// <summary>
        /// Gets or sets the population
        /// </summary>
        public int Population
        {
            get
            {
                return _population;
            }
            protected set
            {
                _population = value;
            }
        }

        /// <summary>
        /// Calculate the amount of people that are happy in this facility
        /// </summary>
        /// <returns>The happy population for this facility</returns>
        public int GetHappyPopulation()
        {
            return Population / _happyPopulationFactor;
        }

        /// <summary>
        /// Increases the population, or not, depending on if it's filled, for this particular facility
        /// </summary>
        public void UpdatePopulation()
        {
            //check if the facility is filled, if it's not, increase the population
            if(!IsFilled())
                Population += _maxPopulation / POPULATION_GROWTH_FACTOR;
        }
        /// <summary>
        /// Check if the facility is filled to the maximum population
        /// </summary>
        /// <returns>Boolean indicating if it's all filled up</returns>
        protected bool IsFilled()
        {
            return Population >= _maxPopulation;
        }

        /// <summary>
        /// Gets the revenue, pre-calculated based on population
        /// </summary>
        public override int Revenue
        {
            get
            {
                return base.Revenue * Population / 1000;
            }
        }
        /// <summary>
        /// Gets the population, pre-calculated base on population
        /// </summary>
        public override int Pollution
        {
            get
            {
                if (IsFilled())
                    return base.Pollution;
                else
                    return 0;
            }
        }
    }
}

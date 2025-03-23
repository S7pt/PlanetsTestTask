using System;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlanetarySystemFactory : PlanetarySystemFactory
{
    [SerializeField] private PlanetarySystem planetarySystem;

    public override PlanetarySystem Create(float mass, List<PlanetConfig> configs)
    {
        PlanetarySystem newPlanetarySystem = Instantiate(planetarySystem);
        newPlanetarySystem.Initialize(CalculatePlanetsData(mass,configs));
        return newPlanetarySystem;
    }

    public List<Tuple<PlanetConfig, float>> CalculatePlanetsData(float mass, List<PlanetConfig> configs) 
    {
        float remainingMass = mass;
        PlanetConfig possibleConfig = configs[configs.Count - 1];
        List<Tuple<PlanetConfig, float>> planetsData = new List<Tuple<PlanetConfig, float>>();
        while (remainingMass > 0) 
        {
            while(possibleConfig.Mass.x > remainingMass)
            {
                possibleConfig = configs[UnityEngine.Random.Range(0, configs.Count - 1)]; 
            }
            float planetMass = UnityEngine.Random.Range(possibleConfig.Mass.x, Math.Min(remainingMass, possibleConfig.Mass.y));
            remainingMass -= planetMass;
            if(remainingMass < 1E-5)
            {
                remainingMass = 0;
            }
            planetsData.Add(new Tuple<PlanetConfig, float>(possibleConfig, planetMass));
            possibleConfig = configs[UnityEngine.Random.Range(0, configs.Count - 1)];
        }
        return planetsData;
    }
}

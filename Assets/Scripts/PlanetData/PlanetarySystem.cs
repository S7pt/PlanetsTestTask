using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : MonoBehaviour
{
    [SerializeField] private PlanetaryObject planetPrefab;
    [SerializeField] private float planetRotationSpeed;
    private List<PlanetaryObject> planetaryObjects;

    public List<PlanetaryObject> PlanetaryObjects  => planetaryObjects;

    public void Initialize(List<Tuple<PlanetConfig, float>> planetsToCreate)
    {
        planetaryObjects = new List<PlanetaryObject>();
        foreach (Tuple<PlanetConfig, float> planetData in planetsToCreate)
        {
            CreatePlanet(planetData);
        }
        float mass = 0;
        foreach (PlanetaryObject planet in PlanetaryObjects)
        {
            mass += planet.Mass;
        }
        Debug.Log(mass);
    }

    private void Update()
    {
        RotatePlanets();
    }

    private void RotatePlanets()
    {
        foreach (PlanetaryObject planet in PlanetaryObjects)
        {
            planet.transform.RotateAround(transform.position, Vector3.up, planetRotationSpeed * Time.deltaTime);
        }
    }

    private void CreatePlanet(Tuple<PlanetConfig, float> planetData)
    {
        float previousPlanetRadius = 0;
        Vector3 previousPlanetPosition = transform.position;
        if (PlanetaryObjects.Count > 0)
        {
            PlanetaryObject previousPlanet = PlanetaryObjects[PlanetaryObjects.Count - 1];
            previousPlanetRadius = previousPlanet.transform.localScale.x;
            previousPlanetPosition = previousPlanet.transform.position;
        }
        float size = CalculatePlanetRadius(planetData.Item1, planetData.Item2);
        Vector3 position = CalculatePlanetPosition(size, previousPlanetRadius, Vector3.Distance(previousPlanetPosition, transform.position));
        PlanetaryObject planet = Instantiate(planetPrefab, position, Quaternion.identity, transform);
        planet.Initialize(planetData.Item1.Type, planetData.Item2, size, GeneratePlanetColor());
        PlanetaryObjects.Add(planet);
    }

    private float CalculatePlanetRadius(PlanetConfig config, float mass)
    {
        float relativeMass = Mathf.InverseLerp(config.Mass.x, config.Mass.y, mass);
        float size = Mathf.Lerp(config.Radius.x, config.Radius.y, relativeMass);
        return size;
    }

    private Vector3 CalculatePlanetPosition(float radius, float previousPlanetRadius, float furthestOrbitRadius)
    {
        float newOrbitRadius = furthestOrbitRadius + previousPlanetRadius + radius + (radius / 4) + 0.2f;
        float randomZ = (float)Math.Sin(UnityEngine.Random.Range(0, 360));
        float randomX = (float)Math.Cos(UnityEngine.Random.Range(0, 360));
        Vector3 planetPosition = new Vector3(randomX, 0 , randomZ).normalized;
        return planetPosition * newOrbitRadius;
    }

    private Color GeneratePlanetColor()
    {
        Color randomColor = UnityEngine.Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
        Color.RGBToHSV(randomColor, out float hue, out float saturation, out float volume);
        volume = 10;
        return Color.HSVToRGB(hue, saturation, volume, true);
    }
}

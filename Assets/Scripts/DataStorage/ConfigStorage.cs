using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigStorage : MonoBehaviour
{
    private const string CONFIG_PATH = "PlanetData";
    private List<PlanetConfig> planetConfigs;

    public List<PlanetConfig> PlanetConfigs => planetConfigs;

    private void Awake()
    {
        planetConfigs = Resources.LoadAll<PlanetConfig>(CONFIG_PATH).ToList();
    }
}

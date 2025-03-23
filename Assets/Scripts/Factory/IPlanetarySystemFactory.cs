using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetarySystemFactory : MonoBehaviour
{
    public abstract PlanetarySystem Create(float mass, List<PlanetConfig> configs);
}

using UnityEngine;

[CreateAssetMenu(fileName = "PlanetConfig", menuName = "ScriptableObjects/PlanetConfig", order = 1)]
public class PlanetConfig : ScriptableObject
{
    [SerializeField] private PlanetType type;
    [SerializeField] private Vector2 mass;
    [SerializeField] private Vector2 radius;

    public PlanetType Type { get => type; set => type = value; }
    public Vector2 Mass { get => mass; set => mass = value; }
    public Vector2 Radius { get => radius; set => radius = value; }
}

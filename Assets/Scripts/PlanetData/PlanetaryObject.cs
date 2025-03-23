using UnityEngine;

public class PlanetaryObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer objectRenderer;
    [SerializeField] private PlanetOrbit orbit;
    private PlanetType planetType;
    private Color planetColor;
    private float mass;
    private float radius;

    public float Mass => mass;

    public void Initialize(PlanetType type, float mass, float radius, Color color)
    {
        planetType = type;
        this.mass = mass;
        this.radius = radius;
        transform.localScale = Vector3.one * this.radius * 2;
        planetColor = color;
        SetColor(planetColor);
        orbit.GenerateOrbit(Vector3.Distance(transform.parent.position, transform.position), planetColor, transform.localScale.x);
    }

    private void SetColor(Color color)
    {
        Material planetMaterial = objectRenderer.material;
        planetMaterial.color = color;
        planetMaterial.SetColor("_EmissionColor", color * 10);
    }
}

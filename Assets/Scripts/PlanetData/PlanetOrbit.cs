using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField] private LineRenderer orbitRenderer;
    [SerializeField] private int segments = 100;

    public void GenerateOrbit(float radius, Color color, float planetSize)
    {
        orbitRenderer.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (i / (float)segments) * 2 * Mathf.PI;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            orbitRenderer.SetPosition(i, new Vector3(x, 0, z));
        }
        orbitRenderer.material.SetColor("_EmissionColor", color / 3f);
        float orbitWidth = orbitRenderer.startWidth * planetSize;
        orbitRenderer.startWidth = orbitWidth;
        orbitRenderer.endWidth = orbitWidth;
    }
}

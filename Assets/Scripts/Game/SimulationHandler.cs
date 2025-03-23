using UnityEngine;

public class SimulationHandler : MonoBehaviour
{
    [SerializeField] private ConfigStorage storage;
    [SerializeField] private PlanetarySystemFactory planetarySystemFactory;
    [SerializeField] private UIManager uiManager;
    private PlanetarySystem currentPlanetarySystem;

    private void Start()
    {
        uiManager.GenerationRequested += OnGenerationRequested;
    }

    private void OnDestroy()
    {
        uiManager.GenerationRequested -= OnGenerationRequested;
    }

    private void OnGenerationRequested(float mass)
    {
        if(currentPlanetarySystem != null)
        {
            Destroy(currentPlanetarySystem.gameObject);
        }
        currentPlanetarySystem = planetarySystemFactory.Create(mass, storage.PlanetConfigs);
    }
}

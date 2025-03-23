using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button generateButton;
    [SerializeField] private TMP_InputField massInput;

    public event Action<float> GenerationRequested;

    private void Start()
    {
        generateButton.onClick.AddListener(OnGenerateButtonClicked);
    }

    private void OnDestroy()
    {
        generateButton.onClick.RemoveListener(OnGenerateButtonClicked);
    }

    private void OnGenerateButtonClicked()
    {
        if(float.TryParse(massInput.text, out float mass))
        {
            GenerationRequested?.Invoke(mass);
        }
        else
        {
            massInput.text = string.Empty;
        }
    }
}

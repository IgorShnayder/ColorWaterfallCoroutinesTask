using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    public event Action ColorButtonPushed;
    [SerializeField] private Button _changeColorButton;
    
    private FillingManager _fillingManager;
    private ColoringManager _coloringManager;
    
    public void Initialize(FillingManager fillingManager, ColoringManager coloringManager)
    {
        _fillingManager = fillingManager;
        _coloringManager = coloringManager;

        ColorButtonPushed += _coloringManager.Coloring;
    }

    public void PushChangeColorButton()
    {
        ColorButtonPushed?.Invoke();
    }
    
    private void Awake()
    {
        StartCoroutine(_fillingManager.FillMap());
    }

    private void OnDestroy()
    {
        ColorButtonPushed -= _coloringManager.Coloring;
    }
}

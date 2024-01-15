using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private Filler _fillerPrefab;
    [SerializeField] private Map _map;
    [SerializeField] private FillingManager _fillingManager;
    [SerializeField] private ColoringManager _coloringManager;

    private void Awake()
    {
        _fillingManager.Initialize(_fillerPrefab, _map);
        _coloringManager.Initialize(_fillingManager.Fillers);
        _gameScreen.Initialize(_fillingManager, _coloringManager);
    }
}

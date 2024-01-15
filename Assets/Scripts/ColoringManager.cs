using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColoringManager : MonoBehaviour
{
    [SerializeField] private float _changeColorInterval; 
    [SerializeField] private float _changingColorTime;

    private Filler[,] _fillers;
    private Color _newColor;
    
    public void Initialize(Filler[,] fillers)
    {
        _fillers = fillers;
    }

    public void Coloring()
    {
        StartCoroutine(ColoringFillers());
    }

    private IEnumerator ColoringFillers()
    {
        var newColor = GetRandomColor();
        
        for (var x = 0; x < _fillers.GetLength(0); x++)
        {
            for (var y = 0; y < _fillers.GetLength(1); y++)
            {
                var startColor = _fillers[x, y].ColoringMaterial.color;

                StartCoroutine(ChangingColorSmoothly(x, y, startColor, newColor));
                
                yield return new WaitForSeconds(_changeColorInterval);
            }
        }
    }
    
    private Color GetRandomColor()
    {
        var color = Random.ColorHSV();
        return color;
    }

    private IEnumerator ChangingColorSmoothly(int x, int y, Color startColor, Color newColor)
    {
        var currentTime = 0f;
        
        while (currentTime < _changingColorTime)
        {
            _fillers[x, y].ColoringMaterial.color = Color.Lerp(startColor, newColor, currentTime / _changingColorTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}

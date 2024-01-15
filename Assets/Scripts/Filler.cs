using UnityEngine;

public class Filler : MonoBehaviour
{
    public Material ColoringMaterial { get; private set; }
    
    [SerializeField] private Renderer _renderer;

    private void Awake()
    {
        ColoringMaterial = ColoringHelper.FindMaterialForColoring(_renderer);
    }
}

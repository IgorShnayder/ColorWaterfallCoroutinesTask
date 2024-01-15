using UnityEngine;

public abstract class ColoringHelper
{
    public static Material FindMaterialForColoring(Renderer renderer)
    {
        var coloringMaterials = renderer.material;
        return coloringMaterials;
    }
}
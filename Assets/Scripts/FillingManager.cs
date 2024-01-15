using System.Collections;
using UnityEngine;

public class FillingManager : MonoBehaviour
{
    public Filler[,] Fillers { get; private set; }

    [SerializeField] private float _fillingInterval;
    
    private Filler _filler;
    private Map _map;

    public void Initialize(Filler filler, Map map)
    {
        _filler = filler;
        _map = map;
        Fillers = new Filler[_map.MapSize.x, _map.MapSize.y];
    }
    
    public IEnumerator FillMap()
    {
        var filler = _filler;
        
        for (var x = 0; x < Fillers.GetLength(0); x++)
        {
            for (var y = 0; y < Fillers.GetLength(1); y++)
            {
                var cellCentre = _map.Grid.GetCellCenterWorld(new Vector3Int(x, y, 0));
                var fillerInstance = Instantiate(filler, cellCentre, Quaternion.identity);
                
                Fillers[x, y] = fillerInstance;

                yield return new WaitForSeconds(_fillingInterval);
            }
        }
    }
}

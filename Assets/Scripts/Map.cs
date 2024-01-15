using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Vector2Int MapSize => _mapSize;
    public Grid Grid => _grid;
    
    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private Grid _grid;
}

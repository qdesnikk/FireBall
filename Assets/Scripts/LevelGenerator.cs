using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GridObject[] _templates;
    [SerializeField] private Player _player;
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _cellSize;

    private HashSet<Vector2Int> _collisionsMatrix = new HashSet<Vector2Int>();

    private void Update()
    {
        FillDistance(_player.transform.position, _viewDistance);
    }

    private void FillDistance(Vector2 center, float viewDistance)
    {
        var cellCountOnAxis = (int)(viewDistance / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x = -cellCountOnAxis; x < cellCountOnAxis; x++)
        {
                TryCreateOnLayer(GridLayer.Ground, fillAreaCenter + new Vector2Int(x, 0));
                TryCreateOnLayer(GridLayer.FirstFloor, fillAreaCenter + new Vector2Int(x, 0));
                TryCreateOnLayer(GridLayer.SecondFloor, fillAreaCenter + new Vector2Int(x, 0));
        }
    }

    private void TryCreateOnLayer(GridLayer layer, Vector2Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
            _collisionsMatrix.Add(gridPosition);

        var template = GetRandomTemplate(layer);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        Instantiate(template, position, Quaternion.identity, transform);
    }

    private GridObject GetRandomTemplate(GridLayer layer)
    {
        var variants = _templates.Where(template => template.Layer == layer);

        foreach (var template in variants)
        {
            if (template.Chance > Random.Range(0, 100))
            {
                return template;
            }
        }

        return null;
    }

    private Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize);
    }

    private Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize));
    }
}

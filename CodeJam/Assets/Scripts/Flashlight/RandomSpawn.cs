using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private PolygonCollider2D polyCollider;

    private void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
        InstantiateObjectInsideCollider();
    }

    public void InstantiateObjectInsideCollider()
    {
        Vector2 randomPointInsideCollider = GetRandomPointInsideCollider();
        Instantiate(objectToInstantiate, randomPointInsideCollider, Quaternion.identity);
    }

    private Vector2 GetRandomPointInsideCollider()
    {
        Bounds bounds = polyCollider.bounds;
        Vector2 randomPoint = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        while (!polyCollider.OverlapPoint(randomPoint))
        {
            randomPoint = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        }
        return randomPoint;
    }
}

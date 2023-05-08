using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private PolygonCollider2D polyCollider;

    // new
    // list to track previously instatiated objects
    private List<Vector2> spawnedPoints = new List<Vector2>();
    // to define the distnce between the instatiated objects
    [SerializeField] float minDistanceBetweenObjects = 1f;

    private void Start()
    {
        // attaches the component
        polyCollider = GetComponent<PolygonCollider2D>();

        // instantiates the object
        InstantiateObjectInsideCollider();
    }

    public void InstantiateObjectInsideCollider()
    {
        // creates a new Vector 2 by calling the method
        Vector2 randomPointInsideCollider = GetRandomPointInsideCollider();

        // instantiates the object at a random point
        Instantiate(objectToInstantiate, randomPointInsideCollider, Quaternion.identity);
    }

    private Vector2 GetRandomPointInsideCollider()
    {
        // gets the bounds of the polygon collider 
        Bounds bounds = polyCollider.bounds;

        // random point is generated inside the bounds of the polygon collider
        Vector2 randomPoint = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));

        // new
        // checks if the point is inside the collider or too close to the other objects and generates a new if it is not
        while (!polyCollider.OverlapPoint(randomPoint) || IsTooCloseToOtherObject(randomPoint))
        {
            randomPoint = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        }

        // new
        // when a random point is found it is added to the list and returned
        spawnedPoints.Add(randomPoint);

        return randomPoint;
    }

    //new
    private bool IsTooCloseToOtherObject(Vector2 point)
    {
        // goes through the list and calculates the distance between the points
        foreach (Vector2 spawnedPoint in spawnedPoints)
        {
            // returns true if the distance is less than the minimum, meaning that the point is too close
            if (Vector2.Distance(point, spawnedPoint) < minDistanceBetweenObjects)
            {
                // continues to generate a new point
                return true;
            }
        }
        // when the random point is considered valid
        return false;
    }
}

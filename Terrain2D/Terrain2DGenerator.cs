using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Terrain2DGenerator : MonoBehaviour {

    EdgeCollider2D edgeCollider2D;
    List<Vector2> terrainList;
    public Vector2 next_Point;
    public int number_Of_Point;
    
	void Start () {
        terrainList = new List<Vector2>();
        edgeCollider2D = (EdgeCollider2D)this.GetComponent<EdgeCollider2D>().collider2D;

        // Added first two point into the array.
        terrainList.Add(new Vector2(1,1));
        this.AddNextPoint(new Vector2(2,0), 10);
        edgeCollider2D.points = terrainList.ToArray();
	}
	
	void Update () {
	}

    // Use this to add next point
    public void AddNextPoint(Vector2 nextPoint, int numberOfPoint)
    {
        if (nextPoint != null)
        {
            // Getting last point from the array
            Vector2 lastPoint = terrainList[terrainList.Count - 1];

            // Make sure the last point and different compare to next point
            if (nextPoint != lastPoint)
            {
                // Get the distance between x
                float distance = nextPoint.x - lastPoint.x;

                // In case distance is negative value
                if (distance < 0)
                {
                    distance = -distance;
                }

                distance = distance / numberOfPoint;

                for (int i = 1; i < numberOfPoint; i++)
                {
                    float cosInterpolateX = (float)i / numberOfPoint;
                    float cosInterpolateY = CosineInterpolate(lastPoint.y, nextPoint.y, cosInterpolateX);
                    cosInterpolateX = lastPoint.x + (distance * i);
                    terrainList.Add(new Vector2(cosInterpolateX, cosInterpolateY));
                    Debug.Log("Point " + i + ":{x: " + cosInterpolateX + ", y:" + cosInterpolateY + "}");
                }
                terrainList.Add(nextPoint);
                edgeCollider2D.points = terrainList.ToArray();
                Debug.Log("Point Added");
            }
        }
    }

    // Math function that required when converting a straight line to curve line
    // http://paulbourke.net/miscellaneous/interpolation/
    private float CosineInterpolate(float y1, float y2, float mu)
    {
        float mu2;

        mu2 = (1 - Mathf.Cos(mu * Mathf.PI)) / 2;
        return (y1 * (1 - mu2) + y2 * mu2);
    }
}

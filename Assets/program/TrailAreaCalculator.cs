using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAreaCalculator : MonoBehaviour
{
    public TrailRenderer trailRenderer;

    void Start()
    {
        if (trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }
    }

    void Update()
    {
        float totalArea = CalculateTrailArea();
        Debug.Log("Total Trail Area: " + totalArea);
    }

    float CalculateTrailArea()
    {
        Vector3[] positions = new Vector3[trailRenderer.positionCount];
        trailRenderer.GetPositions(positions);

        float totalArea = 0f;

        for (int i = 0; i < positions.Length - 1; i++)
        {
            Vector3 point1 = positions[i];
            Vector3 point2 = positions[i + 1];

            // 2D plane上の長方形の面積を計算 (幅を trailRenderer.startWidth と仮定)
            float segmentLength = Vector3.Distance(point1, point2);
            float segmentArea = segmentLength * trailRenderer.startWidth;

            totalArea += segmentArea;
        }

        return totalArea;
    }
}
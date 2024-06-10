using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
    private Vector3 previousPosition;
    private float totalDistance;

    void Start()
    {
        // 初期位置を記録
        previousPosition = transform.position;
        totalDistance = 0f;
    }

    void Update()
    {
        // 現在位置を取得
        Vector3 currentPosition = transform.position;

        // 前回の位置と現在の位置の距離を計算
        float distanceThisFrame = Vector3.Distance(previousPosition, currentPosition);

        // 合計距離に追加
        totalDistance += distanceThisFrame;

        // 前回の位置を更新
        previousPosition = currentPosition;

        // コンソールに合計距離を出力
        Debug.Log("Total Distance: " + totalDistance.ToString("F2") + " units");
    }

    // 合計距離を取得するためのメソッド
    public float GetTotalDistance()
    {
        return totalDistance;
    }
}

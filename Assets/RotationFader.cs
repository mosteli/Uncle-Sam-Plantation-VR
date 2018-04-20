using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RotationFader : MonoBehaviour
{

    [SerializeField]
    private float startRotation;

    [SerializeField]
    private float endRotation;

    [SerializeField]
    private GameObject[] gameObjects;

    private float[] fadeThresholds;
    private int nextThreshold;

    private void Start()
    {
        float rotSize = endRotation - startRotation;
        fadeThresholds = new float[gameObjects.Length];
        float step = rotSize / (gameObjects.Length + 1);
        for (int i = 0; i < fadeThresholds.Length; i++)
        {
            fadeThresholds[i] = step * (i + 1);
            gameObjects[i].SetActive(false);
        }
        nextThreshold = 0;
    }

    private void Update()
    {
        for (int i = 0; i < fadeThresholds.Length; i++)
        {
            if (transform.eulerAngles.y >= fadeThresholds[i]) {
                gameObjects[i].SetActive(true);
            } else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

}

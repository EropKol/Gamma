using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    public RectTransform TextObject;

    public float TextSpeed;
    public float RotationSpeed;
    public float Height;

    private void Update()
    {
        TextObject.position += Vector3.up * TextSpeed * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(0, RotationSpeed * Time.deltaTime, 0);

        if (TextObject.position.y >= Height)
        {
            SceneManager.LoadScene("GameplayScene");
            SceneManager.UnloadSceneAsync("Intro");
        }
    }
}

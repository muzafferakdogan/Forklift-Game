using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionControl : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");  
    }
}

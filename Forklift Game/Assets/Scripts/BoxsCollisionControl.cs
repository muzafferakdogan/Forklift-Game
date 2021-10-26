using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxsCollisionControl : MonoBehaviour
{
    private CollisionControl _collisionControl;


    void Start()
    {
        _collisionControl = GetComponent<CollisionControl>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {

            Debug.Log("sa");
            SceneManager.LoadScene("SampleScene");
        }

    }
}

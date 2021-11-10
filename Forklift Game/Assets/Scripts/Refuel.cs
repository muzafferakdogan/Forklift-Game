using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Refuel : MonoBehaviour
{
    private ForkliftControl _forkliftControl;

    public int maxAmounth = 100;
    public int currentAmounth = 60;

    [SerializeField] private GasBarScrip _gasBarScript;

    void Start()
    {
        _forkliftControl = GetComponent<ForkliftControl>();

        _gasBarScript.SetMaxFuel(maxAmounth);
        _gasBarScript.SetFuel(currentAmounth);
        
        InvokeRepeating(nameof(ConsumeFuel), 5f, 5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Petrol")
        {
            TakeFuel(20);
        }
    }

    private void TakeFuel(int fuel)
    {
        currentAmounth += fuel;
        _gasBarScript.SetFuel(currentAmounth);
    }

    private void ConsumeFuel()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || _forkliftControl.pressGas || _forkliftControl.pressBackGas)
        {
            currentAmounth -= 3;
            _gasBarScript.SetFuel(currentAmounth);

            if (currentAmounth <= 0)
            {
                RestartGame();
            }
        } 
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

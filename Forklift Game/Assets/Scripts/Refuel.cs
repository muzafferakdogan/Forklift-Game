using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuel : MonoBehaviour
{
    public int maxAmounth = 100;
    public int currentAmounth ;

    public GasBarScrip gasBarScript;

    void Start()
    {
        
        gasBarScript.SetMaxGas(maxAmounth);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        /**Debug.Log("çarptý");
        TakeGas(20);**/
        if (collision.gameObject.name == "Petrol")
        {
            TakeGas(20);
        }
    }

    private void TakeGas(int gas)
    {
        currentAmounth += gas;
        gasBarScript.SetGas(currentAmounth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftPallet : MonoBehaviour
{
    private bool up;
    private bool down;

    [SerializeField] private float liftPower;

    [SerializeField] private GameObject pallet;

    [SerializeField] private Transform palletTransform;
    
    [SerializeField] private Vector3 maxY;
    [SerializeField] private Vector3 minY;

    void Start()
    {
        
    }

    void Update()
    {
        getUserPalletInput();
        mooveThePallet();
    }

    void getUserPalletInput()
    {
        up = Input.GetKey(KeyCode.Y);
        down = Input.GetKey(KeyCode.H);
    }

    void mooveThePallet()
    {
        if (up)
        {
            palletTransform.transform.localPosition = Vector3.MoveTowards(palletTransform.localPosition, maxY, liftPower);
        }

        else if (down)
        {
            palletTransform.transform.localPosition = Vector3.MoveTowards(palletTransform.localPosition, minY, liftPower);
        }       
    }


}

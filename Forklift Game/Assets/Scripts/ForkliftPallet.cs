using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftPallet : MonoBehaviour
{
    private bool up;
    private bool down;

    public bool pressUp;
    public bool pressDown;

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
        GetUserPalletInput();
        MooveThePallet();
    }

    private void GetUserPalletInput()
    {
        up = Input.GetKey(KeyCode.Y);
        down = Input.GetKey(KeyCode.H);
    }

    private void MooveThePallet()
    {
        if (up || pressUp)
        {
            palletTransform.transform.localPosition = Vector3.MoveTowards(palletTransform.localPosition, maxY, liftPower);
        }

        else if (down || pressDown)
        {
            palletTransform.transform.localPosition = Vector3.MoveTowards(palletTransform.localPosition, minY, liftPower);
        }       
    }

    public void PalletMoveTheUp_Down()
    {
        pressUp = true;
    }

    public void PalletMoveTheUp_Exit()
    {
        pressUp = false;
    }

    public void PalletMoveTheDown_Down()
    {
        pressDown = true;
    }

    public void PalletMoveTheDown_Exit()
    {
        pressDown = false;
    }


}

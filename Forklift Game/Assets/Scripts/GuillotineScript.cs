using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotineScript : MonoBehaviour
{
    [SerializeField] private float guillotineSpeed;


    [SerializeField] private Transform guillotine1Transform;
    [SerializeField] private Transform guillotine2Transform;
    [SerializeField] private Transform guillotine3Transform;

    [SerializeField] private Vector3 minYGuillotine1;
    [SerializeField] private Vector3 minYGuillotine2;
    [SerializeField] private Vector3 minYGuillotine3;

    private float distance1;
    private float distance2;
    private float distance3;

    private GuillotineCreateScript _guillotineCreateScript;



    void Start()
    {
        
    }
    
    void Update()
    {
        Guillotine1Distance();
        Guillotine2Distance();
        Guillotine3Distance();
    }

    void MooveTheGuillotine()
    {
        transform.position += transform.up * -1 * guillotineSpeed * Time.deltaTime;
    }


    void DieGuillotine()
    {
        Destroy(gameObject);
    }

    void Guillotine1Distance()
    {
        distance1 = Vector3.Distance(guillotine1Transform.position, minYGuillotine1);
        
        if (distance1 > 0.6f)
        {
            MooveTheGuillotine();
        }

        else
        {
            DieGuillotine();
            CreatGuillotine1();
        }
    }

    void Guillotine2Distance()
    {
        distance2 = Vector3.Distance(guillotine2Transform.position, minYGuillotine2);

        if (distance2 > 0.6f)
        {
            MooveTheGuillotine();
        }

        else
        {
            DieGuillotine();
            CreatGuillotine2();
        }
    }

    void Guillotine3Distance()
    {
        distance3 = Vector3.Distance(guillotine3Transform.position, minYGuillotine3);

        if (distance3 > 0.6f)
        {
            MooveTheGuillotine();
        }

        else
        {
            DieGuillotine();
            CreatGuillotine3();
        }
    }

    void CreatGuillotine1()
    {
        _guillotineCreateScript.CreatGuillotine1();
    }

    void CreatGuillotine2()
    {
        _guillotineCreateScript.CreatGuillotine2();
    }

    void CreatGuillotine3()
    {
        _guillotineCreateScript.CreatGuillotine3();
    }

}

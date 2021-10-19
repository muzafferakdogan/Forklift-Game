using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotineCreateScript : MonoBehaviour
{
    [SerializeField] private Transform guillotine1Point;
    [SerializeField] private Transform guillotine2Point;
    [SerializeField] private Transform guillotine3Point;

    [SerializeField] private GameObject guillotinePrefab;


    void Start()
    {
        CreatGuillotine1();
        CreatGuillotine2();
        CreatGuillotine3();
    }


    void Update()
    {
  
    }

    public void CreatGuillotine1()
    {
        Instantiate(guillotinePrefab, guillotine1Point.position, guillotine1Point.rotation);      
    }

    public void CreatGuillotine2()
    {
        Instantiate(guillotinePrefab, guillotine2Point.position, guillotine2Point.rotation);
    }

    public void CreatGuillotine3()
    {
        Instantiate(guillotinePrefab, guillotine3Point.position, guillotine3Point.rotation);
    }
}

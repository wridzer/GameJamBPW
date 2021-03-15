using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public float infantTime = 3;
    public float childTime = 6;
    public float adultTime = 9;
    public float seniorTime = 12;

    public float timePassed;
    public bool infant;
    public bool child;
    public bool adult;
    public bool senior;

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed < infantTime)
        {
            
            infant = true;
            child = false;
            adult = false;
            senior = false;
        }
        else if (timePassed > infantTime && timePassed < childTime)
        {
            Debug.Log(timePassed);
            infant = false;
            child = true;
            adult = false;
            senior = false;
        }
        else if (timePassed > childTime && timePassed < adultTime)
        {
            
            infant = false;
            child = false;
            adult = true;
            senior = false;
        }
        else if (timePassed > seniorTime)
        {
            
            infant = false;
            child = false;
            adult = false;
            senior = true;
        }
    }

    private void Start()
    {
        
    }

    public void Awake()
    {
        Instance = this;
    }
}


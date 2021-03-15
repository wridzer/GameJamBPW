using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeState : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private bool baby, kid, adult, boomer;


    private void Start()
    {
        baby = true;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 25)
        {
            baby = true;
            kid = false;
            adult = false;
            boomer = false;
        }
        if (timer > 25 && timer < 50)
        {
            baby = false;
            kid = true;
            adult = false;
            boomer = false;
        }
        if (timer > 50 && timer < 75)
        {
            baby = false;
            kid = false;
            adult = true;
            boomer = false;
        }
        if (timer > 75)
        {
            baby = false;
            kid = false;
            adult = false;
            boomer = true;
        }
    }
}

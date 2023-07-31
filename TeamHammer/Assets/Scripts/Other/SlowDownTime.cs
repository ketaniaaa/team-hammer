using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{

    [SerializeField] float slowDownDuratione=0;
    [SerializeField] float slowDownPercentage=1;


    public void SlowTime()
    {
       Slow(slowDownDuratione, slowDownPercentage);
    }


    IEnumerator Slow(float slowDownDuratione, float slowDownPercentage)
    {
        Time.timeScale = slowDownPercentage;
        yield return new WaitForSeconds(slowDownDuratione);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

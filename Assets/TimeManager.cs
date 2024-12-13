using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    
    public static TimeManager instance;
    public uint time_stamp = 0;
   

    public UnityEvent TimeProgressed = new UnityEvent(); 
    
    void Start()
    {
       if (instance == null)
        {
            instance = this;
            StartCoroutine(TimeStep());

        }
        else
        {
            Destroy(this);
        }
        

    }

    IEnumerator TimeStep()
    {
        time_stamp++;
        yield return new WaitForSeconds(1);
        //Debug.Log("current time stamp : " + time_stamp);
    }


}

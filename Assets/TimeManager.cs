using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    public static TimeManager instance;
    public uint time_stamp =0;
    
    void Start()
    {
       if (instance == null)
        {
            instance = this;
            StartCoroutine(nameof(TimeStep));

        }
        else
        {
            Destroy(this);
        }
        

    }

    void TimeStep()
    {
        time_stamp++;
        //Debug.Log("current time stamp : " + time_stamp);
    }


}

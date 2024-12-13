using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class timer : MonoBehaviour
{
    [SerializeField] private float durationOfGame = 120;
    [SerializeField] private TextMeshProUGUI text;

    public static UnityEvent Timeout = new UnityEvent(); 

    void Start()
    {
        StartCoroutine(TimeStep());
    }

    IEnumerator TimeStep()
    {
        Debug.Log("Time Step");
        while(durationOfGame>0)
        {
            durationOfGame-=1;
            text.text = "Time Left: " + durationOfGame.ToString();
            yield return new WaitForSeconds(1);
        }
        Timeout.Invoke();
        //Debug.Log("current time stamp : " + time_stamp);
    }
}

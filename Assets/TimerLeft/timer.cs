using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class timer : MonoBehaviour
{
    [SerializeField] private float durationOfGame = 120;
    [SerializeField] private TextMeshProUGUI text;

    void SetText()
    {
        text.text = "Time Left: " + durationOfGame.ToString();
    }

    IEnumerator TimeStep()
    {
        durationOfGame-=1;
        yield return new WaitForSeconds(1);
        //Debug.Log("current time stamp : " + time_stamp);
    }
}

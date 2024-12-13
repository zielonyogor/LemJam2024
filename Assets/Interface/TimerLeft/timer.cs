using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class timer : MonoBehaviour
{
    [SerializeField] private float durationOfGame = 120;

    [SerializeField] private TextMeshProUGUI text;

    public static UnityEvent Timeout = new UnityEvent();
    private bool TimerOn = true;

    void Start()
    {
        MenuPause.PauseOn.AddListener(() => { StopTimer(true); });
        MenuPause.PauseOff.AddListener(() => { StopTimer(false); });
    }

    void StopTimer(bool stop)
    {
        TimerOn = !stop;
    }

    void Update()
    {
        if (durationOfGame > 0)
        {
            if (TimerOn)
            {
                durationOfGame -= Time.deltaTime;
                text.text = Mathf.Ceil(durationOfGame).ToString();
            }
            return;
        }
        Timeout.Invoke();
        durationOfGame = 0;
    }
}

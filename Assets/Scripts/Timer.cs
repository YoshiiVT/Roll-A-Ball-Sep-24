
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    private bool isTiming = true;
    public bool paused = false;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        if(isTiming && !paused)
        {
            currentTime += Time.deltaTime;
           //playerScript.timerText.text = currentTime.ToString("F3");
        }
        if (isTiming == true)
        currentTime += Time.deltaTime;
    }
    public float GetTime()
    {
        return currentTime;
    }
    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTimer()
    {
        ChangeTimeScale(1);
        paused = false;
        //isTiming= false;
    }

    public void PauseTimer(bool _paused)
    {
        paused = _paused;
    }

    public void ChangeTimeScale(float _timeScale)
    {
        Time.timeScale = _timeScale;
    }
}

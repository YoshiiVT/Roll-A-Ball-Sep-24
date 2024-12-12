using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //An enum is a datatype that we can specify its values and use
    public enum PowerupType {SpeedUp, SpeedDown, Grow, Shrink, SlowMo, FastFo}

    public PowerupType myPowerup;
    public float powerupDuration = 7f;
    PlayerController playerController;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        timer = FindObjectOfType<Timer>();
    }

   
    public void UsePowerup()
    {
        if (myPowerup == PowerupType.SpeedUp)
            playerController.Speed = playerController.baseSpeed * 2;

        if (myPowerup == PowerupType.SpeedDown)
            playerController.Speed = playerController.baseSpeed / 3;

        if (myPowerup == PowerupType.Grow)
        {
            Vector3 temp = playerController.gameObject.transform.position;
            temp.y += 1;
            playerController.gameObject.transform.position = temp;
            playerController.gameObject.transform.localScale = Vector3.one * 2;
        }

        if (myPowerup == PowerupType.Shrink)
            playerController.gameObject.transform.localScale = Vector3.one / 2;

        if (myPowerup == PowerupType.SlowMo)
            timer.ChangeTimeScale(0.4f);

        if (myPowerup == PowerupType.FastFo)
            timer.ChangeTimeScale(1.4f);

        StartCoroutine(ResetPowerup() );
    }

    IEnumerator ResetPowerup()
    {
        yield return new WaitForSeconds(powerupDuration);

        if(myPowerup == PowerupType.SpeedUp || myPowerup == PowerupType.SpeedDown)
            playerController.Speed = playerController.baseSpeed;

        if (myPowerup == PowerupType.Grow ||  myPowerup == PowerupType.Shrink)
        {
            playerController.gameObject.transform.localScale = Vector3.one;
        }

        if (myPowerup == PowerupType.SlowMo || myPowerup == PowerupType.FastFo)
            timer.ChangeTimeScale(1);
    }
}

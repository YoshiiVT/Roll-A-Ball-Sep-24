using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public float waitTime = 1;
    public float movespeed = 5;
    public Transform[] moveToPositions;
    private int currentPostition = 0;

    PlayerController playerController;

    private void Start()
    {
        StartCoroutine(MoveInDirection());
        playerController = FindObjectOfType<PlayerController>();
    }

    IEnumerator MoveInDirection() 
    {
        Vector3 _newPos = moveToPositions[currentPostition].position;
        while (Vector3.Distance(transform.position, _newPos) > 0.1f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, _newPos, movespeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);

        if (currentPostition != moveToPositions.Length -1)
            currentPostition = currentPostition + 1;
        else
            currentPostition = 0;
        StartCoroutine(MoveInDirection());
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
}

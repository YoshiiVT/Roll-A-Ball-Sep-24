using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // We want the camera to follow the position of the ball without changing rotational value

    public GameObject player;
    // This is called a Variable Reference ^^^
    private Vector3 offset; 

    void Start()
    {
        //Set the offset of the camera based on the players position
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        
        //Make the transform position of the camera follow the players transform position
        transform.position = player.transform.position + offset;
    }
}

// Logic -> PsudoCode -> Syntax
// To fix visual at home, go in unity > Edit > Preferences > External Script Editor > Visual Studio
// . = Dot Notation. It is used to tell the program to go further into a file or tool
// When linking camera to player or movable object, the distance in positions is called an Offset
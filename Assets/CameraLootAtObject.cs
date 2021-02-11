using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLootAtObject : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] int cameraHeight = 10;
    [SerializeField] int cameraZOffset = 10;

    // Update is called once per frame
    void Update()
    {
        if (obj)
        {
            // follow its position the position of the player.
            transform.position = new Vector3(obj.transform.position.x, cameraHeight, obj.transform.position.z - cameraZOffset);
        }
        else
        {
            // print a message to the screen to make sure obj is not null
            if (!obj) { Debug.LogWarning("Please attach the object to be followed by this camera in the editor"); }
        }

    }

    
}

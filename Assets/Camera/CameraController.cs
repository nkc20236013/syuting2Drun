using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    GameObject playerObjct;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerObjct = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObjct.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + 5, playerTransform.position.y + 4, transform.position.z);
    }
}
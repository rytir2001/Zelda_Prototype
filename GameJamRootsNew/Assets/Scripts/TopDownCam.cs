using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCam : MonoBehaviour
{

    private void Update()
    {
        transform.position = new Vector3(FindObjectOfType<Player>().transform.position.x, transform.position.y, FindObjectOfType<Player>().transform.position.z);
    }

}

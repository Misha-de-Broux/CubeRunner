using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject followed;
    public int distanceToFollow = 5;
    public float speed = 10;

    private void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(followed.transform.position.z >= transform.position.z + distanceToFollow)
            transform.Translate(0, 0, Mathf.Min(followed.transform.position.z - transform.position.z - distanceToFollow, speed * Time.deltaTime), Space.World);
        else
            transform.Translate(0, 0, Mathf.Max(followed.transform.position.z - transform.position.z - distanceToFollow, -speed * Time.deltaTime), Space.World);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin (Time.time), transform.position.z);
        transform.Rotate(0, 50 * Time.deltaTime, 50 * Time.deltaTime);
    }
}

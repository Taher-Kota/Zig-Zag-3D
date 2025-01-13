using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformFall : MonoBehaviour
{
    public static PlatformFall instance;
 
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("Fall", .7f);
        }
    }

    public void Fall()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
    }
}

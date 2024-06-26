using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        float rotAmount = 480f * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}

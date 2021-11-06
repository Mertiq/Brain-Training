using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsWaterInteraction : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Iron")
        {
            IncreaseWater(2.0f);
            Debug.Log("It is iron");
        }
        else if(col.tag == "Wood")
        {
            col.GetComponent<Rigidbody>().velocity = Vector3.zero;
            col.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void IncreaseWater(float increaseAmount)
    {
        Vector3 currentScale = new Vector3(this.transform.localScale.x,this.transform.localScale.y + increaseAmount,this.transform.localScale.z);
        this.transform.localScale = currentScale;
    }
}

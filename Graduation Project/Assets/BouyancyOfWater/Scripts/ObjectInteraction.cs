using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
namespace BouyancyOfWater
{
    public class ObjectInteraction : MonoBehaviour
    {
       public float woodIronInteractionForce = 0.00001f;
       public float ironWoodInteractionForce = 0.07f;
       public float waterInteractionForce = 0.07f;
       public float ironWaterincreaseAmount = 0.3f;

       private Vector2 woodPushingIronDirection;    
       public bool enteredWater = false;
       
        void OnCollisionEnter2D(Collision2D col)
        {

            if(this.transform.tag == "Wood" && col.transform.tag =="Iron")
            {
                if(woodPushingIronDirection == (Vector2.zero))
                {
                    woodPushingIronDirection = RandomUtilities.OneOfTwo<Vector2>(Vector2.left,Vector2.right);
                }
                
            }
            else if(this.transform.tag == "Wood" && col.transform.tag == "Water" && !enteredWater)
            {
                TransformUtilities.ScaleTransformInOneDirection(col.transform,waterInteractionForce,Vector3.up);
                enteredWater = false;
            }
            else if(this.transform.tag == "Iron" && col.transform.tag == "Wood")
            {
                col.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ironWoodInteractionForce);
            }
            else if(this.transform.tag == "Iron" && col.transform.tag == "Water Ground" && !enteredWater)
            {
                enteredWater = true;
                TransformUtilities.ScaleTransformInOneDirection(GameObject.Find("Water").transform,ironWaterincreaseAmount,Vector3.up);
            }
        }
        void OnCollisionStay2D(Collision2D col)
        {
            if(this.transform.tag == "Wood" && col.transform.tag =="Iron")
            {
                if(woodPushingIronDirection == Vector2.zero)
                {
                    woodPushingIronDirection = RandomUtilities.OneOfTwo<Vector2>(Vector2.left,Vector2.right);
                }
                col.transform.GetComponent<Rigidbody2D>().AddForce(woodPushingIronDirection * woodIronInteractionForce);
            }
           
        }
    }
}

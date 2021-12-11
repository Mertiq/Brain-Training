using UnityEngine;


namespace BouyancyOfWater
{

    public static class TransformUtilities
    {

        //if you want to scale a gameobject in one direction, use this by sending its transform, direction and scale Amount
        public static void ScaleTransformInOneDirection(Transform transform,float amount, Vector3 direction)
        {
            transform.position += direction * amount / 2; // Move the object in the direction of scaling, so that the corner on ther side stays in place
            transform.localScale += direction * amount; // Scale object in the specified direction
        }

    }

}
using UnityEngine;
using System.Collections.Generic;

namespace Utilities
{

    public static class RandomUtilities
    {

        //if you want to pick one of 2 object randomly, use this. Give two objects then take chosen one
        public static T OneOfTwo<T>(T object1, T object2)
        {
            return ( Random.Range(0,2) == 0 ) ? object1 : object2;
        }

        //if you want to pick one item randomly from an array, use this. Give an array then take the randomly chosen item.
        public static T OneOfAll<T>(T[] objects)
        {
            return objects[Random.Range(0,objects.Length)];
        }
    }
}


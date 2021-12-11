using UnityEngine;
using System.Collections.Generic;

namespace BouyancyOfWater
{

    public static class RandomUtilities
    {

        //if you want to pick one of 2 object randomly, use this

    public static T OneOfTwo<T>(T object1, T object2)
    {
        return ( Random.Range(0,2) == 0 ) ? object1 : object2;
    }

    }

}
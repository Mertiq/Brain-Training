using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BouyancyOfWater
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Bouyancy Of Water Spawn Manager")]
        
        public GameObject wood;

        public GameObject iron;

        public Transform spawnPoint;

        public int spawnLimit = 3;
        
        public Text spawnLimitTxt;

        public GameObject woodButton;
        public GameObject ironButton;

        public void SpawnObject(string objectType)
        {
            if(spawnLimit <= 1)
            {
                woodButton.SetActive(false);
                ironButton.SetActive(false);
            }
            if(objectType == "Wood")
            {
                Instantiate(wood,spawnPoint.position,Quaternion.identity);
                spawnLimit--;
            }
            else if(objectType == "Iron")
            {
                Instantiate(iron,spawnPoint.position,Quaternion.identity);
                spawnLimit--;
            }
            spawnLimitTxt.text = "x"+spawnLimit;
        }
    }

}
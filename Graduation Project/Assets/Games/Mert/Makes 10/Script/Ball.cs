using UnityEngine;

namespace Makes_10.Script
{
    public class Ball : MonoBehaviour
    {
        public int number;

        public GameObject glowCircle;
        
        public void GlowCirleSetActive(bool active)
        {
            glowCircle.SetActive(active);
        }
    }
}    



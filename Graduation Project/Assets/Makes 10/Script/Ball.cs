using UnityEngine;

namespace Makes10
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



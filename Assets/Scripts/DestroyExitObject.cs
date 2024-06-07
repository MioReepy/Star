using UnityEngine;

namespace AsteroidSpace
{
    public class DestroyExitObject : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Asteroid")
            {
                AsteroidGenerator.ReturnAsteroidToPool(other.gameObject);
            }
        }
    }
}

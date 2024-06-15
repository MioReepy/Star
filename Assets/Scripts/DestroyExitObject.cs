using UnityEngine;

namespace GeneratorSpace
{
    public class DestroyExitObject : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Enemy")
            {
                Generator.ReturnAsteroidOrEnemyToPool(other.gameObject);
            }
        }
    }
}

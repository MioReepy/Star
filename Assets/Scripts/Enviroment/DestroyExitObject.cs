using WeaponSpace;
using UnityEngine;

namespace InviromentSpace
{
    public class DestroyExitObject : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Enemy")
            {
                Generator.ReturnAsteroidOrEnemyToPool(other.gameObject);
            }

            if (other.gameObject.tag == "PlayerBolt")
            {
                Bolt.ReturnBoltToPool(other.gameObject);
            }
            
            if (other.gameObject.tag == "EnemyBolt")
            {
                EnemyWeapon.ReturnBoltToPool(other.gameObject);
            }
        }
    }
}

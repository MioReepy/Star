using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplotion;

    public delegate void Kill();
    public static event Kill OnKill;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        GameObject explosion;
        
        if (_explosion != null && (other.tag == "Asteroid" || other.tag == "Enemy"))
        {
            explosion = Instantiate(_explosion, transform.position, transform.rotation);
            Generator.ReturnAsteroidOrEnemyToPool(other.gameObject);
            Destroy(explosion);
        }
        
        if (other.tag == "Player")
        {
            explosion = Instantiate(_playerExplotion, other.transform.position, other.transform.rotation);
            OnKill?.Invoke();
            Destroy(explosion);
        }
    }
}

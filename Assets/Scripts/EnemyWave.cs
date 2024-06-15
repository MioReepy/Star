using System;
using System.Collections;
using UnityEngine;
using BoundarySpace;
using Random = UnityEngine.Random;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private AsteroidBoundary _boundary;
    [SerializeField] private float _tilt;

    [SerializeField] private float _dodge;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector2 _starWait;
    [SerializeField] private Vector2 _waveTimer;
    [SerializeField] private Vector2 _waveWait;
    [SerializeField] private float _speedMin;
    [SerializeField] private float _speedMax;
    
    private float _currentSpeed;
    private float _tagetWave;

    private void Start()
    {
        _smoothing = (int)Random.Range(_speedMin, _speedMax);
        GetComponent<Rigidbody>().velocity = transform.forward * -_smoothing;
        _currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(_starWait.x, _starWait.y));
        
        while (true)
        {
            _tagetWave = Random.Range(1, _dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(_waveTimer.x, _waveTimer.y));
            _tagetWave = 0;
            yield return new WaitForSeconds(Random.Range(_waveWait.x, _waveWait.y));
        }
    }

    private void FixedUpdate()
    {
        float newManeuver =
            Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, _tagetWave, _smoothing * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0f, _currentSpeed);
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, _boundary._xMin, _boundary._xMax),
            0f,
            gameObject.transform.position.z
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 180f, GetComponent<Rigidbody>().velocity.x * -_tilt);
    }
}

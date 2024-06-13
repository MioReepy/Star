using System;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    
    private float _titleSizeY;
    private Vector3 _startPosition;

    private void Start()
    {
        _titleSizeY = transform.localScale.y;
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * -_scrollSpeed, _titleSizeY);
        transform.position = _startPosition + Vector3.forward * newPosition;
    }
}

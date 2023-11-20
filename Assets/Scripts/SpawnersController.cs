using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Vector2 _targetPosition;

    private Transform[] _spawners;
    private float _currentTime;

    private void Start()
    {
        _template.GetTargetPosition(_targetPosition);
        _spawners = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _spawners[i] = gameObject.transform.GetChild(i);
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _spawnTime)
        {
            _currentTime = 0;
            Transform currentSpawner = _spawners[Random.Range(0, _spawners.Length)];
            var createdEnemy = Instantiate(_template, currentSpawner);
        }
    }
}

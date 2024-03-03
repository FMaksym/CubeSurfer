using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private int _totalRoadsToSpawn = 20;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _roadParent;
    [SerializeField] private List<GameObject> _roadPrefabs;
    
    private int _maxAmountActiveRoads = 4; 
    private float _roadOffset = 30f;
    public List<GameObject> _activeRoads = new List<GameObject>();
    public List<GameObject> _inactiveRoads = new List<GameObject>();

    private void Awake()
    {
        GameObject startRoad = Instantiate(_roadPrefabs[0], _spawnPoint.position, Quaternion.identity, _roadParent);
        startRoad.SetActive(true);
        _activeRoads.Add(startRoad);

        // Инициализация остальных префабов дороги
        for (int i = 1; i < _roadPrefabs.Count; i++)
        {
            GameObject roadPrefab = Instantiate(_roadPrefabs[i], _spawnPoint.position, Quaternion.identity, _roadParent);
            roadPrefab.SetActive(false);
            _inactiveRoads.Add(roadPrefab); // Добавляем в список неактивных кусков дороги
        }

        // Активация остальных кусков дороги
        for (int i = 0; i < Mathf.Min(_maxAmountActiveRoads - 1, _totalRoadsToSpawn - 1); i++)
        {
            ActivateRandomRoad(); // Активируем случайные куски дороги
        }
    }

    private void ActivateRandomRoad()
    {
        if (_inactiveRoads.Count > 0)
        {
            // Генерируем случайный индекс в диапазоне от 0 до количества неактивных дорог - 1
            int randomIndex = Random.Range(0, _inactiveRoads.Count);

            // Извлекаем дорогу из очереди по сгенерированному индексу
            GameObject road = _inactiveRoads[randomIndex];
            _inactiveRoads.RemoveAt(randomIndex);

            float lastRoadZPosition = (_activeRoads.Count > 0) ? _activeRoads[_activeRoads.Count - 1].transform.position.z : _spawnPoint.position.z;
            float newRoadZPosition = lastRoadZPosition + _roadOffset;

            road.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, newRoadZPosition);
            road.SetActive(true);
            _activeRoads.Add(road);
        }
    }

    public void DeactivateRoad(GameObject road)
    {
        road.SetActive(false);
        _activeRoads.Remove(road);
        _inactiveRoads.Add(road); // Добавляем дорогу в очередь неактивных дорог
        ActivateRandomRoad();
    }
}
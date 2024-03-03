using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TowerCubePool : MonoBehaviour
{
    [SerializeField] private int _poolSize = 15;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubesParent;

    public List<GameObject> _cubePool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity , _cubesParent);
            cube.SetActive(false);
            _cubePool.Add(cube);
        }
    }

    public void AddCubeInTower(Transform newParent, List<GameObject> towerCubesList, Transform newPosition)
    {
        if (_cubePool.Count > 0)
        {
            GameObject cube = _cubePool[0];
            _cubePool.Remove(cube);
            cube.transform.parent = newParent;
            cube.transform.position = newPosition.position;
            towerCubesList.Add(cube);
            cube.SetActive(true);
        }
    }

    public void GetCubeFromTower(GameObject cube)
    {
        cube.transform.parent = null;
        Return—ubeInPool(cube);
    }

    private async void Return—ubeInPool(GameObject cube)
    {
        await Task.Delay(1000);
        if (cube.activeSelf)
        {
            cube.SetActive(false);

            //await Task.Delay(500);
            cube.transform.parent = _cubesParent;
            _cubePool.Add(cube);
        }
    }
}

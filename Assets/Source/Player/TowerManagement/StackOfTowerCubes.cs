using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class StackOfTowerCubes : MonoBehaviour
{
    [SerializeField] private float _boxHeight;

    [SerializeField] private GameObject _playerCube;
    [SerializeField] private Transform _lastCubePos;
    [SerializeField] private Transform _cubesParent;

    [SerializeField] private Player _player;
    [SerializeField] private TowerCubePool _towerCubePool;

    [SerializeField] private List<GameObject> _cubeList = new List<GameObject>();

    //private readonly object _lock = new object();

    [Inject] private GameManager _gameManager;

    private void Awake()
    {
        _cubeList.Add(_playerCube);
    }

    public async void IncreaseTowerSize(GameObject triggerCube)
    {
        _gameManager.PickUpBlock();

        triggerCube.SetActive(false);
        Vector3 playerPosition = _player._playerModel.transform.position;
        playerPosition += Vector3.up * _boxHeight;
        _player._playerModel.transform.position = playerPosition;

        foreach (GameObject cube in _cubeList)
        {
            Vector3 cubePosition = cube.transform.position;
            cubePosition += new Vector3(0, 1, 0) * _boxHeight;
            cube.transform.position = cubePosition;
        }

        _towerCubePool.AddCubeInTower(_cubesParent, _cubeList, _lastCubePos);

        await Task.Delay(1000);
        triggerCube.SetActive(true);
    }

    public void DecreaseTowerSize(GameObject cubeForRemove)
    {
        _gameManager.HandleCollisionWithObstacle();
        _cubeList.Remove(cubeForRemove);
        _towerCubePool.GetCubeFromTower(cubeForRemove);
    }
}

using UnityEngine;

public class TowerСubeСollision : MonoBehaviour
{
    [SerializeField] private StackOfTowerCubes _stackOfTowerCubes;

    private void Start()
    {
        if (!_stackOfTowerCubes)
        {
            _stackOfTowerCubes = FindObjectOfType<StackOfTowerCubes>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CubeToAdd>())
        {
            _stackOfTowerCubes.IncreaseTowerSize(other.gameObject);
        }
        else if (other.gameObject.GetComponent<ObstacleCube>())
        {
            _stackOfTowerCubes.DecreaseTowerSize(gameObject);
        }
    }
}

using UnityEngine;
using Zenject;

public class PlayerCubeCollisionTrigger : MonoBehaviour
{
    [SerializeField] private StackOfTowerCubes _stackOfTowerCubes;

    [Inject] private GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CubeToAdd>())
        {
            _stackOfTowerCubes.IncreaseTowerSize(other.gameObject);
        }
        else if (other.gameObject.GetComponent<ObstacleCube>())
        {
            _gameManager.GameOver();
        }
    }
}

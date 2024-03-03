using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class CollectingTextsPool : MonoBehaviour
{
    [SerializeField] private int _poolSize = 5;
    [SerializeField] private GameObject _textPrefab;
    //[SerializeField] private Transform _textsParent;

    private List<GameObject> _textPool = new List<GameObject>();

    [Inject] private Player _player;

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject cube = Instantiate(_textPrefab, transform.position, Quaternion.identity, transform);
            cube.SetActive(false);
            _textPool.Add(cube);
        }
    }

    public void ActivateText(Vector3 position)
    {
        GameObject textToActivate = null;

        foreach (GameObject textObject in _textPool)
        {
            if (!textObject.activeInHierarchy)
            {
                textToActivate = textObject;
                break;
            }
        }

        if (textToActivate == null)
        {
            textToActivate = Instantiate(_textPrefab, position, Quaternion.identity, transform);
            _textPool.Add(textToActivate);
        }

        textToActivate.transform.position = position;
        textToActivate.SetActive(true);
    }
}

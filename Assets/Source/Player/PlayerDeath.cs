using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private float _forwardForce = 1f;
    [SerializeField] private float _lifetimeAfterDeath = 5f;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _ragdollObject;

    private Rigidbody[] _ragdollRigidbodies;
    private Collider[] _ragdollColliders;

    private void OnEnable()
    {
        GameManager.GameOverEvent += ActivateRagdoll;
    }

    private void Awake()
    {
        _ragdollRigidbodies = _ragdollObject.GetComponentsInChildren<Rigidbody>();
        _ragdollColliders = _ragdollObject.GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        SetRagdollEnabled(false);
    }

    private  void ActivateRagdoll()
    {
        _playerAnimator.enabled = false;
        SetRagdollEnabled(true);
        StartCoroutine(WaitAndDeactivatePlayer(_lifetimeAfterDeath));
        //await Task.Delay(5000);
        
    }

    private void SetRagdollEnabled(bool isEnabled)
    {
        foreach (var rb in _ragdollRigidbodies)
        {
            rb.isKinematic = !isEnabled;
        }

        foreach (var collider in _ragdollColliders)
        {
            collider.enabled = isEnabled;
        }
    }

    private IEnumerator WaitAndDeactivatePlayer(float time)
    {
        yield return new WaitForSeconds(time);
        _playerObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.GameOverEvent -= ActivateRagdoll;
    }
}

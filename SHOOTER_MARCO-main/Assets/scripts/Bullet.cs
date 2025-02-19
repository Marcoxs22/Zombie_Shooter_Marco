using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private int damage = 1;
    public int Damage
    {
        get {return damage;}    
    }


    private void OnEnable()
    {
        
        if(_rigidbody == null)
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        _rigidbody.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }

    }

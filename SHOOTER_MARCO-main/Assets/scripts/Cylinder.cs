using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _cylinderSpeed;

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
        _rigidbody.AddForce(transform.forward * _cylinderSpeed, ForceMode.Impulse);
    }

}

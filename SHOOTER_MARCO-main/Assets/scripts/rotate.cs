using UnityEngine;

public class Rotate : MonoBehaviour
{
   [SerializeField]
   private float _rotateSpeed = 5;
   [SerializeField]
   private bool _isRotating = true;

   public bool IsRotating
   {
    get { return _isRotating;}
    set { _isRotating = value;}
   }

   
    // Update is called once per frame
    void Update()
    {
        Rotateweapon();
    }

    private void Rotateweapon()
    {
        if (_isRotating)
        {
            gameObject.transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulllet;
    [SerializeField]
    private Transform _bulletPivot;

    [SerializeField]
    private Animator _weaponAnimator;

    [SerializeField]
    private int _maxBulletsNumber = 20;

    [SerializeField]
    private int _cartridgeBulletsNumber = 5;

     
    private int _totalBulletsNumber = 0;

     
    private int _currentBulletsNumber = 0;

    
    private Text _bulletsText;

    private GetWeapon _getweapon;

    private void RemoveWeapon()
    {
        _getweapon.RemoveWeapon();
        _getweapon = null;
    }

    public void Shoot()
    {
        if (_currentBulletsNumber == 0)
        {
            if(_totalBulletsNumber == 0)
            {
              RemoveWeapon();
            }
            return;
        }
        SoundManager.instance.Play("Fire");
        _weaponAnimator.Play("Shoot", -1, 0f);
        _weaponAnimator.Play("Shoot 1", -1, 0f);
        GameObject.Instantiate(_bulllet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletsNumber--;
        UpdateBulletsText();
    }

    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _getweapon = getWeapon;
        _totalBulletsNumber = _maxBulletsNumber;
        Reload();
        _weaponAnimator.Play("GetWeapon");
        _weaponAnimator.Play("GetWeapon 1");
        UpdateBulletsText();
    }

    public void Reload()
    {
        if(_currentBulletsNumber == _cartridgeBulletsNumber || _totalBulletsNumber == 0)
        {
            return;
        }
        int bulletsNeeded = _cartridgeBulletsNumber - _currentBulletsNumber;
        if(_totalBulletsNumber >= _cartridgeBulletsNumber)
        {
             _currentBulletsNumber = _cartridgeBulletsNumber;
        } else if (_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }
        SoundManager.instance.Play("Reload");
         _totalBulletsNumber -= _currentBulletsNumber;
         UpdateBulletsText();
         _weaponAnimator.Play("Reload");
         _weaponAnimator.Play("Reload 1");
    }

    private void UpdateBulletsText()
    {
        if(_bulletsText == null)
        {
            _bulletsText = _getweapon.GetComponent<UIController>().BulletText;
        }
        _bulletsText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletsUI;
    [SerializeField]
    private Text _bulletsText;
    public Text BulletText
    {
        get{return _bulletsText;}
    }

    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private GameObject _winUI;
    [SerializeField]
    private GameObject _pointUI;

    private void Start()
    {
        ShowBulletsUI(false);
        ShowGameOverUI(false);
        ShowWinUI(false);
    }

    public void ShowBulletsUI(bool show)
    {
        _bulletsUI.SetActive(show);
    }

    public void ShowGameOverUI(bool show)
    {
        _gameOverUI.SetActive(show);
    }

    public void ShowWinUI(bool show)
    {
        _winUI.SetActive(show);
    }

   
}

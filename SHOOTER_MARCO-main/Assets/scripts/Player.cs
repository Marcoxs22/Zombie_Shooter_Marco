    using UnityEngine;

public class Player : MonoBehaviour
{
   private Health health;

   private UIController uIController;

   private bool isPlaying = true;

    private void Start()
    {
        health = GetComponent<Health>();
        uIController = GetComponent<UIController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            transform.position += pushDirection * 0.5f;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            isPlaying = false;
            uIController.ShowWinUI(true);
            SoundManager.instance.Play("GameWin");
        }
    }

    public void Die()
    {
        uIController.ShowGameOverUI(true);
        Destroy(gameObject);
        SoundManager.instance.Play("PlayerDie");
    }
}

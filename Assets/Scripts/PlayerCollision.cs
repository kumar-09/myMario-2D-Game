using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            GameManager.GameIsOver = true;
            AudioManager.instance.Play("gameOver");
            gameObject.SetActive(false);
        }
    }
}

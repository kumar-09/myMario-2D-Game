using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Coin collected");
            AudioManager.instance.Play("coinCollected");
            GameManager.coinCount += 1;
            PlayerPrefs.SetInt("coinCount", GameManager.coinCount);
            Destroy(gameObject);
        }
    }
}

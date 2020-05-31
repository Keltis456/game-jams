using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected");
            GameManager.instance.Score += 10;
            Destroy(gameObject);
        }
    }
}

using DG.Tweening;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    
    private bool isShown;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + " : " + other.tag);
        if (other.CompareTag("Player") && !isShown)
        {
            Debug.Log("Player");
            isShown = true;
            GameObject.FindWithTag("FinalFade").GetComponent<SpriteRenderer>().DOColor(Color.white, 2f);
        }
    }
}
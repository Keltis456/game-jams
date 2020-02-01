using DG.Tweening;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.SetCheckpoint(this);
        DOTween.Sequence().Append(transform.DOScale(1,0.3f)).Append(transform.DOScale(0.5f,0.3f));
    }
}
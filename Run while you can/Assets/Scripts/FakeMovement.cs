using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FakeMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.down * (GameManager.instance.GlobalSpeed * Time.deltaTime));
    }
}
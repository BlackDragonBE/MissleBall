using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MovementSpeed = 10f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * MovementSpeed;
    }
}
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = new Vector3 (transform.position.x + horizontalInput * _moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}

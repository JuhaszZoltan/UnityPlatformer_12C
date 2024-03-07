using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float delay = 1f;
    [SerializeField] private float viewDistance = 14f;

    //private Vector3 offsetRight;
    //private Vector3 offsetLeft;
    private Vector3 offset;

    private float lowY;
    //private float difX;
    bool facingRight = true;

    private void Start()
    {
        lowY = transform.position.y;
        //difX = transform.position.x - target.position.x;

        offset = transform.position - target.position;
        offset.x -= viewDistance / 2;
        //offsetRight = transform.position - target.position;
        //offsetLeft = transform.position - target.position;

    }

    private void FixedUpdate()
    {

        if (facingRight != target.localScale.x < 0)
        {
            facingRight = target.localScale.x < 0;
            offset.x += facingRight ? -viewDistance : viewDistance;
        }

        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            delay * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new(transform.position.x, lowY, transform.position.z);
        }
    }
}

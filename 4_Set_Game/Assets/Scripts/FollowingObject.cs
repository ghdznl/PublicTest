using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    public float speed;
    [SerializeField]
    Vector3 direction;
    public BoxCollider Environment;
    public float RotateAngle = 200;

    private void Start()
    {
        direction = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized;
        ChangeDirection();
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke(nameof(ResetPosition));
        Invoke(nameof(ResetPosition), 10);
        if (other.gameObject == Environment.gameObject)
            ChangeDirection();
    }
    
    void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    private void ChangeDirection()
    {
        direction = (Quaternion.AngleAxis(RotateAngle, Vector3.up) * direction).normalized;
    }
}

using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    private Vector3 pos;
    private float direction;
    private void Start()
    {
        pos = transform.position;
        direction = pos.z > 0 ? -1 : 1;
    }

    private void Update()
    {
        pos.z += direction * speed * Time.deltaTime;
        transform.position = pos;

        var destroyRange = 10f;
        if (pos.z > destroyRange || pos.z < -destroyRange)
        {
            Destroy(gameObject);
        }
    }
}

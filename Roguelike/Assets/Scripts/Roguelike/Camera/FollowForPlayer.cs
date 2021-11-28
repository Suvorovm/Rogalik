
using UnityEngine;

public class FollowForPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int speed=5;
    [SerializeField] private float offsetX,offsetY;
    private Vector3 temp;

    void LateUpdate()
    {
        temp = player.position;
        temp.x += offsetX;
        temp.y += offsetY;
        temp.z += -10f;
        transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);

    }

}

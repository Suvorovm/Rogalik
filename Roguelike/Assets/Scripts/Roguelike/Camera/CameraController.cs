
using Roguelike.World;
using Roguelike.World.Player;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private int speed=5;
    [SerializeField] private float offsetX,offsetY;
    private Vector3 temp;
    private Transform player;
    void Start()
    {
         player = GameWorld.GameWorldInstance.RequaireObjectByName("Player").transform;
    }

    void LateUpdate()
    {
        temp = player.position;
        temp.x += offsetX;
        temp.y += offsetY;
        temp.z += -10f;
        transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);

    }

}

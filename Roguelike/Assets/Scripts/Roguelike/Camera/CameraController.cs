
using Roguelike.World;
using Roguelike.World.Player;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const string PLAYER_NAME = "Player";

    [SerializeField] private int speed=5;
    [SerializeField] private float offsetX,offsetY;
    [SerializeField] private GameObject _player;
    private Vector3 temp;
    private GameWorld _gameWorld;
    private Camera _camera;


    public void Init()
    {
        _gameWorld = GameWorld.GameWorldInstance;
        _player = _gameWorld.RequaireObjectByName(PLAYER_NAME);
        _camera = GetComponent<Camera>();
        _camera.depth += 0;

    }
    void LateUpdate()
    {
        if (_player != null)
        {
            Debug.Log("u");
            temp = _player.transform.position;
            temp.x += offsetX;
            temp.y += offsetY;
            temp.z += -10f;
            transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);
        }
    }

}

using Assets;
using Rooms;
using Storage;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField] private Transform roomContainer;
    private GameObject _player;
    private CameraFollow _cameraFollow;
    private void Start()
    {
        Game.Run();
        Game.OnGameInitializeEvent += OnGameInitializes;
    }

    private void OnGameInitializes()
    {
        Game.OnGameInitializeEvent -= OnGameInitializes;

        var room = new Room(roomContainer);

        _cameraFollow = Camera.main.GetComponent<CameraFollow>();

        var playerPrefab = Resources.Load<GameObject>("PlayerPrefab");
        _player = Instantiate(playerPrefab);
        _player.transform.position = new Vector2(0, 0);

        Debug.Log($"GameRun!");
    }

    private void FixedUpdate()
    {
        if (_player is null || _cameraFollow is null)
            return;
        
        _cameraFollow.SmoothFollow(_player);
    }
}
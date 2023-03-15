using Assets;
using Storage;
using Storage.Player;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    private PlayerIterator _playerIterator;
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
        
        _playerIterator = Game.GetIterator<PlayerIterator>();
        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        _player = _playerIterator.player;

        Debug.Log($"GameRun!");
    }

    private void FixedUpdate()
    {
        if (_player is null || _cameraFollow is null)
            return;
        
        _cameraFollow.SmoothFollow(_player);
    }
}
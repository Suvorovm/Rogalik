
using System;
using Core;
using Core.UI;
using Core.UI.Model;
using Core.Utils;
using UnityEngine;
using DG.Tweening;
using Roguelike.UI;
using Roguelike.World;
using Roguelike.World.Service;
using Roguelike.World.UI;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour, IScreen
{
    public const string SCREEN_PATH = "UI/Game/MainMenu/Menu";
    private const string PLAYER_PATH = "GameWorld/2DObject/Player/Player";
    
    private GameWorld _world;
    private UIService _UIService;
    private LevelLoaderService _levelLoaderService;
    private PlayerProgressService _playerProgressService;
    
    private GameObject _player;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resumeButton;
    
    public void Configure(IScreenModel screenModel)
    {
        _levelLoaderService = GameApplication.RequireService<LevelLoaderService>();
        _playerProgressService = GameApplication.RequireService<PlayerProgressService>();
        
        _UIService = GameApplication.RequireService<UIService>();
        _startButton.onClick.AddListener(StartButton);
        _resumeButton.onClick.AddListener(ResumeButton);
    }

    public void StartButton()
    {
        _levelLoaderService.LoadNextLevel();
        _UIService.ShowScreen<GameScreen>(GameScreen.SCREEN_PATH);
        _world = GameWorld.GameWorldInstance;
    }

    public void ResumeButton()
    {
        _levelLoaderService.LoadNextLevel(_playerProgressService.currentLevel);
        _UIService.ShowScreen<GameScreen>(GameScreen.SCREEN_PATH);
        _world = GameWorld.GameWorldInstance;
    }
}

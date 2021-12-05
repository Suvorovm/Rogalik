
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
    
    private GameObject _player;
    [SerializeField] private Button _button;
    
    public void Configure(IScreenModel screenModel)
    {
        _levelLoaderService = GameApplication.RequireService<LevelLoaderService>();
        _UIService = GameApplication.RequireService<UIService>();
        _button.onClick.AddListener(StartButton);
    }

    public void StartButton()
    {
        _levelLoaderService.LoadNextLevel();
        _UIService.ShowScreen<GameScreen>(GameScreen.SCREEN_PATH);
        _world = GameWorld.GameWorldInstance;
    }
}

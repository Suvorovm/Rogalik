
using Core;
using Core.Utils;
using UnityEngine;
using DG.Tweening;
using Roguelike.UI;
using Roguelike.UIService;
using Roguelike.World;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIService _UIService;
    private GameObject _overlay;
    private GameObject _mainMenu;
    private GameObject _mainScreen;
    private GameObject _ui;
    private GameObject _player;
    [SerializeField]public GameWorld _gameWorld;
    void OnEnable()
    {
        //_UIService = GameApplication.RequireService<UIService>();
        _mainMenu = ResourseLoadService.GetResource<GameObject>("UI/Game/MainMenu/MainMenu");
        _mainScreen = GameObject.Find("MainScreen");
        _ui = GameObject.Find("UI");
        _mainMenu = Instantiate(_mainMenu, _ui.transform, false);
        _mainMenu.name = "MainMenu";
    }

    public void StartButton()
    {
        //_mainMenu = _UIService.RequaireObjectUIByName("MainMenu");
        
        GameObject.FindWithTag("Menu").transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Flash);// тут я пытался сделать анимацю с помощью дотвина но не судьба
        GameObject.FindWithTag("Menu").SetActive(false);
        //_mainMenu.SetActive(false);
        //_player = ResourseLoadService.GetResource<GameObject>("GameWorld/2DObject/Player/Player");
        GameObject _world = GameObject.Find("World");
        //_player = Instantiate(_player, _world.transform, false);
        _mainScreen = GameObject.Find("MainScreen");
        _overlay = ResourseLoadService.GetResource<GameObject>("UI/Game/Overlay/pfGameOverlay");
        _mainScreen = _gameWorld.RequaireObjectByName("Player");
        _mainScreen.SetActive(false);
        Instantiate(_overlay).transform.SetParent(_mainScreen.transform, false);
    }
}


using Core.Utils;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    private GameObject _overlay;
    private GameObject _mainMenu;
    private GameObject MainScreen;
    private GameObject _ui;
    private GameObject _player;
    void OnEnable()
    {
        _mainMenu = ResourseLoadService.GetResource<GameObject>("UI/Game/MainMenu/MainMenu");
        MainScreen = GameObject.Find("MainScreen");
        _ui = GameObject.Find("UI");
        _mainMenu = Instantiate(_mainMenu);
        _mainMenu.transform.SetParent(_ui.transform,false);
        //1159.9  552.6
    }

    public void StartButton()
    {
        _mainMenu = GameObject.Find("MainMenu(Clone)");
        _mainMenu.SetActive(false);
        _player = ResourseLoadService.GetResource<GameObject>("GameWorld/2DObject/Player/Player");
        GameObject _world = GameObject.Find("World");
        _player = Instantiate(_player);
        _player.transform.SetParent(_world.transform,false);
        MainScreen = GameObject.Find("MainScreen");
        _overlay = ResourseLoadService.GetResource<GameObject>("UI/Game/Overlay/pfGameOverlay");
        Instantiate(_overlay).transform.SetParent(MainScreen.transform, false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

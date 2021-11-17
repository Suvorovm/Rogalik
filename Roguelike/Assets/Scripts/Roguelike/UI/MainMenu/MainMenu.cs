
using Core.Utils;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    private GameObject _overlay;
    private GameObject _mainMenu;
    private GameObject _mainScreen;
    private GameObject _ui;
    private GameObject _player;
    void OnEnable()
    {
        _mainMenu = ResourseLoadService.GetResource<GameObject>("UI/Game/MainMenu/MainMenu");
        _mainScreen = GameObject.Find("MainScreen");
        _ui = GameObject.Find("UI");
        _mainMenu = Instantiate(_mainMenu, _ui.transform, false);
    }

    public void StartButton()
    {
        _mainMenu = GameObject.Find("MainMenu(Clone)");
        GameObject.FindWithTag("Menu").transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);// тут я пытался сделать анимацю с помощью дотвина но не судьба
        _mainMenu.SetActive(false);
        _player = ResourseLoadService.GetResource<GameObject>("GameWorld/2DObject/Player/Player");
        GameObject _world = GameObject.Find("World");
        _player = Instantiate(_player, _world.transform, false);
        _mainScreen = GameObject.Find("MainScreen");
        _overlay = ResourseLoadService.GetResource<GameObject>("UI/Game/Overlay/pfGameOverlay");
        Instantiate(_overlay).transform.SetParent(_mainScreen.transform, false);
    }
}

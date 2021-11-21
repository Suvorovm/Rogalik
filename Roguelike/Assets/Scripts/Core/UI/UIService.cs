using System.Collections.Generic;
using Core.UI.Model;
using Core.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.UI
{
    public class UIService : MonoBehaviour
    {
        private const string DIALOG_CONTAINER = "DialogContainer";
        private const string SCREEN_CONTAINER = "ScreenContainer";

        private GameObject _screenContainer;
        private GameObject _dialogContainer;

        private Stack<IDialog> _dialogStack = new Stack<IDialog>();
        public void Init()
        {
            ValidateUIStruct();
        }


        public T ShowScreen<T>(string prefabPath, [CanBeNull] IScreenModel model = null)
            where T : MonoBehaviour, IScreen
        {
            T screenMonoBehaviour = InstantiateUIPrefab<T>(prefabPath);

            screenMonoBehaviour.Configure(model);

            _screenContainer.gameObject.RemoveAllChild();
            _dialogContainer.gameObject.RemoveAllChild();
            screenMonoBehaviour.transform.SetParent(_screenContainer.transform, false);
            return screenMonoBehaviour;
        }

        public T ShowDialog<T>(string prefabPath, [CanBeNull] IDialogModel model = null)
            where T : MonoBehaviour, IDialog
        {
            T dialog = InstantiateUIPrefab<T>(prefabPath);
            dialog.Configure(model);
            dialog.gameObject.transform.SetParent(_dialogContainer.transform, false);
            return dialog;
        }

        private void ValidateUIStruct()
        {
            _dialogContainer = gameObject.GetChildByName(DIALOG_CONTAINER);
            _screenContainer = gameObject.GetChildByName(SCREEN_CONTAINER);
            Predications.CheckNotNull(_dialogContainer);
            Predications.CheckNotNull(_screenContainer);
        }

        private T InstantiateUIPrefab<T>(string prefabPath)
            where T : MonoBehaviour
        {
            GameObject prefab = Resources.Load<GameObject>(prefabPath);
            GameObject instantiatedScreen = Instantiate(prefab);
            T screenMonoBehaviour = instantiatedScreen.GetComponent<T>();
            return screenMonoBehaviour;
        }
    }
}
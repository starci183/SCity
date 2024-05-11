using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICanvasController : Singleton<UICanvasController>
{
    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;

    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Button _button;
    
    private void Start()
    {
        _inputField.text = _clientDataScriptableObject.joinCode;

        _button.onClick.AddListener(() =>
        {
            _clientDataScriptableObject.joinCode = _inputField.text;
            BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.MainScene);
        });
    }
}
    
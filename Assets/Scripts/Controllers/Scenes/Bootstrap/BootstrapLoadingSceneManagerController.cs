using System.Collections;
using System.ComponentModel;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLoadingSceneManagerController : SingletonPersistent<BootstrapLoadingSceneManagerController>
{
    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private async void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(OnSceneLoadedCoroutine(scene));

        if (EnumUtility.GetEnumValueByDescription<SceneName>(scene.name) == SceneName.MainScene)
        {
            await RelayUtility.JoinRelayAsync(_clientDataScriptableObject.joinCode);
            NetworkManager.Singleton.StartClient();
        }
    }

    private IEnumerator OnSceneLoadedCoroutine(Scene scene)
    {


        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeOut);
    }

    public void LoadScene(SceneName sceneToLoad, bool isNetworkSessionAction = false)
    {
        StartCoroutine(LoadSceneCoroutine(sceneToLoad, isNetworkSessionAction));
    }

    private IEnumerator LoadSceneCoroutine(SceneName sceneToLoad, bool isNetworkSessionActive = false)
    {
        BootstrapLoadingFadeEffectController.Instance.FadeIn();

        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeIn);

        if (isNetworkSessionActive)
        {
            LoadSceneNetwork(sceneToLoad);
        }
        else
        {
            LoadSceneLocal(sceneToLoad);
        }

        yield return new WaitForSeconds(1f);

        if (sceneToLoad == SceneName.MainScene)
        {
            yield return new WaitUntil(() => _clientDataScriptableObject.isPlayerSpawned);
            _clientDataScriptableObject.isPlayerSpawned = false;
        }

        BootstrapLoadingFadeEffectController.Instance.FadeOut();

        yield return new WaitUntil(() => BootstrapLoadingFadeEffectController.EndFadeOut);
    }

    private void LoadSceneLocal(SceneName sceneToLoad)
    {
        SceneManager.LoadScene(EnumUtility.GetDescription(sceneToLoad));
    }

    public void LoadSceneNetwork(SceneName sceneToLoad)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(
            EnumUtility.GetDescription(sceneToLoad),
            LoadSceneMode.Single);
    }
}

public enum SceneName
{
    [Description("BootstrapScene")]
    BootstrapScene,
    [Description("TitleScene")]
    TitleScene,
    [Description("MainScene")]
    MainScene
}
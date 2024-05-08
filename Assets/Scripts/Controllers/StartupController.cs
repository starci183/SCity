using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class StartupController : SingletonPersistent<StartupController>
{
    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;

    [SerializeField]
    private bool _isClient;

    public static bool HasFinished { get; set; } = false;
    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Signed in with player ID: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        if (_isClient)
        {
            var joinCodeDto = await HttpUtility.GetAsync<JoinCodeDto>(
                "https://scity-frontend.vercel.app/api",
                async (response) =>
                {
                    Debug.Log(response.StatusCode);
                }
                );

            var joinCode = joinCodeDto.JoinCode;


            if (string.IsNullOrEmpty(joinCode))
            {
                LoadingSceneManagerController.Instance.LoadScene(SceneName.TitleScene);
            }
            else
            {
                _clientDataScriptableObject.joinCode = joinCode;
                LoadingSceneManagerController.Instance.LoadScene(SceneName.MainScene);
            }
        }

        HasFinished = true;
    }
}

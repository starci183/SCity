using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class BootstrapStartupController : SingletonPersistent<BootstrapStartupController>
{
    [SerializeField]
    private ClientDataScriptableObject _clientDataScriptableObject;

    [SerializeField]
    private bool _isClient;

    public static bool HasFinished { get; set; } = false;
    private async void Start()
    {
        Application.targetFrameRate = 60;

        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Signed in with player ID: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        if (_isClient)
        {
            Debug.Log(Constants.ApiEndpoints.JOIN_CODE);
            var joinCodeDto = await HttpUtility.GetAsync<JoinCodeDto>(
                Constants.ApiEndpoints.JOIN_CODE
            );

            var joinCode = joinCodeDto.JoinCode;
            _clientDataScriptableObject.joinCode = joinCode;

            BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.TitleScene);
        }

        HasFinished = true;
    }
}

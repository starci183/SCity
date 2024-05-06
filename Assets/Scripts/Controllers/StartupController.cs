using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class StartupController : SingletonPersistent<StartupController>
{
    [SerializeField]
    private bool _isClient;
    private async void Start()
    {   
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log($"Signed in with player ID: {AuthenticationService.Instance.PlayerId}");
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        if (_isClient) 
            LoadingSceneManagerController.Instance.LoadScene(SceneName.TitleScene);
    }
}

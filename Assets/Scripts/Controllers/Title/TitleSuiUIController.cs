using Newtonsoft.Json;
using Suinet.Rpc.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSuiUIController : Singleton<TitleSuiUIController>
{
    [SerializeField]
    private Button _createNewWalletButton;

    [SerializeField]
    private Button _importAWalletButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    [SerializeField]
    private Transform _titleInputMnemonicsModal;

    // Start is called before the first frame update
    private void Start()
    {
        _createNewWalletButton.onClick.AddListener(OnCreateNewWalletButtonClick);
        _importAWalletButton.onClick.AddListener(OnImportAWalletButtonClick);
    }

    private void OnCreateNewWalletButtonClick()
    {
        var mnemonics = SuiWallet.CreateNewWallet();
        PlayerPrefs.SetString("SuiMnemonics", mnemonics);

        var address = SuiWallet.GetActiveAddress();


        _blockchainDataScriptableObject.Address = address;

        BootstrapModalController.Instance.CloseNearestModal();

        PlayerPrefs.SetString(Constants.PlayerPrefs.SIGNED_IN, true.ToString());
        BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.MainScene);
    }

    private void OnImportAWalletButtonClick()
    {
        BootstrapModalController.Instance.CreateModal(_titleInputMnemonicsModal);
    }
}

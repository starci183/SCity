using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleInputMnemonicsModalController : Singleton<TitleInputMnemonicsModalController>
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Toggle _useStoredMnemonicsToggle;

    [SerializeField]
    private Button _cancelButton;

    [SerializeField]
    private Button _importButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    private string storedMnemonics;

    private void Start()
    {
        storedMnemonics = PlayerPrefs.GetString(Constants.PlayerPrefs.SUI_MNEMONICS);

        if (storedMnemonics == null)
        {
            _useStoredMnemonicsToggle.enabled = false;
        }

        _inputField.onEndEdit.AddListener(value => _inputField.text = value);
        _inputField.enabled = !_useStoredMnemonicsToggle.enabled;

        _useStoredMnemonicsToggle.onValueChanged.AddListener(value =>
        {
            _inputField.enabled = !value;
        });
        _importButton.onClick.AddListener(OnImportButtonClick);

        _cancelButton.onClick.AddListener(BootstrapModalController.Instance.CloseNearestModal);
    }

    private void OnImportButtonClick()
    {
        var mnemonics = _useStoredMnemonicsToggle.isOn ? storedMnemonics : _inputField.text;

        SuiWallet.RestoreWalletFromMnemonics(mnemonics);
        var address = SuiWallet.GetActiveAddress();

        _blockchainDataScriptableObject.Address = address;

        BootstrapModalController.Instance.CloseNearestModal();
        PlayerPrefs.SetString(Constants.PlayerPrefs.SIGNED_IN, true.ToString());
        BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.MainScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnImportButtonClick();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BootstrapModalController.Instance.CloseNearestModal();
        }
    }
}

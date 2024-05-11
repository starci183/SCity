using System.Net;

public static class Constants
{
    public static class PlayerPrefs
    {
        public static string SIGNED_IN = "SignedIn";
        public static string SUI_MNEMONICS = "SuiMnemonics";
    }

    public static class ApiEndpoints
    {
        private static readonly string END_POINT = "https://scity-backend.ltvn.pw";
        public static readonly string JOIN_CODE = $"{END_POINT}/join-code";
    }
}
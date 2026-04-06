using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Cadastro : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public void RegisterButton() {
        if (passwordInput.text.Lengh < 6) {
            messageText.text = "Password too short";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequiredBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucess, OnError);
    }

void OnRegisterSucess(RegisterPlayFabUserResult result) {
    messageText.text = "Registered and logged in";
}

public void LoginButton() {

}

public void ResetPasswordButton() {

}
void OnPasswordReset(SendAccountRecoveryEmailResult result)

// Loggin in
void Start()
void Login()
void OnLoginSucess(LoginResult result)

// Player data
public void GetAppearance()
void OnDataRecieved(GetUserDataResult result)
public void SaveAppearance()
void OnDataSend(UpdateUserDataResult result)

// Title data
void GetTitleData()
void OnTitleDataRecieved(GetTitleDataResult result)

// Handling JSON
public void SaveCharacters()
public void GetCharacters()
void OnCharactersDataReceived(GetUserDataResult result)

// Other
void OnError(PlayFabError error) {
    messageText.text = error.ErrorMessage;
    Debug.Log(error.GenerateErrorReport());
}
}
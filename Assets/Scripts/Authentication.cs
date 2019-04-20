using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Authentication
{
    private static string _userId;
    public static string UserId
    {
        get
        {
            return _userId;
        }
    }

    public static bool IsLoggedIn
    {
        get;
        private set;
    }

    public static UserData CurrentUser
    {
        get;
        private set;
    }

    static FirebaseAuth auth = FirebaseAuth.DefaultInstance;
    static PhoneAuthProvider provider;
    static string _id;


    static UnityAction<RequestData> _onVerify;
    static UnityAction<RequestData> _onRegister;

    public static void Register(string phoneNumber, UnityAction<RequestData> onRegister = null)
    {
        provider = PhoneAuthProvider.GetInstance(auth);
        provider.VerifyPhoneNumber(phoneNumber, 1000, null, OnVerificationCompleted,
            OnVerificationFailed, OnCodeSent, OnCodeAutoRetrievalTimeout);
        _onRegister = onRegister;
    }

    private static void OnVerificationCompleted(Credential credential)
    {
        Debug.Log("OnVerificationCompleted");
        LoginUser(credential, false);
    }

    private static void OnVerificationFailed(string error)
    {
        _onRegister.Invoke(new RequestData(false, error));
        Debug.Log("OnVerificationFailed " + error);
    }

    private static void OnCodeSent(string id, ForceResendingToken token)
    {
        _id = id;
        _onRegister.Invoke(new RequestData(true, null));
        Debug.Log("OnCodeSent");
    }
    private static void OnCodeAutoRetrievalTimeout(string id)
    {
        _onRegister.Invoke(new RequestData(false, "time out"));
        Debug.Log("OnCodeAutoRetrievalTimeout");
    }

    public static void Logout()
    {
        auth.SignOut();
    }

    public static void Verify(string code, UnityAction<RequestData> onVerify = null)
    {
        _onVerify = onVerify;
        Credential credential = provider.GetCredential(_id, code);
        LoginUser(credential, true);
    }

    private static void LoginUser(Credential credential, bool isNew)
    {
        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                if (isNew)
                {
                    _onRegister.Invoke(new RequestData(false, task.Exception.ToString()));
                }
                else
                {
                    _onVerify.Invoke(new RequestData(false, task.Exception.ToString()));
                }
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.Log("User signed in successfully");
                // This should display the phone number.
                Debug.Log("Phone number: " + newUser.PhoneNumber);
                // The phone number providerID is 'phone'.
                Debug.Log("Phone provider ID: " + newUser.ProviderId);
                _userId = newUser.UserId;

                if (isNew)
                {
                    _onVerify.Invoke(new RequestData(true, null));
                }

                else
                {
                    // get user data
                    UsersCollection.GetUser(_userId, user =>
                   {
                       if (user != null)
                       {
                           IsLoggedIn = true;
                           CurrentUser = user;
                           _onRegister.Invoke(new RequestData(true, null));
                       }
                       else
                       {
                           _onRegister.Invoke(new RequestData(false, "couldn't downlod user data"));
                       }
                   });
                }
            }

        });
    }

    public static void InitializeUse(UserData user, UnityAction<bool> onUserInitilized)
    {
        CurrentUser = user;
        UsersCollection.SaveUser(_userId, user, onUserInitilized);

    }
}


public class RequestData
{
    public bool Success
    {
        get;
        private set;
    }

    public string Error
    {
        get;
        private set;
    }
    public RequestData(bool success, string error)
    {
        Success = success;
        Error = error;
    }
}
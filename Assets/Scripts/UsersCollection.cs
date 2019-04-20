using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsersCollection
{
    

    // Get the root reference location of the database.
    static DatabaseReference reference;
    public static void GetUser(string id, UnityAction<UserData> onGetUser)
    {
        if (reference == null)
        {
            reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child("User").Child(id).GetValueAsync().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    onGetUser.Invoke(null);
                }
                else if (t.IsCompleted)
                {
                    DataSnapshot snapshot = t.Result;
                    onGetUser.Invoke(JsonUtility.FromJson<UserData>(snapshot.Value.ToString()));
                }
            });

        }
    }

    public static void SaveUser(string id, UserData user, UnityAction<bool> onSaveUser)
    {
        if (reference == null)
        {
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }
        reference.Child("User").Child(id).SetValueAsync(JsonUtility.ToJson(user)).ContinueWith(t =>
        {
            onSaveUser.Invoke(t.IsCanceled || t.IsFaulted);
        });
    }

    public static void RateUser(string id, int rate)
    {

    }
}

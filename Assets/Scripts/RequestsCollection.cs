//using Firebase.Database;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class RequestsCollection {

//    static DatabaseReference reference;
//    public void AddRequest(RequistData requist)
//    {

//    }

//    public void AcceptRequist(string requistId)
//    {

//    }

//    public void DeclineRequists(string requistId)
//    {

//    }

//    public void GetRequists(UnityEvent<List<RequistData>> onGetRequists)
//    {
//        reference.Root.Child("Request").GetValueAsync().ContinueWith(t =>
//        {
//            if (t.IsFaulted)
//            {
//                onGetRequists.Invoke(null);
//            }
//            else if (t.IsCompleted)
//            {
//                DataSnapshot snapshot = t.Result;
//                List<RequistData> data = new List<RequistData>();
//                foreach (var child in snapshot.Children)
//                {
//                    data.Add(child.Value.ToString());
//                }
//                onGetUser.Invoke(JsonUtility.FromJson<UserData>(snapshot.Value.ToString()));
//            }
//        });
//    }
//}

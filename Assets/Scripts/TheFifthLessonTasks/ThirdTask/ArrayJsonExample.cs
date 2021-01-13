using System;
using UnityEngine;

namespace TheFifthLessonTasks.ThirdTask.TestJson
{
    public class ArrayJsonExample : MonoBehaviour
    {
 
        private void Start()
        {
            Player[] playerInstance = new Player[2];

            playerInstance[0] = new Player();
            playerInstance[0].playerId = "8484239823"; 
            playerInstance[0].playerLoc = "Powai"; 
            playerInstance[0].playerNick = "Random Nick";

            playerInstance[1] = new Player();
            playerInstance[1].playerId = "512343283"; 
            playerInstance[1].playerLoc = "User2"; 
            playerInstance[1].playerNick = "Rand Nick 2";

            string playerToJson = JsonHelper.ToJson(playerInstance, true);
            Debug.Log(playerToJson);
            
            string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}";
            Player[] player = JsonHelper.FromJson<Player>(jsonString);
            Debug.Log(player[0].playerLoc);
            Debug.Log(player[1].playerLoc);
        }
    }
    
    [Serializable]
    public class Player 
    {

        public string playerId;
        public string playerLoc;
        public string playerNick;
    }
    public static class JsonHelper 
    {
        public static T[] FromJson<T>(string json) {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T> 
        {
            public T[] Items;
        }
    }


    
}

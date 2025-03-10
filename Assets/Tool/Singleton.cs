using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instan;

    public static T Instance
    {
        get
        {
            if (instan == null)
            {
                instan = (T)FindObjectOfType(typeof(T));
            }

            if (instan == null)
            {
                GameObject obj = new GameObject();
                instan = obj.AddComponent<T>();
            }
            return instan;
        }
    }
}
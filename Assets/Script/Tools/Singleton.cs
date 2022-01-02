using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T :Singleton<T> 
{
    private static T instance;
    // Start is called before the first frame update
    public static T Instance{
        get {return instance;}

    }
    // over write 
    protected virtual void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }else{
            instance = (T)this;
        }
    }

    // Check if instance is generated
    public static bool IsInitiaized{
        get{return instance!=null;}
    }

    protected virtual void OnDestroy() {
        if(instance == this){
            instance = null;
        }
    }
}

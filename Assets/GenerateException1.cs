using UnityEngine;

public class GenerateException1 : MonoBehaviour {

    public void OnClick()
    {
        throw new System.Exception("Exception 1");
    }
}

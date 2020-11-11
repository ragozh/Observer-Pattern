using System;
using UnityEngine;

public class ObjectCollide : MonoBehaviour
{
    public static event Action<ObjectCollide> OnSubjectEntered;
    [SerializeField]
    public string ObjName { get { return gameObject.name; } }
    private void OnTriggerEnter(Collider other)
    {
        if (OnSubjectEntered != null)
            OnSubjectEntered(this);
        
        DestroyObject();
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}

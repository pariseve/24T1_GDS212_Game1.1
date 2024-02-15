using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerFunction : MonoBehaviour
{
    [SerializeField] private UnityEvent Function;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.X))
        Function.Invoke();
    }
}

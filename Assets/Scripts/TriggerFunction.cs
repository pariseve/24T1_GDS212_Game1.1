using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerFunction : MonoBehaviour
{
    [SerializeField] private UnityEvent Function;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.X))
        Function.Invoke();
    }
}

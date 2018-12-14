using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collidercomponent : MonoBehaviour {

    public string TagFilter;

    public UnityEvent EventOnEnter;
    public UnityEvent EventOnExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != TagFilter)
            return;
        if (EventOnEnter != null)
            EventOnEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != TagFilter)
            return;
        if (EventOnExit != null)
            EventOnExit.Invoke();
    }
}

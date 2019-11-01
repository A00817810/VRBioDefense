using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool>{ }

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    private ToggleEvent onToggleShared;
    [SerializeField]
    private ToggleEvent onToggleLocal;
    [SerializeField]
    private ToggleEvent onToggleRemote;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayer();
    }

    void DisablePlayer()
    {
        onToggleShared.Invoke(false);
        if (isLocalPlayer)
        {
            onToggleLocal.Invoke(false);
        }
        else
        {
            onToggleRemote.Invoke(false);
        }
    }

    void EnablePlayer()
    {
        onToggleShared.Invoke(false);
        if (isLocalPlayer)
        {
            onToggleLocal.Invoke(false);
        }
        else
        {
            onToggleRemote.Invoke(false);
        }
    }
}

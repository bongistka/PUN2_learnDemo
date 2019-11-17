using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Basic class to manage multiplayer connection to the server. 
// It inherits from the Poton.Pun MonoBehaviourPunCallbacks class rather than the default one.

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject enterGamePanel;
    public GameObject connectionStatusPanel;
    public GameObject LobbyPanel;

    #region Unity Methods
    void Start()
    {
        // Sets the UI panels to enterGamePanel
        enterGamePanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }
    #endregion

    #region Public Methods
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            // Connects us to the Photon server using settings in 
            // Photon /PhotonUnityNetworking/Resources/PhotonServerSettings.
            PhotonNetwork.ConnectUsingSettings();

            // Sets the UI panels to connectionStatusPanel which will indicate that we are trying to connect
            enterGamePanel.SetActive(false);
            connectionStatusPanel.SetActive(true);
        }
        
    }
    #endregion

    #region Photon Callbacks
    // Called when we successfully connect to the server.
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " Connected to Photon server.");
        connectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }

    // Called when internet connection is available. This gets called before OnConnectedToMaster
    public override void OnConnected()
    {
        Debug.Log("Connected to the Internet.");
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviour
{
    #region Private Serializable Fields

    #endregion

    #region Private Fields

    // el numero de version de este cliente. Los usuarios son separados por la gameVersion

    string gameVersion = "1.0";

    #endregion

    #region MonoBehaviour Callbacks 

    private void Awake()
    {
        // esto se asegura que todos los metodos de PhotonNetwork.LoadLevel() en el cliente maestro y todos los clientes en la misma room
        // sincronizan sus niveles automaticamente 
        PhotonNetwork.AutomaticallySyncScene = true;    
    }

    private void Start()
    {
        // llama al metodo Connect al Start
        Connect();
    }

    #endregion

    #region Public Methods 
    // Comienza el proceso de conexion
    // Si ya esta conectado, nos intentamos unir a una room aleatoria
    // si no esta conectado ya, conecta esta aplicacion con Photon Cloud Network
    public void Connect() 
    {
        // comprueba si estamos conectados o no, nos unimos si estamos conectados,
        // e iniciamos la conexion al servidor
        if (PhotonNetwork.IsConnected)
        {
            // tenemos que intentar unirnos una room aleatorio.
            // Si falla, recibiremos una notificacion y creara una 
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // primero debemos conectar con el Photon Online Server 
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;    
        }
    }

    #endregion
}

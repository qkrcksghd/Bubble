using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManagerChat : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";

    public Text connectionInfoText;
    public Button map1joinButton;
    public Button map2joinButton;
    public Button map3joinButton;
    private bool btn1;
    private bool btn2;
    private bool btn3;

    // ���� ����� ���ÿ� ������ ���� ���� �õ�
    private void Start()
    {
        btn1 = false;
        btn2 = false;
        btn3 = false;
        //���ӿ� �ʿ��� ���� (���� ����) ����
        PhotonNetwork.GameVersion = this.gameVersion;
        //������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();


        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false;
        this.connectionInfoText.text = "������ ������ ������...";
    }

    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        this.map1joinButton.interactable = true;
        this.map2joinButton.interactable = true;
        this.map3joinButton.interactable = true;
        this.connectionInfoText.text = "�¶��� : ������ ������ ���� ��";
    }

    // ������ ���� ���� ���н� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false;
        this.connectionInfoText.text = "�������� : ������ ������ ������� ����\n ���� ��õ���... ";
        //������ ������ ������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();
    }

    // �� ���� �õ�
    public void Connect()
    {
        // �ߺ� ���� ����
        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false; ;

        // ������ ������ ���� ���̶��
        if (PhotonNetwork.IsConnected)
        {

            //�뿡 �����Ѵ�.
            this.connectionInfoText.text = "�뿡 ����....";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            this.connectionInfoText.text = "�������� : ������ ������ ���� ��Ŵ \n �ٽ� ���� �õ��մϴ�.";
            //������ ������ ������ ���� ���� �õ�
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // (�� ���� ����)���� �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        this.connectionInfoText.text = "�� �� ����, ���ο�� ����...";
        //�ִ� �ο��� 4������ ���� + ���� ����
        //���̸� , 4�� ����
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });

    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        this.connectionInfoText.text = "�� ���� ����!";

        if (btn1 == true)
        {
            //��� �� �����ڰ� �����ص� ���� �ε��ϰ� ��
            PhotonNetwork.LoadLevel("01_Map");
        }
        if (btn2 == true)
        {
            //��� �� �����ڰ� �����ص� ���� �ε��ϰ� ��
            PhotonNetwork.LoadLevel("02_Map");
        }
        if (btn3 == true)
        {
            //��� �� �����ڰ� �����ص� ���� �ε��ϰ� ��
            PhotonNetwork.LoadLevel("03_Map");
        }


    }

    public void btn1Click()
    {
        btn1 = true;
        Connect();
    }

    public void btn2Click()
    {
        btn2 = true;
        Connect();
    }

    public void btn3Click()
    {
        btn3 = true;
        Connect();
    }
}

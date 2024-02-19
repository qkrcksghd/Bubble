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

    // 게임 실행과 동시에 마스터 서버 접속 시도
    private void Start()
    {
        btn1 = false;
        btn2 = false;
        btn3 = false;
        //접속에 필요한 정보 (게임 버전) 설정
        PhotonNetwork.GameVersion = this.gameVersion;
        //설정한 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();


        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false;
        this.connectionInfoText.text = "마스터 서버에 접속중...";
    }

    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        this.map1joinButton.interactable = true;
        this.map2joinButton.interactable = true;
        this.map3joinButton.interactable = true;
        this.connectionInfoText.text = "온라인 : 마스터 서버와 연결 됨";
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false;
        this.connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도중... ";
        //설정한 정보로 마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // 룸 접속 시도
    public void Connect()
    {
        // 중복 접속 막기
        this.map1joinButton.interactable = false;
        this.map2joinButton.interactable = false;
        this.map3joinButton.interactable = false; ;

        // 마스터 서버에 접속 중이라면
        if (PhotonNetwork.IsConnected)
        {

            //룸에 접속한다.
            this.connectionInfoText.text = "룸에 접속....";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            this.connectionInfoText.text = "오프라인 : 마스터 서버와 연결 끊킴 \n 다시 접속 시도합니다.";
            //설정한 정보로 마스터 서버 접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        this.connectionInfoText.text = "빈 방 없음, 새로운방 생성...";
        //최대 인원을 4명으로 설정 + 방을 만듦
        //방이름 , 4명 설정
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });

    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        this.connectionInfoText.text = "방 참가 성공!";

        if (btn1 == true)
        {
            //모든 룸 참가자가 지정해둔 씬을 로드하게 함
            PhotonNetwork.LoadLevel("01_Map");
        }
        if (btn2 == true)
        {
            //모든 룸 참가자가 지정해둔 씬을 로드하게 함
            PhotonNetwork.LoadLevel("02_Map");
        }
        if (btn3 == true)
        {
            //모든 룸 참가자가 지정해둔 씬을 로드하게 함
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

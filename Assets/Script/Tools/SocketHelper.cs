 
using System.Collections.Generic;
using UnityEngine;
using WWBK;
using XLua;
public class SocketHelper : MonoBehaviour
{
    public static SocketHelper instance;

    private int sendSum;
    
    public delegate void ReciveDataHandler(string[] v);
    public event ReciveDataHandler reciveEvent;

    public TcpSocketClient _socket;
    private Queue<string> recvQueue;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        recvQueue = new Queue<string>();
    }

    public static SocketHelper GetInstance()
    {
        return instance;
    }

[LuaCallCSharp]
    public void ConnectSocket(string host, int port)
    {
        CloseSocket();

        _socket = new TcpSocketClient(host, port);
        _socket.stateChanged = SocketStateChangedHandler;
        _socket.processBytesHandler = SocketReceiveHandler;
        _socket.errorFunc = SocketErrorHandler;
        _socket.Connect();
    }

    private void SocketErrorHandler(string v)
    {

    }

    private void SocketReceiveHandler(byte[] bytes)
    {
        string templs = System.Text.Encoding.UTF8.GetString(bytes);
        templs = templs.Trim('\0');
        string[] temp = templs.Split('$');
        for (int ii = 0; ii < temp.Length; ii++)
        {
            if (string.IsNullOrEmpty(temp[ii]) == false)
            {
                recvQueue.Enqueue(temp[ii]);
            }
        }
    }

    private void SocketStateChangedHandler(TcpSocketClient.State state)
    {
       // print("state=" + state);
      //  AppBoot.instance.slua.ReceiveFromPvpSocket("socket_state"+"|"+(int)state);

     
    }

    private void Write(string v)
    {
        if(_socket != null)
            _socket.Send(System.Text.Encoding.UTF8.GetBytes(v));
    }

    private void Update()
    {
        while (recvQueue.Count > 0)
            Control_All_Lines();
    }

    void Control_All_Lines()
    {
        string data_receive = recvQueue.Dequeue();
        if (data_receive.Equals(""))
        {
            return;
        }
        string[] arrReceiveData = data_receive.Split('|');


        int msgType;
        if(int.TryParse(arrReceiveData[0], out msgType) == false)
        {
            return;
        }

      

        if (reciveEvent != null)
            reciveEvent.Invoke(arrReceiveData);
        
         //if (msgType < 100)
             LuaBehaviour.sockerSendMsg(data_receive);
           
        
    }

    private void OnDestroy()
    {
        OutGame();
    }

    public void OutGame()
    {
        CloseSocket();
    }

    void CloseSocket()
    {
        if(_socket != null)
        {
            //用temp禁止断线重连
            var temp = _socket;
            _socket = null;
            temp.Close();
        }
    }

     void SendMsg1(string item)
    {
        Write(item + "|" + (sendSum++) + "$");
    }

    public static void SendMsg(PvpMsg type,string value )
    {
        instance.SendMsg1((int)type + "|" + value);
    }
}

public enum PvpMsg
{ 
    login = 1,
    move = 2,
    //PickUpBox = 3,
    logout = 4, 
}
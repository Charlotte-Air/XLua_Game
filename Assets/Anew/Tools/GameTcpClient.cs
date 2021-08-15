 
using System;
using System.Text;

public class GameTcpClient
{
   // public TcpSocketClient tcp;

    public bool isCompress;

    public bool isEncrypt;

    public GameTcpClient(string ip, int port)
    {
        isCompress = true;
        isEncrypt = true;
        
     //   tcp = new TcpSocketClient(ip, port);
        //tcp.processBytesHandler = ProcessHandler;
        //tcp.stateChanged = StateChangedHandler;
        //tcp.errorFunc = ErrorHandler;
        //tcp.Connect();
    }

    //private void ErrorHandler(string v)
    //{
    //    AppBoot.instance.slua.ReceiveFromSocketError(v);
    //}

    //private void StateChangedHandler(TcpSocketClient.State state)
    //{
    //    AppBoot.instance.slua.ReceiveFromSocketState((int)state);
    //}

    public void Send(string json)
    {
        Send(Encoding.UTF8.GetBytes(json));
    }

    private void Send(byte[] buffer)
    {
        //这里不加密了先
        //tcp.Send(Encode(PackageType.PKG_DATA,buffer));
    //    tcp.Send(buffer);
    }

    private void ProcessHandler(byte[] bytes)
    {
        //ProcessBytes(bytes, 0, bytes.Length);
        ProcessMessage(bytes);
    }

    private void ProcessMessage(byte[] bytes)
    {
        //string s = Encoding.UTF8.GetString(Decode(bytes));
        string s = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

      //  AppBoot.instance.slua.ReceiveFromSocket(s);

        //UnityEngine.Debug.Log("GameTpc Receive: " + s);

        //SLua.LuaTable net = SLua.LuaSvr.mainState.getTable("Net");
        //net.invoke("Receive", s);

    }

    public void Close()
    {
        //tcp.Close();
        //tcp = null;
    }


    const int HEADER_LENGTH = 5;

    public enum PackageType
    {
        PKG_HEARTBEAT,
        PKG_DATA,
        PKG_KICK,
    }

    private byte[] Encode(PackageType type, byte[] body)
    {
        int length = HEADER_LENGTH;

        byte[] data = body;
        if (body != null)
        {
            if (isCompress)
                data = ZlibMgr.compressBytes(body);
            if (isEncrypt)
            {
                data = AES.AESEncrypt(data);
            }
            length += data.Length;
        }

        byte[] buf = new byte[length];

        int index = 0;
        buf[index++] = Convert.ToByte(1);
        buf[index++] = Convert.ToByte(data.Length >> 24 & 0xFF);
        buf[index++] = Convert.ToByte(data.Length >> 16 & 0xFF);
        buf[index++] = Convert.ToByte(data.Length >> 8 & 0xFF);
        buf[index++] = Convert.ToByte(data.Length & 0xFF);

        while (index < length)
        {
            buf[index] = data[index - HEADER_LENGTH];
            index++;
        }

        return buf;
    }

    public byte[] Decode(byte[] buf)
    {
        byte[] body = new byte[buf.Length - HEADER_LENGTH];

        for (int i = 0; i < body.Length; i++)
        {
            body[i] = buf[i + HEADER_LENGTH];
        }

        byte[] data = body;
        if (isEncrypt)
            data = AES.AESDecrypt(body);
        if (isCompress)
            data = ZlibMgr.deCompressBytes(data);
        return data;
        //return new Package(type, body);
    }

    enum TransportState
    {
        ReadHead,
        ReadBody,
    }
    TransportState transportState = TransportState.ReadHead;
    int headBufferOffset = 0;
    byte[] headBuffer = new byte[HEADER_LENGTH];
    byte[] msgBuffer;
    int msgBufferOffset = 0;
    int pkgLength = 0;


    void ProcessBytes(byte[] bytes, int offset, int limit)
    {
        if (this.transportState == TransportState.ReadHead)
        {
            ReadHead(bytes, offset, limit);
        }
        else if (this.transportState == TransportState.ReadBody)
        {
            ReadBody(bytes, offset, limit);
        }

    }

    bool ReadHead(byte[] bytes, int offset, int limit)
    {
        int length = limit - offset;
        int headNum = HEADER_LENGTH - headBufferOffset;

        if (length >= headNum)
        {
            WriteBytes(bytes, offset, headNum, headBufferOffset, headBuffer);
            pkgLength = (headBuffer[1] << 24) + (headBuffer[2] << 16) + (headBuffer[3] << 8) + headBuffer[4];

            msgBuffer = new byte[HEADER_LENGTH + pkgLength];
            WriteBytes(headBuffer, 0, HEADER_LENGTH, msgBuffer);
            offset += headNum;

            msgBufferOffset = HEADER_LENGTH;
            transportState = TransportState.ReadBody;
            if (offset <= limit)
                ProcessBytes(bytes, offset, limit);

            return true;
        }
        else
        {
            WriteBytes(bytes, offset, length, headBufferOffset, headBuffer);
            headBufferOffset += length;
            return false;
        }
    }

    void ReadBody(byte[] bytes, int offset, int limit)
    {
        int length = pkgLength + HEADER_LENGTH - msgBufferOffset;
        if ((offset + length) <= limit)
        {
            WriteBytes(bytes, offset, length, msgBufferOffset, msgBuffer);
            offset += length;

            ProcessMessage(msgBuffer);

            headBufferOffset = 0;
            msgBufferOffset = 0;
            pkgLength = 0;

            transportState = TransportState.ReadHead;
            if (offset < limit)
                ProcessBytes(bytes, offset, limit);
        }
        else
        {
            WriteBytes(bytes, offset, limit - offset, msgBufferOffset, msgBuffer);
            msgBufferOffset += limit - offset;
            transportState = TransportState.ReadBody;
        }
    }

    void WriteBytes(byte[] source, int sourceOffset, int length, byte[] target)
    {
        WriteBytes(source, sourceOffset, length, 0, target);
    }

    void WriteBytes(byte[] source, int sourceOffset, int length, int targetOffset, byte[] target)
    {
        for (int i = 0; i < length; i++)
        {
            target[targetOffset + i] = source[sourceOffset + i];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Sound_Track_Win
{
    namespace NetworkAudio
    {
        class ProbeData
        {
            public string Key { get; set; }
            public int StreamPort { get; set; }
            public int ByteLength
            {
                get
                {
                    List<byte> data = new List<byte>();
                    data.AddRange(Encoding.UTF8.GetBytes(Key));
                    data.AddRange(BitConverter.GetBytes(StreamPort));
                    return data.Count;
                }
            }

            public ProbeData()
            {
                Key = "";
                StreamPort = 0;
            }

            public ProbeData(byte[] data) { fromBytes(data); }

            public ProbeData(int port)
            {
                Key = "soundtrack";
                StreamPort = port;
            }

            public bool IsGoodData { get { return Key == "soundtrack"; } }

            public byte[] toBytes()
            {
                List<byte> data = new List<byte>();
                data.AddRange(Encoding.UTF8.GetBytes(Key));
                data.AddRange(BitConverter.GetBytes(StreamPort));
                return data.ToArray();
            }

            public void fromBytes(byte[] data)
            {
                try
                {
                    Key = Encoding.UTF8.GetString(data, 0, 10);
                    StreamPort = BitConverter.ToInt32(data, 10);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    Key = "";
                    StreamPort = 0;
                }
            }
        }

        class DeviceData
        {
            public string Key { get; set; }
            public deviceType ThisDevice { get; set; }
            public int StreamPort { get; set; }
            public int UpdatePort { get; set; }
            public string DeviceName { get; set; }
            public int ByteLength
            {
                get
                {
                    List<byte> data = new List<byte>();
                    data.AddRange(Encoding.UTF8.GetBytes(Key));
                    data.Add((byte)ThisDevice);
                    data.AddRange(BitConverter.GetBytes(StreamPort));
                    data.AddRange(BitConverter.GetBytes(UpdatePort));
                    data.AddRange(BitConverter.GetBytes(DeviceName.Length));
                    return data.Count + 255;
                }
            }
            
            public enum deviceType
            {
                unknown,
                dedicatedOutput,
                smartOutput,
                server
            }

            public DeviceData()
            {
                Key = "";
                ThisDevice = deviceType.unknown;
                StreamPort = 0;
                UpdatePort = 0;
                DeviceName = "";
            }
            public DeviceData(deviceType device, int streamPort, int updatePort, string deviceName)
            {
                Key = "soundtrack";
                ThisDevice = device;
                StreamPort = streamPort;
                UpdatePort = updatePort;
                DeviceName = deviceName;
            }
            public DeviceData(byte[] data) { fromBytes(data); }

            public byte[] toBytes()
            {
                if (DeviceName.Length < 255) { DeviceName = DeviceName.PadRight(255); }
                else { DeviceName = DeviceName.Substring(0, 255); }

                List<byte> data = new List<byte>();
                data.AddRange(Encoding.UTF8.GetBytes(Key));
                data.Add((byte)ThisDevice);
                data.AddRange(BitConverter.GetBytes(StreamPort));
                data.AddRange(BitConverter.GetBytes(UpdatePort));
                data.AddRange(Encoding.UTF8.GetBytes(DeviceName));
                return data.ToArray();
            }

            public void fromBytes(byte[] data)
            {
                try
                {
                    Key = Encoding.UTF8.GetString(data, 0, 10);
                    ThisDevice = (deviceType)data[10];
                    StreamPort = BitConverter.ToInt32(data, 11);
                    UpdatePort = BitConverter.ToInt32(data, 15);
                    DeviceName = Encoding.UTF8.GetString(data, 24, 255);
                }
                catch
                {
                    /*Key = "";
                    ThisDevice = deviceType.unknown;
                    StreamPort = 0;
                    UpdatePort = 0;
                    DeviceName = "";*/
                }
            }

            public void setValues(deviceType device, int streamPort, int updatePort, string deviceName)
            {
                Key = "soundtrack";
                ThisDevice = device;
                StreamPort = streamPort;
                UpdatePort = updatePort;
                DeviceName = deviceName;
            }

            public bool IsGoodData { get { return Key == "soundtrack"; } }

        }

        class AudioReceiver
        {
            Socket streamSocket;
            Socket multicastSocketR;
            Socket messageSocket;
            MulticastOption multicast;
            IPAddress multicastIP = IPAddress.Parse("239.205.205.205");
            IPAddress serverIPAd;

            int serverComPort;
            int serverStreamPort;
            int multicastPortT = 2249;
            int multicastPortR = 2250;
            int streamPort = 2251;
            //int updatePort = 2252;

            string deviceName { get; set; }
            public bool connectedToServer { get; } = false;
            public bool receivingStream { get; } = false;

            byte[] multicastDataR = new byte[14];

            public String serverIP
            {
                get
                {
                    if (connectedToServer)
                    {
                        return serverIP.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }

            }

            public AudioReceiver(string name = "")
            {
                deviceName = name;

                streamSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                multicastSocketR = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                messageSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                multicast = new MulticastOption(multicastIP);


                try
                {
                    EndPoint localEP = (EndPoint)new IPEndPoint(IPAddress.Any, multicastPortR);
                    multicastSocketR.Bind(localEP);
                    multicastSocketR.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, multicast);
                    EndPoint multicastEP = (EndPoint)new IPEndPoint(multicastIP, multicastPortR);
                    multicastSocketR.BeginReceiveFrom(multicastDataR, 0, multicastDataR.Length, SocketFlags.None, ref multicastEP, new AsyncCallback(ReceivedMulticastMessage), null);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }

            int PollServer()
            {
                return 0;
            }

            void ReceivedMulticastMessage(IAsyncResult result)
            {
                EndPoint serverEP = new IPEndPoint(IPAddress.Any, 0);

                multicastSocketR.EndReceiveFrom(result, ref serverEP);

                IPEndPoint serverIPEP = (IPEndPoint)serverEP;

                ProbeData data = new ProbeData(multicastDataR);

                if (data.IsGoodData)
                {
                    MessageBox.Show("Received good data!");
                    serverIPAd = serverIPEP.Address;
                    serverStreamPort = data.StreamPort;
                }
                else
                {
                    MessageBox.Show("Received bad data");
                }
            }
        }

        class AudioServer
        {
            Socket streamSocket;
            Socket multicastSocketT;
            Socket messageSocket;
            MulticastOption multicast;
            IPAddress multicastIP = IPAddress.Parse("239.205.205.205");
            IPAddress serverIPAd;

            Thread serverWaitTask;
            Thread respondTask;

            int serverComPort;
            int serverStreamPort;
            int multicastPortT = 2249;
            int multicastPortR = 2250;
            int streamPort = 2251;
            //int updatePort = 2252;

            string deviceName { get; set; }
            public bool connectedToServer { get; } = false;
            public bool receivingStream { get; } = false;

            public String serverIP
            {
                get
                {
                    if (connectedToServer)
                    {
                        return serverIP.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }

            }

            public AudioServer(string name = "")
            {
                deviceName = name;

                UdpClient test = new UdpClient();

                streamSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                multicastSocketT = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                messageSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                multicast = new MulticastOption(multicastIP);

                try
                {
                    EndPoint localEP = (EndPoint)new IPEndPoint(IPAddress.Any, multicastPortT);
                    multicastSocketT.Bind(localEP);
                    multicastSocketT.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, multicast);
                }
                catch
                {

                }

            }

            public void Send()
            {
                EndPoint multicastEP = (EndPoint)new IPEndPoint(multicastIP, multicastPortR);

                ProbeData testData = new ProbeData(streamPort);
                byte[] message = testData.toBytes();
                multicastSocketT.Connect(multicastEP);
                multicastSocketT.Send(message, message.Length, SocketFlags.None);
            }

        }
    }
}

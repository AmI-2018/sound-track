using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            public ProbeData()
            {
                Key = "";
                StreamPort = 0;
            }

            public ProbeData(byte[] data)
            {
                try
                {
                    Key = Encoding.UTF8.GetString(data, 0, 10);
                    StreamPort = BitConverter.ToInt32(data, 11);
                }
                catch
                {
                    Key = "";
                    StreamPort = 0;
                }
            }

            public bool IsGoodData()
            {
                return Key == "soundtrack";
            }
        }

        class OutputResponseData
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
                    data.AddRange(Encoding.UTF8.GetBytes(DeviceName));
                    return data.Count;
                }
            }
            
            public enum deviceType
            {
                unknown,
                dedicatedOutput,
                smartOutput
            }

            public OutputResponseData()
            {
                Key = "";
                ThisDevice = deviceType.unknown;
                StreamPort = 0;
                UpdatePort = 0;
                DeviceName = "";
            }
            public OutputResponseData(deviceType device, int streamPort, int updatePort, string deviceName)
            {
                Key = "soundtrack";
                ThisDevice = device;
                StreamPort = streamPort;
                UpdatePort = updatePort;
                DeviceName = deviceName;
            }
            public OutputResponseData(byte[] data)
            {
                try
                {
                    Key = Encoding.UTF8.GetString(data, 0, 10);
                    ThisDevice = (deviceType)data[11];
                    StreamPort = BitConverter.ToInt32(data, 12);
                    UpdatePort = BitConverter.ToInt32(data, 16);
                    int length = BitConverter.ToInt32(data, 20);
                    DeviceName = Encoding.UTF8.GetString(data, 24, length);
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

            public byte[] toBytes()
            {
                List<byte> data = new List<byte>();
                data.AddRange(Encoding.UTF8.GetBytes(Key));
                data.Add((byte)ThisDevice);
                data.AddRange(BitConverter.GetBytes(StreamPort));
                data.AddRange(BitConverter.GetBytes(UpdatePort));
                data.AddRange(BitConverter.GetBytes(DeviceName.Length));
                data.AddRange(Encoding.UTF8.GetBytes(DeviceName));
                return data.ToArray();
            }

            public bool IsGoodData()
            {
                return Key == "soundtrack";
            }

        }

        class AudioReceiver
        {
            Socket streamSocket;
            Socket multicastSocket;
            Socket messageSocket;
            MulticastOption multicast;
            IPAddress multicastIP = IPAddress.Parse("239.205.205.205");
            IPAddress serverIPAd;

            Task serverWaitTask;
            Task respondTask;

            int serverComPort;
            int serverStreamPort;
            int multicastPort = 2250;
            int streamPort = 2251;
            int updatePort = 2252;

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

            public AudioReceiver(string name = "")
            {
                deviceName = name;

                UdpClient test = new UdpClient();

                streamSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                multicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                messageSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                multicast = new MulticastOption(multicastIP);

                serverWaitTask = new Task(WaitForMulticastMessage);

                try
                {
                    EndPoint multicastEP = (EndPoint)new IPEndPoint(IPAddress.Any, multicastPort);
                    multicastSocket.Bind(multicastEP);
                    multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, multicast);
                    serverWaitTask.Start();
                }
                catch
                {

                }

            }

            void WaitForMulticastMessage()
            {
                byte[] dataReceive = new byte[14];
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                while (!connectedToServer)
                {
                    try
                    {
                        IAsyncResult receive = multicastSocket.BeginReceiveFrom(dataReceive, 0, dataReceive.Length,
                            SocketFlags.None, ref remoteEP, null, null);
                        receive.AsyncWaitHandle.WaitOne();

                        ProbeData receivedProbe = new ProbeData(dataReceive);
                        if (receivedProbe.IsGoodData())
                        {
                            serverComPort = BitConverter.ToInt32(dataReceive, 11);
                            IPEndPoint ipEP = (IPEndPoint)remoteEP;
                            serverIPAd = ipEP.Address;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }

        }
    }
}

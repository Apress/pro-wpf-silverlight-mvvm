using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;

namespace PortChecker.Model
{
    public class PortChecker
    {
        public PortChecker()
        {
            Ports = new ObservableCollection<Port>();
        }

        public ObservableCollection<Port> Ports
        {
            get;
            private set;
        }

        public void ScanPorts(string machineNameOrIPAddress)
        {
            if (!IPAddress.TryParse(machineNameOrIPAddress, out ipAddress))
            {
                // assume machine name
                IPHostEntry hostEntry = Dns.GetHostEntry(machineNameOrIPAddress);
                if (hostEntry.AddressList.Count() > 0)
                {
                    ipAddress = hostEntry.AddressList[0];
                }
            }           

            for (int currentPort = 1; currentPort <= 100; ++currentPort)
            {
                TestPort(currentPort);
            }
        }

        private void TestPort(int currentPort)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ipAddress, currentPort);
                if (socket.Connected)
                {
                    Ports.Add(new Port(currentPort, false));
                }
            }
            catch (SocketException ex)
            {
                Ports.Add(new Port(currentPort, ex.SocketErrorCode == SocketError.ConnectionRefused));
            }
            catch (Exception)
            {
                Ports.Add(new Port(currentPort, null));
            }
            finally
            {
                socket.Close();
            }
        }

        private IPAddress ipAddress;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace KOSELib
{
    public class Packet
    {
        Thread Channel;

        int Port ;

        public Packet( bool server )
        {
            Channel = new Thread(new ThreadStart(Parsing));
            Channel.Start();
            Channel.Priority = ThreadPriority.Highest;
            if (server)
                Port = Global.ServerPort;
            else
                Port = Global.ClientPort;
        }

        private void Parsing()
        {
            TcpListener PortReader = new TcpListener(Port);
            byte[] read_Data = new byte[255];

            while (true)
            {
                read_Data = new byte[50000];

                PortReader.Start();

                Socket soc = PortReader.AcceptSocket();
                soc.Receive(read_Data, read_Data.Length, 0);
                
                PortReader.Stop();

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOSELib
{
    public static class Global
    {
        public const bool isClient = true;
        public const bool isServer = false;

        public static void SetShort(ref byte[] send_buff, Int16 tem, ref int send_index) 
        {
            byte[] NewByte = { (byte)(tem & 0x00FF), (byte)((tem & 0xFF00) >> 8) };

            for (int i = 0; i < 2; i++)
                send_buff[++send_index] = NewByte[i];

        }

        public static short GetShort(byte[] send_buff, ref int send_index) 
        {
            short tmp = Convert.ToInt16(send_buff[++send_index]
                              | ((send_buff[++send_index]) << 8));

            return tmp;
        }

        public static void SetString(ref byte[] send_buff, byte[] text, int text_len, ref int send_index) 
        {
            for (int i = 0; i < text_len; i++)
                send_buff[++send_index] = text[i];
        }
        
        public static void GetString(byte[] get_buff, ref byte[] text_buff, int text_len, ref int get_index) 
        {
            int text_index = -1;
            for (int i = 0; i < text_len; i++)
                text_buff[++text_index] = get_buff[++get_index];
        }
    }
}

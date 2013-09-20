using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOSELib
{
    public static class ChatPacket
    {
        // Text i şifrele 
        private static void IsCrypto(ref string text)
        {
            string OldText = text;
            text = "";

            int upper = 3;
            foreach (char isn in OldText.ToCharArray())
            {
                string chr = "";
                for (int i = 0; i < 3; i++)
                {
                    chr = Convert.ToString(isn + upper);
                }
                text += chr;
                upper++;
            }

        }
        // Şifreyi çöz
        private static void DeCrypto(ref string text)
        {
            string OldText = text;
            text = "";

            int upper = 3;
            foreach (char isn in OldText.ToCharArray())
            {
                string chr = "";
                for (int i = 0; i < 3; i++)
                {
                    chr = Convert.ToString(isn - upper);
                }
                text += chr;
                upper++;
            }
        }

        // Texti byte yap
        private static byte[] TextChBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
        // Byte Text yap
        private static string ByteChText(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        // Yazıyı pakete ekle
        public static void PacketAddText(ref byte[] pBuf, string text, ref int index)
        {
            IsCrypto(ref text);

            Global.SetShort(ref pBuf, (short)text.Length,ref index);

            byte[] chat = TextChBytes(text);

            Global.SetString(ref pBuf, chat, text.Length, ref index);
        }

        // Yazıyı paketten kaldır
        public static string PacketReadText(byte[] pBuf, ref int index)
        {
            byte[] chat = null;

            Global.GetString(pBuf, ref chat, Global.GetShort(pBuf, ref index), ref index);

            string text = ByteChText(chat);

            DeCrypto(ref text);
            
            return text;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BBC
{
    public class Block
    {
        Times timeStamp = new Times();
        private string PreviousHash { get; set; }
        private string Data { get; set; }
        public string BlockHash { get; set; }

        public Block(string previousHash, string data)
        {
            PreviousHash = previousHash;
            Data = timeStamp.PrintTimeStamp() + " " + data;

            string contens = Hashing(data).ToString();

            BlockHash = Hashing(contens + previousHash);

        }
        public string currentblockData()
        {
            return Data;
        }
        public string CurrentBlockHash()
        {
            return BlockHash;
        }

        public string Hashing(string mess1)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] MessageHashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(mess1.ToString()));
            string result = BitConverter.ToString(MessageHashed).Replace("-", "");
            return result;
        }



    }

}


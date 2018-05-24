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
        string Time { get; set; }
        public int index { get; set; }
        public string PreviousHash { get; set; }
        private string data { get; set; }
        public string currentHash { get; set; }

        public Block(int index , string data ,  string PreviousHash)
        {
            this.index = index;
            this.data = data;
            this.PreviousHash = PreviousHash;
            this.currentHash = this.CalcHash();
            this.Time = timeStamp.PrintTimeStamp();

        }
        public string CalcHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] messagehashed = sha256.ComputeHash(Encoding.UTF8.GetBytes((this.index + this.PreviousHash + this.Time)));
            return BitConverter.ToString(messagehashed);
        }

        public string currentblockData()
        {
            return data;
        }

        public string PrevHash()
        {
            return PreviousHash;
        }
        public string CurrentBlockHash()
        {
            return currentHash;
        }

/* 
         ----->the old block constructor

        Times timeStamp = new Times();
        public string PreviousHash { get; set; }
        private string Data { get; set; }
        public string BlockHash { get; set; }

        public Block(string previousHash, string data)
        {
            PreviousHash = previousHash;
            Data = timeStamp.PrintTimeStamp() + " " + data;

            string contens = Hashing(data).ToString();

            BlockHash = Hashing(contens + previousHash);

        }

        -----> old hash function
        public string Hashing(string mess1)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] MessageHashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(mess1.ToString()));
            string result = BitConverter.ToString(MessageHashed).Replace("-", "");
            return result;
        }
*/



    }

}


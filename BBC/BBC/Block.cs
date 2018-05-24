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
        public string time { get; set; }
        public int index { get; set; }
        public string previoushash { get; set; }
        private string data { get; set; }
        public string currenthash { get; set; }

        public Block(int index , string data ,  string previousHash , string time)
        {
            this.index = index;
            this.data = data;
            this.previoushash = previousHash;
            this.currenthash = this.CalcHash();
            this.time = time;

        }
        public string CalcHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] messagehashed = sha256.ComputeHash(Encoding.UTF8.GetBytes((this.index + this.previoushash)));
            return BitConverter.ToString(messagehashed);
        }

        public string CurrentBlockData()
        {
            return data;
        }
        public string PreviousHash()
        {
            return previoushash;
        }
        public string CurrentBlockHash()
        {
            return currenthash;
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


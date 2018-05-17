﻿using System;
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
        private string previousHash { get; set; }
        private string data { get; set; }
        public string blockHash { get; set; }

        public Block(string previousHash, string data)
        {
            this.previousHash = previousHash;
            this.data = timeStamp.PrintTimeStamp() + " " + data;

            string contens = Hashing(data).ToString();

            this.blockHash = Hashing(contens + previousHash);

        }
        public string currentblockData()
        {
            return data;
        }
        public string CurrentBlockHash()
        {
            return blockHash;
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

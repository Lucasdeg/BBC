using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace testingkeyfunction
{
    class Block
    {
        private string previousHash { get; set; }
        public string data { get; set; }
        public string blockHash { get; set; }

        public Block(string previousHash, string data)
        {
            this.previousHash = previousHash;
            this.data = data;

            string contens = Hashing(data).ToString();

            this.blockHash = Hashing(contens + previousHash);

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


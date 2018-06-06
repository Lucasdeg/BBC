using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC
{
    class Transaction
    {
        public string transactionId;
        public User sender;
        public User recipient;
        public string message;
        public byte[] signature;

        private static int sequence = 0;

        public Transaction(User sender, User recipient, string ipfsHash)
        {
            this.sender = sender;
            this.recipient = recipient;
            this.message = ipfsHash;
        }

        public void generateSignature(string privateKey)
        {
            string data = null;
        }
    }
}

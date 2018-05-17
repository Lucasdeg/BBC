using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC
{
    class Blockchain
    {
        List<Block> chain = new List<Block>();

        public Blockchain()
        {
            this.chain = 
        }


        public  Block Genblock()
        {
            return new Block("0", "This is the gen");
        }
        public Block GetLast()
        {
            return chain[chain.Count-1];
        }
        public Block Addblock(Block newblock)
        {
            newblock.previousHash = GetLast().blockHash;
            newblock.blockHash = newblock.CurrentBlockHash();
            return newblock;
        }

    }
}

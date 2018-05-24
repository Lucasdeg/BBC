using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC

{

    public class Blockchain
    {

        List<Block> chain = new List<Block>();
        public Blockchain()
        {
            chain.Insert(0,Creategen());
        }
            
        

        public Block Creategen()
        {
            return new Block("0", "this is the gen");   
        }

        public Block LatestBlock()
        {
            Console.WriteLine(this.chain[this.chain.Count-1].currentblockData());
            //Console.WriteLine("this is the current hash:"+ this.chain[this.chain.Count - 1].CurrentBlockHash());
            //Console.WriteLine("this is the prev has    :" + this.chain[this.chain.Count - 1].PrevHash());
            return this.chain[this.chain.Count - 1];
            
        }

        public void AddBlock(Block NewBlock)
        {
            NewBlock.PreviousHash = NewBlock.PreviousHash;
            this.chain.Add(NewBlock);
        } 


        /*
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
        */

    }
}

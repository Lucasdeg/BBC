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
            return new Block(0, "this is the gen","");   
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

        public bool IsChainValid()
        {
            //return true;
            for (int i = 1; i < this.chain.Count; i++)
            {
                Block currentblock = this.chain[i];
                Block previousblock = this.chain[i - 1];
                if (currentblock.PrevHash() != previousblock.CurrentBlockHash())
                {
                    Console.WriteLine("the hash of the previous block does not match the pervious hash of this block");
                    return false;
                }
                /*if (currentblock.BlockHash != currentblock.Hashing(currentblock.PrevHash() )) 
                {
                    Console.WriteLine("The currentblock hash does not have the same hash as the calculated hash");
                    return false;
                }
                */
            }
            Console.WriteLine("The blockchain is valid");
            return true;
        }
    }
}

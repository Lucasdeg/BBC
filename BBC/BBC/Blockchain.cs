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
            
        
        //creating the genesis block
        public Block Creategen()
        {
            return new Block(0, "this is the gen","", "24/5/2018");   
        }

        //requesting the latesblock in the blockchain
        public Block LatestBlock()
        {
            //Console.WriteLine(this.chain[this.chain.Count - 1 ].CurrentBlockData());
            return this.chain[this.chain.Count - 1];
            
        }

        //printing everthing in the block
        public void CurrentBlockPrinter()
        {
            Console.WriteLine("Index:........." + this.chain[this.chain.Count - 1].index);
            Console.WriteLine("Timestamp:....." + this.chain[this.chain.Count - 1].time);
            Console.WriteLine("Currentdata:..." + this.chain[this.chain.Count - 1].CurrentBlockData());
            Console.WriteLine("CurrentHash:..." + this.chain[this.chain.Count - 1].CurrentBlockHash());
            Console.WriteLine("PreviousHash:.." +this.chain[this.chain.Count - 1].PreviousHash());
        }
    
        //a function with the posibility to add a new block;
        public void AddBlock(Block NewBlock)
        {
            NewBlock.previoushash = NewBlock.previoushash;
            this.chain.Add(NewBlock);
        } 

        public int BlockchainLength()
        {
            int counter = 0;
            for (int i = 1; i < this.chain.Count; i++)
            {
                counter++;
            }
            Console.WriteLine(counter);
            return counter;
        }

        //a function to check the blockchain valid
        public bool IsChainValid()
        {
            //return true;
            for (int i = 1; i < this.chain.Count; i++)
            {
                Block currentblock = this.chain[i];
                Block previousblock = this.chain[i - 1];
                if (currentblock.PreviousHash() != previousblock.CurrentBlockHash())
                {
                    Console.WriteLine("the hash of the previous block does not match the pervious hash of this block");
                    return false;
                }
                if(currentblock.index <= previousblock.index)
                {
                    Console.WriteLine("the current index cannot be the same or smaller as one of the previous ones");
                    return false;
                }
                
                if (currentblock.CurrentBlockHash() != currentblock.CalcHash()) 
                {
                    Console.WriteLine("The currentblock hash does not have the same hash as the calculated hash");
                    return false;
                }
            }
            Console.WriteLine("The blockchain is valid");
            return true;
        }
    }
}

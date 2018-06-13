using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC

{

    public class Blockchain
    {
        LinkedList<Block> chain = new LinkedList<Block>();

        LinkedList<Transaction> currentTransactions = new LinkedList<Transaction>();


        public Blockchain()
        {
            chain.AddLast(Creategen());
        }


        /*
        public int newTransaction(string sender, string recipient, string ipfsHash)
        {

            currentTransactions.AddLast(transaction);
            return this.chain.Last.Value.index + 1;
        }
        */

        //creating the genesis block
        public Block Creategen()
        {
            return new Block(0, "this is the gen","", "24/5/2018");   
        }

        //requesting the latesblock in the blockchain
        public Block LatestBlock()
        {
            //Console.WriteLine(this.chain[this.chain.Count - 1 ].CurrentBlockData());
            return chain.Last.Value;
            
        }
        public int LatestBlockIndex()
        {
            return chain.Last.Value.index;
        }
        public void AllBlocks()
        {
            foreach (var data in chain)
            {
                Console.WriteLine("Block " + data.index + " message");
                Console.WriteLine( data.CurrentBlockData());
                Console.WriteLine("----------------------");
            }
            ;
        }

        //printing everthing in the block
        public void CurrentBlockPrinter()
        {
            Console.WriteLine("Index:........." + chain.Last.Value.index);
            Console.WriteLine("Timestamp:....." + chain.Last.Value.time);
            Console.WriteLine("Currentdata:..." + chain.Last.Value.CurrentBlockData());
            Console.WriteLine("CurrentHash:..." + chain.Last.Value.CurrentBlockHash());
            Console.WriteLine("PreviousHash:.." + chain.Last.Value.PreviousHash());
        }
    
        //a function with the posibility to add a new block;
        public void AddBlock(Block NewBlock)
        {
            NewBlock.previoushash = NewBlock.previoushash;
            this.chain.AddLast(NewBlock);
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
                Block currentblock = chain.Where(x => x.index == i).First();
                Block previousblock = chain.Where(x => x.index == i-1).First();
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

using System;



namespace BBC
{
    public class BlockFactory : IFactory<Block, string>
    {
        int IndexOfCurrentBlock = 0;

        Block LastBlock;

        public BlockFactory()
        {

        }

        public Block Generate(string data)
        {
            Block block;
            if (LastBlock == null)
            {
                block = new Block(0,string.Empty, data);
            }
            else
            {
                block = new Block(IndexOfCurrentBlock,LastBlock.CurrentBlockHash(), data);
            }
            IndexOfCurrentBlock++;
            LastBlock = block;

            return block;
        }
    }
}
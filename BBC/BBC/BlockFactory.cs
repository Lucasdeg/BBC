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
                block = new Block(string.Empty, data);
            }
            else
            {
                block = new Block(LastBlock.blockHash, data);
            }
            IndexOfCurrentBlock++;
            LastBlock = block;

            return block;
        }
    }
}
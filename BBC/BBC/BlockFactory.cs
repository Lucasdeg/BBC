using System;
using BBC;




namespace BBC
{
    public class BlockFactory
    {
        int IndexOfCurrentBlock = 0;

        Block LastBlock;

        public BlockFactory()
        {

        }

        public Block GenerateBlock()
        {
            if (LastBlock == null)
            {
                return new Block();
            }
            else
            {

            }
        }
    }
}
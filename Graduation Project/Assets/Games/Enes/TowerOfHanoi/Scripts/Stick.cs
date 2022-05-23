using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float blockPosX;

        private float blockPosY = -2.54f;
        private float yIntervalPerBlock = 0.7f;

        [HideInInspector] public int blockCount;
        [HideInInspector] public Block topBlock;
        [HideInInspector] public List<Block> blocks;

        private void Start()
        {
            blocks = new List<Block>();
            FindBlocks(); 
            FindTopBlock();
        }

        private void FindBlocks()
        {
            Collider2D[] targetObject = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.2f, 6f), 0f);
            
            foreach (Collider2D collider in targetObject)
            {
                if (collider.TryGetComponent<Block>(out Block block))
                {
                    blocks.Add(block);
                }
            }

            blockCount = blocks.Count;
        }

        private void FindTopBlock()
        {
            if (blocks.Count > 0)
            {
                Block topB = blocks[0];

                foreach (Block block in blocks)
                {
                    if (block.blockData.size < topB.blockData.size)
                    {
                        topB = block;
                    }
                    else
                    {
                        block.blockData.isOnAbove = false;
                    }
                }

                topBlock = topB;
                topBlock.blockData.isOnAbove = true;
            }
            else
            {
                topBlock = null;
            }
        }

        public void RemoveBlock(Block block)
        {
            blocks.Remove(block);
            blockCount = blocks.Count;
            FindTopBlock();
        }

        public void AddBlock(Block block)
        {
            blocks.Add(block);
            blockCount = blocks.Count;
            FindTopBlock();

            Vector3 blockPos = new Vector3(blockPosX, blockPosY + (blockCount - 1) * yIntervalPerBlock, -1);
            block.transform.position = blockPos;
        }
    }
}
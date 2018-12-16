using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Blockchain
{
    public class Block
    {
        public int index;
        public string time;
        public string data;
        public string CurrentHash;
        public string PreviousHash;
        public Block(string data)
        {
            time = Convert.ToString(DateTime.Now);
            this.data = data;
        }
    }
    public class Blockchain
    {
        public List<Block> blocks = new List<Block>();
        private string lastHash;
        private string firstHash;
        public int count;
        private int CountOfZeros;
        public Blockchain(string data, int CountOfZeros)
        {
            Block firstblock = new Block(data);
            firstblock.CurrentHash = "00000";
            blocks.Add(firstblock);
            firstHash = firstblock.CurrentHash;
            firstblock.index = blocks.IndexOf(firstblock);
            lastHash = firstblock.CurrentHash;
            count = 1;
            this.CountOfZeros = CountOfZeros;
        }
        private string Hash(string time, int index, string data, string previousHash, string nonce)
        {
            string result;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] check = md5.ComputeHash(Encoding.UTF8.GetBytes(time + index + data + previousHash + nonce));
            result = BitConverter.ToString(check).Replace("-", String.Empty);
            for (int i = result.Length - 1; i > result.Length - 1 - CountOfZeros; i--)
            {
                if (result[i] != '0')
                    return Hash(time, index, data, previousHash, nonce + "aa");
            }
            return result;
        }
        private string HashOfBlock(Block block)
        {
            return Hash(block.time, block.index, block.data, block.PreviousHash, "q");
        }
        public void AddBlock(string data)
        {
            Block block = new Block(data);
            block.PreviousHash = lastHash;
            block.CurrentHash = Hash(block.time, count, data, lastHash, "q");
            lastHash = block.CurrentHash;
            block.index = count;
            count++;
            blocks.Add(block);
        }
        public Block FindBlock(string Hash)
        {
            foreach(Block a in blocks)
            {
                if (a.CurrentHash == Hash)
                    return a;
            }
            return null;
        }
        public void GetAllHashes()
        {
            foreach(Block a in blocks)
            {
                Console.WriteLine(a.CurrentHash);
            }
        }
        public bool CheckChain()
        {
            for(int i = 0; i < blocks.Count - 1; i++)
            {
                if (blocks[i].CurrentHash != blocks[i + 1].PreviousHash)
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain myblocks = new Blockchain("Igor let me 10 bitcoins", 2);
            myblocks.AddBlock("Igor let u 1000 bitcoins");
            myblocks.AddBlock("I spent all bitcoins");
            myblocks.AddBlock("Oups, I'm late with this task");
            myblocks.GetAllHashes();
           
        }
    }
}

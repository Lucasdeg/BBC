﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace BBC
{
    class Program
    {
        static HttpListener _httpListener = new HttpListener();

        static void ResponseThread()
        {
            while (true)
            {
                HttpListenerContext context = _httpListener.GetContext(); // get a context
                                                                          // Now, you'll find the request URL in context.Request.Url
                byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
                "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 5000!</em></body></html>"); // get the bytes to response
                context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
                Console.WriteLine("Response given to a request.");
            }
        }

        static void Main(string[] args)
        {
            Times timestamp = new Times();
            //creating the blockchain
            Blockchain BBC = new Blockchain();
            //adding blocks
            BBC.AddBlock(new Block(1, "Hello This is a test for the first block in the chain", BBC.LatestBlock().CurrentBlockHash(), "20-5-2018...12:00"));
            BBC.AddBlock(new Block(2, "Hi what a nice first message!", BBC.LatestBlock().CurrentBlockHash(), "24-5-2018...9:10"));
            BBC.AddBlock(new Block(3, "Data is send to the chain", BBC.LatestBlock().CurrentBlockHash(), "30-5-2018...10:20"));
            BBC.AddBlock(new Block(4, "What a time to be alive", BBC.LatestBlock().CurrentBlockHash(), timestamp.GetTimestamp(DateTime.Now)));
            BBC.AddBlock(new Block(5, "This block is made in the future", BBC.LatestBlock().CurrentBlockHash(), "32-5-2018...55:55"));

            string BBCJson = JsonConvert.SerializeObject(BBC.AllBlocksData());//.LatestBlock());//.CurrentBlockData());


            //Console.WriteLine(value);

            //List<Block> jsonblock = JsonConvert.DeserializeObject<List<Block>>(BBCJson);
            //MikaBlock.AddBlock(jsonblock);

            /*foreach(Block wow in jsonblock)
            {
                Console.WriteLine("Index: " + wow.index + "\r\n Message: " + wow.CurrentBlockData() + "\r\n currenthash: " + wow.currenthash + "\r\n previoushash: " + wow.previoushash + "\r\n------------");
            }
            */


            //
            // testing private / public key
            // 
            /*string _privatekey = Keys.Encrypt("Let's see..");
            string _decryptedkey = Keys.Decrypt(_privatekey);
            Console.WriteLine(_privatekey);
            Console.WriteLine(_decryptedkey);
            */


            Console.WriteLine("Starting server...");
            _httpListener.Prefixes.Add("http://*:80/"); // add prefix "http://localhost:5000/"
            _httpListener.Start(); // start server (Run application as Administrator!)
            Console.WriteLine("Server started.");
            //Thread _responseThread = new Thread(ResponseThread);
            //_responseThread.Start(); // start the response thread
            
            while (true)
            {
                Console.WriteLine("Waiting for a new conection...");
                HttpListenerContext newContext = _httpListener.GetContext();
                HttpListenerRequest newRequest = newContext.Request;


                // test writing data to console instead of browser
                string blockcontents;
                using (Stream receiveStream = newRequest.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        blockcontents = readStream.ReadToEnd();
                    }
                }
                Console.WriteLine(blockcontents);
                // end test
                HttpListenerRequest clientRequest = newContext.Request;
                HttpListenerResponse serverResponse = newContext.Response;

                serverResponse.StatusCode = (int)HttpStatusCode.OK;
                serverResponse.ContentType = "text/html";


                Stream serverResponseOutput = serverResponse.OutputStream;
                serverResponseOutput.Write(Encoding.Default.GetBytes(BBCJson), 0, BBCJson.Length);
                int x = 0;
                Console.WriteLine("Welcome to the BigBlockChain");
                while (x == 0)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("Press [r] to read the blockdata");
                    Console.WriteLine("Press [R] to read the full block");
                    Console.WriteLine("Press [a] to add a block");
                    Console.WriteLine("Press [s] to send the data to the Blockchain");
                    Console.WriteLine("Press [q] to quit,");
                    Console.WriteLine("------------------------------");
                    string s = Console.ReadLine();
                    if (s == "q")
                    {
                        x = 1;
                    }
                    else if (s == "r")
                    {
                        BBC.AllBlocks();
                    }
                    else if (s == "R")
                    {
                        BBC.AllBlocksPrint();
                    }
                    else if (s == "a")
                    {
                        Console.Write("Message>>>");
                        string message = Console.ReadLine();
                        BBC.AddBlock(new Block(BBC.LatestBlockIndex() + 1, message, BBC.LatestBlock().CurrentBlockHash(), timestamp.GetTimestamp(DateTime.Now)));
                        //checking if the blockchain is tampered with
                        BBC.IsChainValid();
                    }
                    else if (s == "s")
                    {
                        
                        string lastBlockJson = JsonConvert.SerializeObject(BBC.LatestBlock().CurrentBlockData());
                        lastBlockJson += "\n";
                        serverResponseOutput.Write(Encoding.Default.GetBytes(lastBlockJson), 0, lastBlockJson.Length);
                        Console.WriteLine("Block send!");
                    }
                }
                
                /*string value2 = JsonConvert.SerializeObject(MikaBlock);//.LatestBlock());//.CurrentBlockData());

                //Console.WriteLine(value);

                List<Block> jsonblock2 = JsonConvert.DeserializeObject<List<Block>>(value);
                //MikaBlock.AddBlock(jsonblock);

                foreach (Block wow in jsonblock)
                {
                    Console.WriteLine("Message: " + wow.CurrentBlockData() + "\r\n currenthash: " + wow.currenthash + "\r\n previoushash: " + wow.previoushash);
                }

                //Console.WriteLine(jsonblock);
                Console.WriteLine("JsonBlock");
                */

            }


            
            

            /*
            Block genblock = new Block("0", "this is the gen block");
            Block block2 = new Block(genblock.CurrentBlockHash(), "mess2");
            Block block3 = new Block(block2.CurrentBlockHash(), "sUkkkaaa");

            BlockFactory factory = new BlockFactory();
            factory.Generate("First Block");
            factory.Generate("Second Block");
            factory.Generate("Third Block");
            
            Console.WriteLine("this is the genblockcode ");
            Console.WriteLine(genblock.currentblockData());
            Console.Write(genblock.CurrentBlockHash());

            Console.WriteLine("this is the second block");
            Console.WriteLine(block2.CurrentBlockHash());
            Console.WriteLine(block3.CurrentBlockHash());
            
            Console.ReadKey();
            */
            }
        }
}

            /*
            if ((args.Length == 3) && (args[0].Equals("k")))
            {
                // Generate a new key pair
                Keys(args[1], args[2]);

            }
            else if ((args.Length == 4) && (args[0].Equals("e")))
            {
                // Encrypt a file
                Encrypt(args[1], args[2], args[3]);

            }
            else if ((args.Length == 4) && (args[0].Equals("d")))
            {
                // Decrypt a file
                Decrypt(args[1], args[2], args[3]);
            }
            else
            {
                // Show usage
                Console.WriteLine("Usage:");
                Console.WriteLine("   - New key pair: EncryptDecrypt k public_key_file private_key_file");
                Console.WriteLine("   - Encrypt:      EncryptDecrypt e public_key_file plain_file encrypted_file");
                Console.WriteLine("   - Decrypt:      EncryptDecrypt d private_key_file encrypted_file plain_file");
            }

            // Exit
            Console.WriteLine("\n<< Press any key to continue >>");
            Console.ReadKey();
            return;

        } // Main

        // Generate a new key pair
        static void Keys(string publicKeyFileName, string privateKeyFileName)
        {
            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamWriter publicKeyFile = null;
            StreamWriter privateKeyFile = null;
            string publicKey = "";
            string privateKey = "";

            try
               { 
                // Create a new key pair on target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL
                //cspParams.ProviderName; // CSP name
                cspParams.Flags = CspProviderFlags.UseArchivableKey;
                cspParams.KeyNumber = (int)KeyNumber.Exchange;
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Export public key
                publicKey = rsaProvider.ToXmlString(false);

                // Write public key to file
                publicKeyFile = File.CreateText(publicKeyFileName);
                publicKeyFile.Write(publicKey);

                // Export private/public key pair
                privateKey = rsaProvider.ToXmlString(true);

                // Write private/public key pair to file
                privateKeyFile = File.CreateText(privateKeyFileName);
                privateKeyFile.Write(privateKey);
            }
            catch (Exception ex)
            {
                // Any errors? Show them
                Console.WriteLine("Exception generating a new key pair! More info:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Do some clean up if needed
                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }
                if (privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }
            }

        } // Keys

        // Encrypt a file
        static void Encrypt(string publicKeyFileName, string plainFileName, string encryptedFileName)
        {
            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader publicKeyFile = null;
            StreamReader plainFile = null;
            FileStream encryptedFile = null;
            string publicKeyText = "";
            string plainText = "";
            byte[] plainBytes = null;
            byte[] encryptedBytes = null;

            try
            {
                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL

                //cspParams.ProviderName; // CSP name
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Read public key from file
                publicKeyFile = File.OpenText(publicKeyFileName);
                publicKeyText = publicKeyFile.ReadToEnd();

                // Import public key
                rsaProvider.FromXmlString(publicKeyText);

                // Read plain text from file
                plainFile = File.OpenText(plainFileName);
                plainText = plainFile.ReadToEnd();

                // Encrypt plain text
                plainBytes = Encoding.Unicode.GetBytes(plainText);
                encryptedBytes = rsaProvider.Encrypt(plainBytes, false);

                // Write encrypted text to file
                encryptedFile = File.Create(encryptedFileName);
                encryptedFile.Write(encryptedBytes, 0, encryptedBytes.Length);
            }
            catch (Exception ex)
            {
                // Any errors? Show them
                Console.WriteLine("Exception encrypting file! More info:");
                Console.WriteLine(ex.Message);
            }
            finally     
            {
                // Do some clean up if needed
                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }
                if (plainFile != null)
                {
                    plainFile.Close();
                }
                if (encryptedFile != null)
                {
                    encryptedFile.Close();
                }
            }

        } // Encrypt

        // Decrypt a file
        static void Decrypt(string privateKeyFileName, string encryptedFileName, string plainFileName)
        {
            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader privateKeyFile = null;
            FileStream encryptedFile = null;
            StreamWriter plainFile = null;
            string privateKeyText = "";
            string plainText = "";
            byte[] encryptedBytes = null;
            byte[] plainBytes = null;

            try
            {
                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL

                //cspParams.ProviderName; // CSP name
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                // Read private/public key pair from file
                privateKeyFile = File.OpenText(privateKeyFileName);
                privateKeyText = privateKeyFile.ReadToEnd();

                // Import private/public key pair
                rsaProvider.FromXmlString(privateKeyText);

                // Read encrypted text from file
                encryptedFile = File.OpenRead(encryptedFileName);
                encryptedBytes = new byte[encryptedFile.Length];
                encryptedFile.Read(encryptedBytes, 0, (int)encryptedFile.Length);

                // Decrypt text
                plainBytes = rsaProvider.Decrypt(encryptedBytes, false);

                // Write decrypted text to file
                plainFile = File.CreateText(plainFileName);
                plainText = Encoding.Unicode.GetString(plainBytes);
                plainFile.Write(plainText);
            }

            catch (Exception ex)
            {
                // Any errors? Show them
                Console.WriteLine("Exception decrypting file! More info:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Do some clean up if needed

                if (privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }

                if (encryptedFile != null)
                {
                    encryptedFile.Close();
                }

                if (plainFile != null)
                {
                    plainFile.Close();
                }
            }
        } // Decrypt
    }
}
*/

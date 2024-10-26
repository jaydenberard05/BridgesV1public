using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;
using Cosmos.System;
using Cosmos.Core.Memory;
using Console = System.Console;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers.PCI.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using Cosmos.HAL.Audio;
using IL2CPU.API.Attribs;
using Cosmos.System.Network;
using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4.UDP;
using Cosmos.Core;

///Source Code for the Kernal Commands
namespace BridgesOS
{
    public class Kernel : Sys.Kernel
    {

        
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

        //[ManifestResourceStream(ResourceName = "BridgesOS.welcome.wav")] public static byte[] music;
        /// Before Kernal Starts 
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);


            ///Audio does not work well with VMWARE
            

            /* var mixer = new AudioMixer();
             var audioStream = MemoryAudioStream.FromWave(music);

             var driver = AC97.Initialize(bufferSize: 4096);

             mixer.Streams.Add(audioStream);

             var audioManager = new AudioManager()
             {
                 Stream = mixer,
                 Output = driver
             };
             audioManager.Enable(); */

            ///Networking in Progress
            NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0"); //get network device by name
            IPConfig.Enable(nic, new Address(192, 168, 1, 69), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254)); //enable IPv4 configuration

           
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome Too Bridges OS. Please Type in a command or type help for info" + " _          _     _                 \r\n | |__  _ __(_) __| | __ _  ___  ___ \r\n | '_ \\| '__| |/ _` |/ _` |/ _ \\/ __|\r\n | |_) | |  | | (_| | (_| |  __/\\__ \\\r\n |_.__/|_|  |_|\\__,_|\\__, |\\___||___/\r\n                     |___/           ");
            //Console.WriteLine(NetworkConfiguration.CurrentAddress.ToString());


        }
        /// Start of Kernal     
    
        protected override void Run()
        {
            Console.Write("Input:");

            string command = Console.ReadLine();
            ///All commands are stored in cases 
            switch (command)
            {

                case "help":


                    {

                        Console.WriteLine("hello - Simple OS command");

                        Console.WriteLine("about - Know about OS ");

                        Console.WriteLine("singraph - Shows a basic singraph");

                        Console.WriteLine("binarygacha - Makes a random 8 digit binarynumber");

                        Console.WriteLine("clear - Clears the console");

                        Console.WriteLine("calculator - A simple calculator");

                        Console.WriteLine("date - Shows the current date and time,  currenlty a deathswitch ");

                        Console.WriteLine("filecommands - shows all file and dir commands ");

                        Console.WriteLine("DnD - plays a small demo of the fansaty game D&D");

                        Console.WriteLine("settings - shows settings commands");

                        Console.WriteLine("DNS - a simple DNS server that sends data to gain a IP");

                        Console.WriteLine("poweroff - turns off the system");
                        break;

                    }

                case "filecommands":
                    {
                        Console.WriteLine(" ____|_ _| |     ____|  ___| \r\n |      |  |     __|  \\___ \\ \r\n __|    |  |     |          |\r\n_|    ___|_____|_____|_____/ \r\n                             \r\n");
                               
                        Console.WriteLine("fileinfo - gives information on file type and space");

                        Console.WriteLine("filelist - gives list of all files");

                        Console.WriteLine("readallfile - see all directories and files");

                        Console.WriteLine("filenew - creates new file");

                        Console.WriteLine("dirnew - creates new directory");

                        Console.WriteLine("detelefile - deteles file and directory");

                        Console.WriteLine("writefile - write into file");

                        Console.WriteLine("readfile - read from file");
                     
                        break;
                    }

                case "settings":
                    {
                        Console.WriteLine(" ____       _   _   _                 \r\n/ ___|  ___| |_| |_(_)_ __   __ _ ___ \r\n\\___ \\ / _ \\ __| __| | '_ \\ / _` / __|\r\n ___) |  __/ |_| |_| | | | | (_| \\__ \\\r\n|____/ \\___|\\__|\\__|_|_| |_|\\__, |___/\r\n                            |___/     ");
                       
                        Console.WriteLine("IP - Shows IP Address ");

                        Console.WriteLine("raminfo - gives info on ram usage and avaibility");

                        Console.WriteLine("diskcleanup - cleans up data not being used");
                        break;
                    }

              
                case "about":

                    {

                        Console.WriteLine("BRIDGES OS 1.0 is a Mini Operating System Designed for Simple tasks like Information and Music " +
                            "                                      ^^\r\n    ^^      ..                                       ..\r\n            []                                       []\r\n          .:[]:_          ^^                       ,:[]:.\r\n        .: :[]: :-.                             ,-: :[]: :.\r\n      .: : :[]: : :`._                       ,.': : :[]: : :.\r\n    .: : : :[]: : : : :-._               _,-: : : : :[]: : : :.\r\n_..: : : : :[]: : : : : : :-._________.-: : : : : : :[]: : : : :-._\r\n_:_:_:_:_:_:[]:_:_:_:_:_:_:_:_:_:_:_:_:_:_:_:_:_:_:_:[]:_:_:_:_:_:_\r\n!!!!!!!!!!!![]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!![]!!!!!!!!!!!!!\r\n^^^^^^^^^^^^[]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[]^^^^^^^^^^^^^\r\n            []                                       []\r\n            []                                       []\r\n            []                                       []\r\n ~~^-~^_~^~/  \\~^-~^~_~^-~_^~-^~_^~~-^~_~^~-~_~-^~_^/  \\~^-~_~^-~~-\r\n~ _~~- ~^-^~-^~~- ^~_^-^~~_ -~^_ -~_-~~^- _~~_~-^_ ~^-^~~-_^-~ ~^\r\n   ~ ^- _~~_-  ~~ _ ~  ^~  - ~~^ _ -  ^~-  ~ _  ~~^  - ~_   - ~^_~\r\n     ~-  ^_  ~^ -  ^~ _ - ~^~ _   _~^~-  _ ~~^ - _ ~ - _ ~~^ -\r\njgs     ~^ -_ ~^^ -_ ~ _ - _ ~^~-  _~ -_   ~- _ ~^ _ -  ~ ^-\r\n            ~^~ - _ ^ - ~~~ _ - _ ~-^ ~ __- ~_ - ~  ~^_-\r\n                ~ ~- ^~ -  ~^ -  ~ ^~ - ~~  ^~ - ~");

                        break;

                    }

                case "hello":
                    {

                        Console.WriteLine("Hello User! Thanks for using this operating system!");

                        break;

                    }

                case "clear":
                    {
                        Console.Clear();
                        break;
                    }


                case "cena":
                    {

                        Console.WriteLine("                                                                      \r\n                                           @@%%%%%%%@@@@                                            \r\n                                          @%#*++===++*%@@                                           \r\n                                        #%%###+*=-+*++#@                                            \r\n                                        ###+=-+#=---:-+*                                            \r\n                                          #++-=------+                                              \r\n                                   @@@@@@@*%%%%***#%%@                                              \r\n                               @@@@@@@@@@%%*++++#-:---+@@@@@@                                       \r\n                               @%%%%%%%%%%%#-=*#**......:%%%@@@@                                    \r\n                               %%%%%%%%%%%#%%#%%*#+-:::-#%%%%@@@                                    \r\n                               %%%%%%%%%%%%%##%#-==:.....#%%@@@@@                                   \r\n                               %%%%%%@%%%%%%%@@@@#--::---#@@@@@@@@                                  \r\n                               @@@%%%%@%%%@@@@@@@#%%%@%++*#%%%%%@@@@            ");

                        break;
                    }
                case "singraph":
                    {

                        Console.WriteLine("     \\/ _ |_  // |-.   \\/\r\n     /  -  _| \\  | |   /\\\r\n\r\n 1 -|         ,-'''-.\r\n    |      ,-'       `-.          \r\n    |    ,'             `.\r\n    |  ,'                 `.\r\n    | /                     \\\r\n    |/                       \\\r\n----+-------------------------\\--------------------------\r\n    |          __           __ \\          __           /  __\r\n    |          ||/2         ||  \\        3||/2        /  2||\r\n    |                            `.                 ,'\r\n    |                              `.             ,'\r\n    |                                `-.       ,-'\r\n-1 -|                                   `-,,,-'\r\n");
                        break;
                    }
                case "binarygacha":
                    {

                        Random rnd = new Random();
                        for (int i = 0; i < 8; i++)

                            Console.WriteLine(rnd.Next(2));
                        break;
                    }
                case "calculator":
                    {
                        string value;
                        do
                        {
                            Console.Write("Enter the first number: ");
                            int num1 = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter the second number: ");
                            int num2 = Convert.ToInt32(Console.ReadLine());

                            int result = num1 + num2;
                            Console.WriteLine($"Addition: {result}");

                            Console.Write("Do you want to continue (y/n)? ");
                            value = Console.ReadLine();
                        } while (value.ToLower() == "y");
                        break;
                    }
                
                case "fileinfo":
                    {


                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        Console.WriteLine("Available Free Space: " + available_space);

                        var fs_type = fs.GetFileSystemType(@"0:\");
                        Console.WriteLine("File System Type: " + fs_type);

                        break;

                    }
                case "readallfile":
                    {

                        var files_list = Directory.GetFiles(@"0:\");
                        var directory_list = Directory.GetDirectories(@"0:\");
                      
                        foreach (var file in files_list)
                        {
                            Console.WriteLine(file);
                        }
                        foreach (var directory in directory_list)
                        {
                            Console.WriteLine(directory);
                        }

                        break;

                    }
                case "filelist":
                    {
                        var directory_list = Directory.GetFiles(@"0:\");
                        try
                        {
                            foreach (var file in directory_list)
                            {
                                var content = File.ReadAllText(file);

                                Console.WriteLine("File name: " + file);
                                Console.WriteLine("File size: " + content.Length);
                                Console.WriteLine("Content: " + content);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
               

                        break;
                    }
                case "filenew":
                    {
                        try
                        {
                            var file_stream = File.Create(@"0:\new.txt");
                            Console.WriteLine("new.txt was made");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                       
                        break;
                    }
                case "dirnew":
                    {
                        try
                        {
                            Directory.CreateDirectory(@"0:\newdirectory\");
                            Console.WriteLine("newdirectory was made");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                        break;
                    }
                case "detelefile":
                    {
                        try
                        {
                            File.Delete(@"0:\new.txt");                         
                          
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        
                        break;
                    }

                case "deteledir":
                    {
                        try
                        {
                            Directory.Delete(@"0:\newdirectory\");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    }
                
                
                
                case "writefile":
                    {

                        try
                        {
                            Console.WriteLine("Enter the text:");
                            string filePath = Console.ReadLine();
                            File.WriteAllText(@"0:\new.txt", filePath);
                            Console.WriteLine("File successfully written.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"An error occurred: {e}");
                        }

                        break;
                    }
                case "readfile":
                    {

                        try
                        {
                            Console.WriteLine(File.ReadAllText(@"0:\new.txt"));                            
                        
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                        break;


                    }


                case "DNS":
                    {
                        using (var xClient = new DnsClient())
                        {
                            xClient.Connect(new Address(8, 8, 8, 8)); //DNS Server address. We recommend a Google or Cloudflare DNS, but you can use any you like!

                            /** Send DNS ask for a single domain name **/
                            xClient.SendAsk("github.com");

                            /** Receive DNS Response **/
                            Address destination = xClient.Receive(); //can set a timeout value
                            
                        }

                        break;
                    }

               

                case "IP":
                    {
                        Console.WriteLine(NetworkConfiguration.CurrentAddress.ToString());

                        break;
                    }

                    ///Small DND Game
                case "DnD":
                    {

                        Console.WriteLine("                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                              .-####+.                                              \r\n                                          .-###++##++###+.                                          \r\n                                      .-+##++++++##++++++###-.                                      \r\n                                   -+##++####++++##++++++++++###-.                                  \r\n                              ..-###++++#####++++##++++++###+#+++##+-.                              \r\n                          ..-##+++##+++#####+++######+++++++######+++##+...                         \r\n                      ..-##+++++#++++++######+++##+#+++######++++++++++++##+..                      \r\n                   .-###+++++++######++++++++++##+++#++++++++++######++++++++##-.                   \r\n               .-###+++######+++++++++++++++++#++++++##++++++++++++++++######+++###-.               \r\n           .-+#######++++++++++++++++++++++++#++++++++##+++++++++++++++++++++++########-.           \r\n          +##++++++++++++++++++++++++++++++##++++++++++##++++++++++++++++++++++++++++++##+          \r\n          -##+++++++++++++++++++++++++++++##+++++++++++++#+++++++++++++###++++++++++++++#+          \r\n          -##+++++++++++###++++++++++++++##+++++++++++++++#+++++++######+++++++++++++++##+          \r\n          -###++++++++##++##++##++++++++#++++++++++++++++++##+++++++##++++++++++++++++###+          \r\n          -#+##++++++##+++##+##++++++++#++++++++++++++++++++##+++++++++++#####++++++++#+#+          \r\n          -#++#+++++++++++####+++++++##++++++++++++++++++++++##++++++++++##++++++++++##+#+          \r\n          +#++##+++++++++++#++++++++##+++++++++++++++++++++++++#+++++++++####++++++++#++#+          \r\n          +#+++#+++++++++++++++++++#++++++++##++++++++++++++++++#++++++++++##+++++++##++#+          \r\n          +#+++##+++++++++++++++++#++++++###++##+++++#######+++++##++++++++++++++++##+++#+          \r\n          +#++++##+++++++++++++++#+++++++#++++##++++##+++++##+++++##++++++++++++++##++++##          \r\n          +#++#++#+++++++++++++##+++++++++++###+++++##+++++##++++++##+++++++++++++#+++++##          \r\n          +#++##+##+++++++++++##++++++++++##++++++++##+++++##++++++++#+++++++++++##+++++##          \r\n          +######+#++++++++++#+++++++++++########++++###+###++++++++++#++++++++++#++++++##          \r\n          ####++++##++++++++#++++++++++++++++++++++++++++++++++++++++++##+++++++##++######          \r\n          ##+#+###+##+++++##++++++++++++++++++++++++++++++++++++++++++++##+++++##+++######          \r\n          ##++##++++#++++##++++++++++++++++++++++++++++++++++++++++++++++##++++#++++++####          \r\n          ##++##++++##++##++++++++++++++++++++++++++++++++++++++++++++++++##++##++++++#+##          \r\n          ##+++++++++###++++++++++++++++++++++++++++++++++++++++++++++++++++###+++++++++##          \r\n          ##+++++++++##########################################################+++++++++##          \r\n          ##+++++###++++##++++++++++++++++++++++++++++++++++++++++++++++++###+++###+++++##          \r\n          ##+####+++++++++##++++++++++++++++++++++++++++++++++++++++++++##++++++++++###++#          \r\n          ###+++++++++++++++##++++++++++++++++++++++++++++++++++++++++##++++++###++++++###          \r\n           .-###++++##+++##+++##++++++++++++++########++++++++++++++##+++++##+++++++###+..          \r\n               .-##+++#####+++++##+++++++++++##+++++##++++++++++++##++++###++++++##+.               \r\n                   .+##+++++++##++##++++++++++########++++++++++##++#####++#+##+.                   \r\n                      ..+#####+##+++##++++++++########++++++++##++++###++##+..                      \r\n                          ..+##+++++++##++++++++++++++++++++##+++++++##+...                         \r\n                              ..+##+++++##++++++++++++++++##+++++##+-.                              \r\n                                  .-+##+++###+++++++++++##+++##+-.                                  \r\n                                      .-+##+##++++++++##+###-.                                      \r\n                                          .-#####+++####-.                                          \r\n                                              .-####-.                                              \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ");
                        Console.WriteLine("Welcome to the World of D&D pls tell me your name ");
                        string playername = Console.ReadLine();
                        Console.WriteLine("Why hello " + playername);
                        Console.WriteLine("Welcome to the world of D&D lets get you started");
                        Console.WriteLine("You have 20 points, please enter the number for each stat");
                        Console.WriteLine("Strength");
                        Console.WriteLine("Dexterity");
                        Console.WriteLine("Constitution");
                        Console.WriteLine("Intelligence");
                        Console.WriteLine("Wisdom");
                        string playerstrength = Console.ReadLine();
                        string playerdexterity = Console.ReadLine();
                        string playerconstitution = Console.ReadLine();
                        string playerintelligence = Console.ReadLine();
                        string playerwisdom = Console.ReadLine();
                        Console.WriteLine("Strength " + playerstrength);
                        Console.WriteLine("Dexterity " + playerdexterity);
                        Console.WriteLine("Constitution " + playerconstitution);
                        Console.WriteLine("Intelligence " + playerintelligence);
                        Console.WriteLine("Wisdom " + playerwisdom);
                        Console.WriteLine("You are all set, now get ready to go on a amazing adventure, hope to see you alive with no missing limbs");
                        //level 1
                        Console.WriteLine("As you start your journey you come across a tree and want to cut it down");
                        Console.WriteLine("Type anyhting to roll a number from 1 to 20");
                        Console.WriteLine();

                        string roll = Console.ReadLine();

                        if (Console.ReadLine() != null)
                        {
                            Random rnd = new Random();
                             
                            Console.WriteLine("You rolled a " + rnd.Next(1, 20));
                            int die = rnd.Next(1, 20);

                        
                        }
                        Console.WriteLine("if you got 1-3 the tree fell on you and you die a horrible death");
                        Console.WriteLine("if you got 4-7 you only put a dent into the tree");
                        Console.WriteLine("if you got a 8-11 you cut the tree down and simply get the wood");
                        Console.WriteLine("if you got a 12-16 the tree had the hidden Sword of Aegis which gives you plus 5 str/wis");
                        Console.WriteLine("if you got a 17-20 not only did you get the Sword of Aegis you all got a golden apple which gives permenant 4 hp buff");
                        
                       break;
                    }

                case "raminfo":
                    {
                        GCImplementation.GetAvailableRAM();
                        GCImplementation.GetUsedRAM();

                        break;
                    }
                case "diskcleanup":
                    {
                        Heap.Collect();
                        break;
                    }

                case "poweroff":
                    {
                        Sys.Power.Shutdown();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No such command");

                        command = null; break;
                    }
                  
            }
       
        }

    }
}


        
    

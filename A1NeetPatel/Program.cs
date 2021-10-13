using System;
using System.Collections.Generic;
using System.Linq;

namespace A1NeetPatel
{
    class Program
    {

        public enum typeOfPlayer
        {
            HockeyPlayer,
            BaseBallPlayer,
            BasketBallPlayer
        }

        //ind is unique id   
        private static int ind = 1;
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        //Generic Collection as per assignment requirement
        static List<Player> players = new List<Player>();

        //Main Menu
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Player");
            Console.WriteLine("2) Edit Player");
            Console.WriteLine("3) Delete Player");
            Console.WriteLine("4) View Player");
            Console.WriteLine("5) Search Player");
            Console.WriteLine("6) Exit");

            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    AddpLayer();
                    return true;
                case "2":
                    Console.Clear();
                    EditPlayer();
                    return true;
                case "3":
                    Console.Clear();
                    DeletePlayer();
                    return true;
                case "4":
                    Console.Clear();
                    ShowPlayerss();
                    return true;
                case "5":
                    Console.Clear();
                    SearchPlayer();
                    return true;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Try Again, Please., Invalid input");
                    return true;
            }
        }
        //Add Player- Menu 
        private static Player AddpLayer()
        {

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Hockey Player");
            Console.WriteLine("2) Add BasketBall Player");
            Console.WriteLine("3) Add Baseball Player");
            Console.WriteLine("4) Back to Main Menu");

            typeOfPlayer ptype = typeOfPlayer.HockeyPlayer;

            bool showMenu = true;
            while (showMenu)
            { showMenu = AddMenu(); }

            bool AddMenu()
            {
                Console.Write("\nEnter your option: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        ptype = typeOfPlayer.HockeyPlayer;
                        InsertingPlayer(ptype);
                        return false;
                    case "2":
                        ptype = typeOfPlayer.BasketBallPlayer;
                        InsertingPlayer(ptype);

                        return false;
                    case "3":
                        ptype = typeOfPlayer.BaseBallPlayer;
                        InsertingPlayer(ptype);

                        return false;
                    case "4":
                        Console.Clear();
                        MainMenu();
                        return false;

                    default:
                        Console.WriteLine("Invalid input. Try again, Please.");
                        return true;
                }

            }

            // Inserting as per user choice
            static void InsertingPlayer(typeOfPlayer PlayerType)
            {

                int assists = 0;
                int goals = 0;
                int runs = 0;
                int homeRuns = 0;
                int fGoals = 0;
                int threePointer = 0;
                bool checker = true;

                Console.Write("\nEnter player Name : ");
                string pName = Console.ReadLine();
                Console.Write("Enter Team Name : ");
                string tName = Console.ReadLine();

                int gamesPlayed = 0;// 
                                    //gamesplayed must be a positive number or zero
                while (checker)
                {
                    Console.Write("Enter games Played: ");

                    bool success = Int32.TryParse(Console.ReadLine(), out gamesPlayed);
                    if (success && gamesPlayed >= 0)
                    {
                        checker = false;
                    }
                    else
                    {
                        Console.WriteLine("Numbers Only, positive please. ");
                        checker = true;
                    }
                }
                if (PlayerType == typeOfPlayer.HockeyPlayer)
                {
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter assists: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out assists);
                        if (success && assists >= 0)
                        { checker = false; }
                        else
                        {
                            Console.WriteLine("Numbers Only, positive please. ");
                            checker = true;
                        }
                    }
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter goals: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out goals);
                        if (success && goals >= 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Numbers Only, positive please. ");
                            checker = true;
                        }
                    }
                    Player p = new HockeyPlayer(ind++, PlayerType, pName, tName, gamesPlayed, assists, goals);
                    players.Add(p);
                }
                if (PlayerType == typeOfPlayer.BaseBallPlayer)
                {
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter runs: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out runs);
                        if (success && runs >= 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Numbers Only, positive please. ");
                            checker = true;
                        }
                    }
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter home runs: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out homeRuns);
                        if (success && homeRuns >= 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Numbers Only, positive please. ");
                            checker = true;
                        }
                    }
                    Player p = new BaseBallPlayer(ind++, PlayerType, pName, tName, gamesPlayed, runs, homeRuns);
                    players.Add(p);
                }

                if (PlayerType == typeOfPlayer.BasketBallPlayer)
                {
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter field goals: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out fGoals);
                        if (success && fGoals >= 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Type, nter zero or positive numbers only");
                            checker = true;
                        }
                    }
                    checker = true;
                    while (checker)
                    {
                        Console.Write("Enter three pointers: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out threePointer);
                        if (success && threePointer >= 0)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Numbers Only, positive please. ");
                            checker = true;
                        }
                    }
                    Player p = new BasketBallPlayer(ind++, PlayerType, pName, tName, gamesPlayed, fGoals, threePointer);
                    players.Add(p);
                }
                Console.WriteLine("\nPlayer Added.");
                Console.Write("\nView All ");
                ShowPlayers(PlayerType);
                Console.WriteLine("\n Continue");
                Console.ReadKey();
                Console.Clear();
                AddpLayer();//go back to menu

            }
            return null;
        }

        //Edit Player
        private static Player EditPlayer()
        {

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Edit Hockey Player");
            Console.WriteLine("2) Edit BasketBall Player");
            Console.WriteLine("3) Edit Baseball Player");
            Console.WriteLine("4) Back to Main Menu");

            typeOfPlayer ptype = typeOfPlayer.HockeyPlayer;

            bool showMenu = true;
            while (showMenu)
            { showMenu = EditMenu(); }
            bool EditMenu()
            {
                Console.Write("Enter your option: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        ptype = typeOfPlayer.HockeyPlayer;
                        UpdatingPlayer(ptype);
                        return true;
                    case "2":
                        ptype = typeOfPlayer.BasketBallPlayer;
                        UpdatingPlayer(ptype);

                        return false;
                    case "3":
                        ptype = typeOfPlayer.BaseBallPlayer;
                        UpdatingPlayer(ptype);

                        return false;
                    case "4":
                        Console.Clear();
                        MainMenu();
                        return false;

                    default:
                        Console.WriteLine("Invalid input. Try Again, Please..");
                        return true;
                }

            }

            //Updating Player in a user choice sport
            static void UpdatingPlayer(typeOfPlayer PlayerType)
            {

                ShowPlayers(PlayerType);
                bool des = true;
                while (des)
                {
                    Console.Write("Enter the ID of the Player edit: ");
                    int start = Convert.ToInt32(Console.ReadLine());
                    if (start > 0 && start < players.Count)
                    {
                        if (players[start - 1].typeOfPlayer == PlayerType)
                        {

                            int assists = 0;
                            int goals = 0;
                            int runs = 0;
                            int homeRuns = 0;
                            int fGoals = 0;
                            int threePointer = 0;
                            bool checker = true;
                            Console.Write("Enter player's new Name : ");
                            string pName = Console.ReadLine();
                            Console.Write("Enter new Team Name : ");
                            string tName = Console.ReadLine();
                            int gamesPlayed = 0;// 
                            while (checker)
                            {
                                Console.Write("Enter games Played: ");

                                bool success = Int32.TryParse(Console.ReadLine(), out gamesPlayed);
                                if (success && gamesPlayed >= 0)
                                {
                                    checker = false;
                                }
                                else
                                {
                                    Console.WriteLine("Numbers Only, positive please. ");
                                    checker = true;
                                }
                            }
                            if (PlayerType == typeOfPlayer.HockeyPlayer)
                            {
                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter assists: ");
                                    bool success = Int32.TryParse(Console.ReadLine(), out assists);
                                    if (success && assists >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }
                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter goals: ");
                                    bool success = Int32.TryParse(Console.ReadLine(), out goals);
                                    if (success && goals >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }
                                players[start - 1] = new HockeyPlayer(start, PlayerType, pName, tName, gamesPlayed, assists, goals);
                            }
                            if (PlayerType == typeOfPlayer.BaseBallPlayer)
                            {
                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter runs: ");
                                    bool success = Int32.TryParse(Console.ReadLine(), out runs);
                                    if (success && runs >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }

                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter home runs: ");
                                    bool success = Int32.TryParse(Console.ReadLine(), out homeRuns);
                                    if (success && homeRuns >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }
                                players[start - 1] = new BaseBallPlayer(start, PlayerType, pName, tName, gamesPlayed, runs, homeRuns);
                            }
                            if (PlayerType == typeOfPlayer.BasketBallPlayer)
                            {
                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter field goals: ");


                                    bool success = Int32.TryParse(Console.ReadLine(), out fGoals);
                                    if (success && fGoals >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }

                                checker = true;
                                while (checker)
                                {
                                    Console.Write("Enter three pointers: ");
                                    bool success = Int32.TryParse(Console.ReadLine(), out threePointer);
                                    if (success && threePointer >= 0)
                                    {
                                        checker = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numbers Only, positive please. ");
                                        checker = true;
                                    }
                                }
                                players[start - 1] = new BasketBallPlayer(start, PlayerType, pName, tName, gamesPlayed, fGoals, threePointer);
                            }
                            Console.WriteLine($"\n\nPlayer updated for ID = {start}.");
                            Console.Write("\nSee all ");
                            ShowPlayers(PlayerType);
                            des = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id");
                            des = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id");
                        des = true;
                    }

                }
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
                EditPlayer();//Back to aEdit menu
            }
            return null;
        }

        //Delete Player
        private static Player DeletePlayer()
        {

            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Delete Hockey Player");
            Console.WriteLine("2) Delete BasketBall Player");
            Console.WriteLine("3) Delete Baseball Player");
            Console.WriteLine("4) Back to Main Menu");

            typeOfPlayer ptype = typeOfPlayer.HockeyPlayer;

            bool showMenu = true;
            while (showMenu)
            { showMenu = DeleteMenu(); }
            bool DeleteMenu()
            {
                Console.Write("\nEnter your option: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        ptype = typeOfPlayer.HockeyPlayer;
                        Console.WriteLine("\n\nView all ");
                        RemovingPlayer(ptype);
                        return false;
                    case "2":
                        ptype = typeOfPlayer.BasketBallPlayer;
                        Console.WriteLine("\n\nView all ");
                        RemovingPlayer(ptype);
                        return false;
                    case "3":
                        ptype = typeOfPlayer.BaseBallPlayer;
                        Console.WriteLine("\n\nView all ");
                        RemovingPlayer(ptype);

                        return false;
                    case "4":
                        Console.Clear();
                        MainMenu();
                        return false;

                    default:
                        Console.WriteLine("Invalid input. Try Again, Please..");
                        return true;
                }

            }
            //Deleting Player by name 
            static void RemovingPlayer(typeOfPlayer PlayerType)
            {

                ShowPlayers(PlayerType);
                bool des = true;
                while (des)
                {
                    int start = -1;
                    int getInd = -1;
                    bool checker = true;
                    while (checker)
                    {
                        Console.Write("\n\nEnter the ID of the Player delete: ");
                        bool success = Int32.TryParse(Console.ReadLine(), out start);
                        if (success)
                        {
                            checker = false;
                        }
                        else
                        {
                            Console.WriteLine("Not Valid, Try Again!");
                            checker = true;
                        }
                    }
                    getInd = players.FindIndex(p => p.PlayerId == start);

                    if (getInd != -1)
                    {
                        if (players[getInd].typeOfPlayer == PlayerType)
                        {
                            players.RemoveAt(getInd);
                            Console.WriteLine($"\nPlayer with ID = {start} Deleted!!!\n\nView all ");
                            ShowPlayers(PlayerType);
                            Console.Write("\nPress any key to continue");
                            Console.ReadKey();
                            des = false;

                        }
                        else
                        {
                            Console.WriteLine($"\nNo {PlayerType} with  Id = {start}.\nPress any key to return to Delete menu.");
                            Console.ReadKey();
                            des = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nList is Empty or No Data found with same Id.\nPress any key to return to Delete menu");
                        Console.ReadKey();
                        des = false;
                    }
                }
                DeletePlayer();
            }
            return null;
        }


        //Searching player in whole collection by name
        private static void SearchPlayer()
        {
            Console.WriteLine("\nSearch for Player by name, Case sensitive.");
            Console.Write("\n Enter the player name to search (I.e. : Neet Patel)");
            string sValue = Console.ReadLine();


            var searchResults = from player in players
                                where player.PlayerName.Contains(sValue, StringComparison.OrdinalIgnoreCase)
                                select player;
            if (searchResults.Count() > 0)
            {
                Console.WriteLine($"Here are all the players with the search : {sValue}.\n");
                foreach (var i in searchResults)
                {
                    if (i.typeOfPlayer == typeOfPlayer.HockeyPlayer)
                    {

                        Console.WriteLine("Hockey Players\n");
                        Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14    } {"Assists",+14} {"Goals",+15} {"Points",+8}\n");
                        Console.WriteLine(i);

                        Console.WriteLine("\n");

                    }
                    if (i.typeOfPlayer == typeOfPlayer.BasketBallPlayer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Basket Ball Players\n");
                        Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14} {"Field Goals",+14} {"Three Pointers",+15} {"Points",+8}\n");
                        Console.WriteLine(i);

                        Console.WriteLine("\n\n");

                    }
                    if (i.typeOfPlayer == typeOfPlayer.BaseBallPlayer)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Base Ball Players\n");
                        Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14} {"Runs",+13} {"Home Runs",+15} {"Points",+8}\n");
                        Console.WriteLine(i);

                        Console.WriteLine("\n\n");

                    }


                }
            }
            else
            {
                Console.WriteLine("Not Found, oops");
            }

            Console.ReadKey();
            MainMenu();
        }

     
        //Viewing all players
        private static void ShowPlayerss()
        {



            Console.WriteLine("\n\t\tView All Players:\n\n");
            ShowPlayers(typeOfPlayer.HockeyPlayer);
            Console.WriteLine("\n\n");
            ShowPlayers(typeOfPlayer.BasketBallPlayer);
            Console.WriteLine("\n\n");

            ShowPlayers(typeOfPlayer.BaseBallPlayer);
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            MainMenu();
        }
        //Viewing Players of individual sport
        static void ShowPlayers(typeOfPlayer typeOfPlayer)
        {
            var hockeyPlayers = from player in players
                                where player.typeOfPlayer == typeOfPlayer.HockeyPlayer
                                select player;
            var basketBallPlayers = from player in players
                                    where player.typeOfPlayer == typeOfPlayer.BasketBallPlayer
                                    select player;

            var baseBallPlayers = from player in players
                                  where player.typeOfPlayer == typeOfPlayer.BaseBallPlayer
                                  select player;

            if (typeOfPlayer == typeOfPlayer.HockeyPlayer)
            {

                Console.WriteLine("Hockey Players\n");

                Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14    }\t{"Assists",+11}\t{"Goals",+14}\t{"Points",+6}\n");
                foreach (var i in hockeyPlayers)
                    Console.WriteLine(i);


            }

            if (typeOfPlayer == typeOfPlayer.BasketBallPlayer)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine("BasketBall Players\n");

                Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14}\t{"Field Goals",+11}\t{"Three Pointers",+14}\t{"Points",+6}\n");
                foreach (var i in basketBallPlayers)
                    Console.WriteLine(i);


            }
            if (typeOfPlayer == typeOfPlayer.BaseBallPlayer)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("BaseBall Players\n");

                Console.WriteLine($"{ "Player Type",-18}{" Player ID",+14} {"Player Name",-18} {"Team Name",-18} {"Games Played",+14}\t{"Runs",+11}\t{"Home Runs",+14}\t{"Points",+6}\n");
                foreach (var i in baseBallPlayers)
                    Console.WriteLine(i);


            }
        }

        //Players Class
        public abstract class Player
        {

            private int iD;

            public int PlayerId
            {
                get { return iD; }
                set { iD = value; }
            }



            private typeOfPlayer playerType;

            public typeOfPlayer typeOfPlayer
            {
                get { return playerType; }
                set { playerType = value; }
            }

            private string namePlayer;

            public string PlayerName
            {
                get { return namePlayer; }
                set { namePlayer = value; }
            }
            private string teamNames;

            public string TeamName
            {
                get { return teamNames; }
                set { teamNames = value; }
            }

            private int gamesPlayered;

            public int GamesPlayed
            {
                get { return gamesPlayered; }
                set
                {
                    gamesPlayered = value;
                }
            }

            //Constructor of Player
            public Player(int playerId, typeOfPlayer PlayerType, string playerName, string teamName, int gamesPlayed)
            {

                PlayerId = playerId;
                typeOfPlayer = PlayerType;
                PlayerName = playerName;
                TeamName = teamName;
                GamesPlayed = gamesPlayed;
            }

            //abstract method for points//
            public abstract int Points();

            //toString method//
            public override string ToString()
            {
                return $"{typeOfPlayer,-20}{PlayerId,+12} {PlayerName,-20} {TeamName,-20} {GamesPlayed,+11}";
            }


        }

        //derived class of player : baseballplayer
        class BaseBallPlayer : Player
        {
            private int xRuns;

            public int Runs
            {
                get { return xRuns; }
                set { xRuns = value; }
            }

            private int xHomeRuns;

            public int HomeRuns
            {
                get { return xHomeRuns; }
                set { xHomeRuns = value; }
            }
            public BaseBallPlayer(int playerId, typeOfPlayer PlayerType, string playerName, string teamName,
             int gamesPlayed, int runs, int homeRuns) : base(playerId, PlayerType, playerName, teamName, gamesPlayed)
            {
                Runs = runs;
                HomeRuns = homeRuns;
            }

            //overriding the base class abstract method//
            public override int Points()
            {
                return ((Runs - HomeRuns) + (2 * HomeRuns));
            }
            public override string ToString()
            {
                return base.ToString() + $"\t{Runs,+11}\t{HomeRuns,+14}\t{Points(),+6}";
            }
        }

        //derived class of player : hockeyplayer
        class HockeyPlayer : Player
        {
            private int xassists;

            public int Assists
            {
                get { return xassists; }
                set { xassists = value; }
            }
            private int xgoals;

            public int Goals
            {
                get { return xgoals; }
                set { xgoals = value; }
            }

            public HockeyPlayer(int playerId, typeOfPlayer PlayerType, string playerName, string teamName,
                int gamesPlayed, int assists, int goals) : base(playerId, PlayerType, playerName, teamName, gamesPlayed)
            {
                Assists = assists;
                Goals = goals;
            }
            //overriding the base class abstract method//
            public override int Points()
            {
                return Assists + (2 * Goals);
            }

            public override string ToString()
            {
                return base.ToString() + $"\t{Assists,+11}\t{Goals,+14}\t{Points(),+6}";
            }

        }

        //derived class of player : basketballplayer
        class BasketBallPlayer : Player
        {
            private int xfgoals;

            public int FGoals
            {
                get { return xfgoals; }
                set { xfgoals = value; }
            }

            private int _threePointer;

            public int ThreePointer
            {
                get { return _threePointer; }
                set { _threePointer = value; }
            }
            public BasketBallPlayer(int playerId, typeOfPlayer PlayerType, string playerName, string teamName,
              int gamesPlayed, int fGoals, int threePointer) : base(playerId, PlayerType, playerName, teamName, gamesPlayed)
            {
                FGoals = fGoals;
                ThreePointer = threePointer;
            }
            //overriding the base class abstract method//
            public override int Points()
            {
                return ((FGoals - ThreePointer) + (2 * ThreePointer));
            }
            public override string ToString()
            {
                return base.ToString() + $"\t{FGoals,+11}\t{ThreePointer,+14}\t{Points(),+6}";
            }
        }
    }
}
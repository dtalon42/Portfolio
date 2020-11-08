using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDManager.Models;
using CDManager.Data;


namespace CDManager.View
{
    public class CDView
    {
        private string input;
        private int choice;

        private int idCount = 0;


        public int getMenuChoice() // get program path execution
        {


            Console.WriteLine("Press 1 to create a new CD,");
            Console.WriteLine("press 2 to display CDs,");
            Console.WriteLine("press 3 to search CDs,");
            Console.WriteLine("press 4 to edit a CD,");
            Console.WriteLine("press 5 to remove a CD,");
            Console.WriteLine("press 6 to clear the screen,");
            Console.WriteLine("or press 7 to quit.");

            while (true)
            {

                choice = getInt();
                if (choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    return choice;
                }

            }

        }

        public CD getNewCDInfo() // get cd info
        {
            CD temp = new CD();
            int trackCount;
            string input;
            TimeSpan runtime;

            idCount++; // every time you have a new cd, get a new id
            temp.id = idCount;

            Console.WriteLine("Please input the title of the cd");
            temp.title = getString();


            Console.WriteLine("Please input the cd's artist.");
            temp.artist = getString();


            while (true)
            {
                Console.WriteLine("How many tracks are in the cd?");
                trackCount = getInt();
                if (trackCount < 0)
                {
                    Console.WriteLine("Invalid input.");
                }
                else
                    break;

            }

            temp.tracklist = new string[trackCount];
            Console.WriteLine("Please enter the names of each track.");
            for (int i = 0; i < trackCount; i++)
            {
                temp.tracklist[i] = getString();
            }

            while (true) // use timespan object for album runtime
            {
                Console.WriteLine("Please enter the runtime in hh:mm:ss format.");
                input = Console.ReadLine();
                if (!TimeSpan.TryParse(input, out runtime))
                {
                    Console.WriteLine("Invalid input");
                }
                else
                    break;

            }

            temp.runtime = runtime;

            return temp;
        }

        public void displayCD(CD cd) // display given CDs data
        {
            Console.WriteLine($"Title: {cd.title}");
            Console.WriteLine($"Artist: {cd.artist}");
            for (int i = 0; i < cd.tracklist.Length; i++)
            {
                Console.WriteLine($"Track {i + 1}: {cd.tracklist[i]}"); // cds don't usually start at track 0
            }
            Console.WriteLine($"Runtime: {cd.runtime}");



        }

        public CD editCDInfo(CD cd) // edit cd info
        {
            string input;
            int choice;
            int arrayInit;
            TimeSpan runtime;

            while (true)
            {
                Console.WriteLine("Please enter the data field that you would like to change.");
                Console.WriteLine("1 is title, 2 is artist, 3 is tracklist, 4 is runtime");
                choice = getInt();

                if (choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Please enter the title.");
                            cd.title = getString();
                            break;

                        case 2:
                            Console.WriteLine("Please enter the artist.");
                            cd.artist = getString();
                            break;

                        case 3:
                            Console.WriteLine("How many tracks are in the cd?");
                            arrayInit = getInt();

                            cd.tracklist = new string[arrayInit];
                            Console.WriteLine("Please input the track names.");

                            for (int i = 0; i < cd.tracklist.Length; i++)
                            {
                                cd.tracklist[i] = getString();
                            }
                            break;

                        case 4:
                            while (true) // use timespan object for album runtime
                            {
                                Console.WriteLine("Please enter the runtime in hh:mm:ss format.");
                                input = Console.ReadLine();
                                if (!TimeSpan.TryParse(input, out runtime))
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                else
                                    break;

                            }
                            cd.runtime = runtime;
                            break;
                    }

                    Console.WriteLine("Would you like to edit another data field?");
                    Console.WriteLine("1 is yes, 2 is no.");
                    while (true)
                    {
                        choice = getInt();
                        if (choice < 1 || choice > 2)
                            Console.WriteLine("Invalid input. Please try again.");
                        else
                            break;
                    }


                }

                if (choice == 1)
                {

                }
                else if(choice == 2)
                {
                    break;
                }


            }

            return cd; //placeholder
        }

        private enum searchTerm { title = 1, artist = 2, track = 3 };
        public int searchCD() // search for a cd, return id
        {
            string input;
            //string targetData;
            int choice;
            int foundID = 0;
            bool searchedArtist = false;
            bool searchedTrack = false;
            // boolean variables are for checking for further parsing searches

            List<CD> resultList = new List<CD>();
            CD searchCD = new CD();
            CDRepository repo = new CDRepository();


            Console.WriteLine("You have chosen to search.");
            Console.WriteLine("You can search by title, artist, or track.");
            Console.WriteLine("1 is title, 2 is artist, 3 is track.");
           
            while (true)
            {
                choice = getInt();
                if (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid input. Please enter your choice again.");
                }
                else
                    break;
            }

            Console.WriteLine("Please enter the term to search.");
            input = getString();

            switch(choice)
            {
                case(int) searchTerm.title:
                    resultList = repo.searchCD(input, (int)searchTerm.title);
                    break;

                case (int)searchTerm.artist:
                    searchedArtist = true;
                    resultList = repo.searchCD(input, (int)searchTerm.artist);
                    break;

                case (int)searchTerm.track:
                    searchedTrack = true;
                    resultList = repo.searchCD(input, (int)searchTerm.track);
                    break;
            }

            if (resultList.Count == 1)
                return resultList[0].id;


            else if(resultList.Count > 1)
            {
                Console.WriteLine($"You have {resultList.Count} results.");
                Console.WriteLine("Would you like to continue searching or display all results?");
                Console.WriteLine("Press 1 to continue searching or 2 to display all data.");
                choice = getInt();
                if(choice == 1)
                {
                    if(searchedArtist == true)
                    {
                        Console.WriteLine("Please search by either title or track.");
                        Console.WriteLine("Press 1 to search by title, 2 to search by track.");
                        while(true)
                        {
                            choice = getInt();
                            if(choice < 1 || choice > 2)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            else
                            {
                                break;
                                
                            }
                            
                        }

                        input = getString();

                        switch (choice)
                        {
                            case 1:
                                foundID = searchResultList(input, (int)searchTerm.title, resultList);
                                break;
                            case 2:
                                foundID = searchResultList(input, (int)searchTerm.track, resultList);
                                break;
                        }

                        return foundID;

                    }
                    else if(searchedTrack == true)
                    {
                        Console.WriteLine("Please search by either title or artist.");
                        Console.WriteLine("Press 1 to search by title, 2 to search by artist.");

                        while (true)
                        {
                            choice = getInt();
                            if (choice < 1 || choice > 2)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            else
                            {
                                break;

                            }

                        }

                        input = getString();

                        switch (choice)
                        {
                            case 1:
                                foundID = searchResultList(input, (int)searchTerm.title, resultList);
                                break;
                            case 2:
                                foundID = searchResultList(input, (int)searchTerm.artist, resultList);
                                break;
                        }

                        return foundID;
                    }

                }
                else if(choice == 2)
                {
                    for(int i = 0; i < resultList.Count; i++)
                    {
                        Console.WriteLine($"CD ID is {resultList[i].id}");
                        displayCD(resultList[i]);
                    }
                }

            }

            Console.WriteLine("Match not found.");
            return 0; //default value
        }




        public bool confirmRemoveCD(CD cd)
        {
            if (cd.title != null && cd.tracklist != null && cd.artist != null)
            {
                Console.WriteLine("Warning. Error present. Deletion unsuccessful.");
                return false; //if cd is not null, deletion was unsuccessful
            }
                //title, tracklist, and artist are nullable
                //timespan and int are not
                
            else
            {
                idCount--;
                Console.WriteLine("Deletion successful.");
                return true;
            }


        }

        public int getInt()
        {
            string input;
            int parsed;

            while (true)
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out parsed))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                    break;

            }


            return parsed;
        }

        public string getString()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Invalid input. Please enter data.");
                }
                else
                    break;
            }



            return input;
        }

        public int searchChoice()
        {
            int choice;
            int search = -1;
        

            Console.WriteLine("Do you know the id of the cd you would like to edit?");
            Console.WriteLine("If yes, press 1. If no, press 2");
        
            while(true)
            {
                choice = getInt();
                if(choice < 1 || choice > 2)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    break;
                }

            }

            if (choice == 2)
            {
                return search;
            }
            else if(choice == 1)
            {
                Console.WriteLine("Please enter the cd id.");
                search = getInt();
                return search;
            }

                return search;

        }

        public int deleteChoice()
        {
            int choice;
            int search = -1;


            Console.WriteLine("Do you know the id of the cd you would like to delete?");
            Console.WriteLine("If yes, press 1. If no, press 2");

            while (true)
            {
                choice = getInt();
                if (choice < 1 || choice > 2)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                else
                {
                    break;
                }

            }

            if (choice == 2)
            {
                return search;
            }
            else if (choice == 1)
            {
                Console.WriteLine("Please enter the cd id.");
                search = getInt();
                return search;
            }

            return search;

        }

        private int searchResultList(string searchTerm, int searchType, List<CD> cdlist)
        {

            switch (searchType)
            {
                case 1: // search title
                    for (int i = 0; i < cdlist.Count; i++)
                    {
                        if (cdlist[i].title.ToLower() == searchTerm.ToLower())
                        {
                            return cdlist[i].id;
                        }
                    }
                    break;

                case 2: // search artist
                    for (int i = 0; i < cdlist.Count; i++)
                    {
                        if (cdlist[i].artist.ToLower() == searchTerm.ToLower())
                        {
                            return cdlist[i].id;
                        }
                    }
                    break;

                case 3: // search track
                    for (int i = 0; i < cdlist.Count; i++)
                    {
                        for (int j = 0; j < cdlist[i].tracklist.Length; j++)
                            if (cdlist[i].tracklist[j].ToLower() == searchTerm.ToLower())
                            {
                                return cdlist[i].id;
                            }
                    }
                    break;
            }

            Console.WriteLine("Match not found.");
            return 0; // default value - match not found

        }







    }
}

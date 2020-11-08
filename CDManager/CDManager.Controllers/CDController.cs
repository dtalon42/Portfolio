using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDManager.View;
using CDManager.Data;
using CDManager.Models;

namespace CDManager.Controllers
{
    public class CDController
    {
        private CDRepository repo = new CDRepository();
        private CDView view = new CDView();
        

        int choice;
        enum programChoice : int
        {
            create  = 1,
            display = 2,
            search  = 3,
            edit    = 4,
            remove  = 5,
            clear   = 6,
            quit    = 7
        };

        public void run()
        {
           choice = view.getMenuChoice();

            switch (choice) // make decision based on outcome of user choice
            {
                case (int)programChoice.create:
                    createCD();
                    break;
                case (int)programChoice.display:
                    displayCDs();
                    break;
                case (int)programChoice.search:
                    searchCDs();
                    break;
                case (int)programChoice.edit:
                    editCD();
                    break;
                case (int)programChoice.remove:
                    removeCD();
                    break;
                case (int)programChoice.clear:
                    Console.Clear();
                    break;
                case (int)programChoice.quit:
                    System.Environment.Exit(0);
                    break;
            }
        }
        private void createCD()
        {

            CD temp = new CD();
            temp = view.getNewCDInfo();
            repo.create(temp);
        }

        private void displayCDs() // display cd information
        {
            for(int i = 0; i < repo.readAll().Count; i++) // get length of list
                view.displayCD(repo.readAll()[i]); // pass in info one cd at a time
            

        }

        private void searchCDs() // no user input in mamnager
        {
            int foundID;
            foundID = view.searchCD();

        }

        private void editCD() // no user input - should be in view
        {
            int searchID = 0; // default value
            CD temp = new CD();

            searchID = view.searchChoice();
            if(searchID == -1)
            {
                searchID = view.searchCD();
                if(searchID == 0) // match not found
                {
                    run(); 
                }
            }
            else
            { }
                
                //assume that id is known after this method by this point
                temp = repo.readByID(searchID);
                temp = view.editCDInfo(temp);
                repo.update(searchID, temp);

        }

        private void removeCD() // no user input
        {
            int foundID = 0; // default
            bool deleted;
            CD temp = new CD();
            

            foundID = view.deleteChoice();
            if(foundID == -1)
            {
                foundID = view.searchCD();
                if (foundID == 0)
                    run();
            }

            repo.delete(foundID);
            temp = repo.readByID(foundID);

            deleted = view.confirmRemoveCD(temp);

        }
    }
}

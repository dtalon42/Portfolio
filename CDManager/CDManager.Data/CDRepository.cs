using CDManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDManager.Data
{

    public class CDRepository
    {
        private static List<CD> cdlist = new List<CD>();

        public CD create(CD cd) // add cd to list and return what was added
        {
            cdlist.Add(cd);

            return cd;
        }

        public List<CD> readAll() //read all data = return entire list
        {

            return cdlist;
        }

        public CD readByID(int id) // needs id parameter? can't read by id if you don't supply an id...                    
        {
            
            int readId = id;
            if (!cdlist.Exists(x => x.id == readId)) // if id does not exist, create a throwaway object
            {                                       // verifies deletion
                CD temp = new CD();
                return temp;
            }
            
            for(int i = 0; i < cdlist.Count; i++)
            {
                if (cdlist[i].id == readId)
                {
                    return cdlist[i];
                }
            }

            return cdlist[0]; // returns default value
        }

        public void update(int id, CD cd)
        {
            for(int i = 0; i < cdlist.Count; i++)
            {
                if(cdlist[i].id == id)
                {
                    cdlist[i] = cd;
                    break;
                }
            }


        }

        public List<CD> searchCD(string searchTerm, int searchType)
        {
            List<CD> resultList = new List<CD>();

            switch(searchType)
            {
                case 1: // search title
                    for (int i = 0; i < cdlist.Count; i ++)
                    {
                        if(cdlist[i].title.ToLower() == searchTerm.ToLower())
                        {
                            resultList.Add(cdlist[i]);
                        }
                    }
                    break;

                case 2: // search artist
                    for (int i = 0; i < cdlist.Count; i++)
                    {
                        if (cdlist[i].artist.ToLower() == searchTerm.ToLower())
                        {
                            resultList.Add(cdlist[i]);
                        }
                    }
                    break;

                case 3: // search track
                    for (int i = 0; i < cdlist.Count; i++)
                    {
                        for(int j = 0; j < cdlist[i].tracklist.Length; j++)
                        if (cdlist[i].tracklist[j].ToLower() == searchTerm.ToLower())
                        {
                            resultList.Add(cdlist[i]);
                        }
                    }
                    break;


            }
            return resultList;
        }

        public void delete(int id)
        {
            for (int i = 0; i < cdlist.Count; i++)
            {
                if (cdlist[i].id == id)
                {
                    cdlist.RemoveAt(i);
                    break;
                }
            }


        }


    }
}

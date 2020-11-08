using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class StateValidationRepository
    {
        private static List<State> _states;

        static StateValidationRepository()
        {
            // sample data
            _states = new List<State>
            {
                new State { StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateAbbreviation="OH", StateName="Ohio" },

                new State { StateAbbreviation="WV", StateName="West Virginia" },
                new State { StateAbbreviation="VA", StateName="Virginia" },
                new State { StateAbbreviation="MD", StateName="Maryland" },

                new State { StateAbbreviation="DE", StateName="Delaware" },
                new State { StateAbbreviation="NJ", StateName="New Jersey" },
                new State { StateAbbreviation="PA", StateName="Pennsylvania" },

                new State { StateAbbreviation="NY", StateName="New York" },
                new State { StateAbbreviation="CT", StateName="Connecticut" },
  

                new State { StateAbbreviation="MA", StateName="Massachusetts" },
                new State { StateAbbreviation="VA", StateName="Vermont" },
                new State { StateAbbreviation="NH", StateName="New Hampshire" },

                new State { StateAbbreviation="ME", StateName="Maine" },
                new State { StateAbbreviation="RI", StateName="Rhode Island" },
                new State { StateAbbreviation="TN", StateName="Tennessee" },

                new State { StateAbbreviation="NC", StateName="North Carolina" },
                new State { StateAbbreviation="SC", StateName="South Carolina" },
                new State { StateAbbreviation="GA", StateName="Georgia" },

                new State { StateAbbreviation="AL", StateName="Alabama" },
                new State { StateAbbreviation="FL", StateName="Florida" },
                new State { StateAbbreviation="MS", StateName="Mississippi" },

                new State { StateAbbreviation="IN", StateName="Indiana" },
                new State { StateAbbreviation="MI", StateName="Michigan" },
                new State { StateAbbreviation="IL", StateName="Illinois" },

                new State { StateAbbreviation="WI", StateName="Wisconsin" },
                new State { StateAbbreviation="IA", StateName="Iowa" },
                new State { StateAbbreviation="MO", StateName="Missouri" },

                new State { StateAbbreviation="AR", StateName="Arkansas" },
                new State { StateAbbreviation="LA", StateName="Louisiana" },
                new State { StateAbbreviation="ND", StateName="North Dakota" },

                new State { StateAbbreviation="SD", StateName="South Dakota" },
                new State { StateAbbreviation="NE", StateName="Nebraska" },
                new State { StateAbbreviation="KS", StateName="Kansas" },

                new State { StateAbbreviation="OK", StateName="Oklahoma" },
                new State { StateAbbreviation="TX", StateName="Texas" },


                new State { StateAbbreviation="MN", StateName="Montana" },
                new State { StateAbbreviation="WY", StateName="Wyoming" },
                new State { StateAbbreviation="CO", StateName="Colorado" },

                new State { StateAbbreviation="NM", StateName="New Mexico" },
                new State { StateAbbreviation="ID", StateName="Idaho" },
                new State { StateAbbreviation="UT", StateName="Utah" },

                new State { StateAbbreviation="AZ", StateName="Arizona" },
                new State { StateAbbreviation="NV", StateName="Nevada" },
                new State { StateAbbreviation="CA", StateName="California" },

                new State { StateAbbreviation="OR", StateName="Oregon" },
                new State { StateAbbreviation="WA", StateName="Washington" },


                new State { StateAbbreviation="HI", StateName="Hawaii" },
                new State { StateAbbreviation="AK", StateName="Alaska" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            return _states;
        }

        public static State Get(string stateAbbreviation)
        {
            return _states.FirstOrDefault(c => c.StateAbbreviation == stateAbbreviation);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL.RuleDefinitions.Rules;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;


namespace FlooringMastery.BLL.RuleDefinitions
{
    public static class AddRuleFactory
    {
        public static IAdd Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Test":
                    return new OrderAddRule();
                case "Prod":
                    return new OrderAddRule();
                default:
                    throw new Exception("Mode value in app config is not valid");

            }
        }

        

 
        
    }
}

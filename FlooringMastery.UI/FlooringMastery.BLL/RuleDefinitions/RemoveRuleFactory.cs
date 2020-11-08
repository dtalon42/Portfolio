using FlooringMastery.BLL.RuleDefinitions.Rules;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.RuleDefinitions
{
    public static class RemoveRuleFactory
    {
        public static IRemove Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderRemoveRule();
                case "Prod":
                    return new OrderRemoveRule();
                default:
                    throw new Exception("Mode value in app config is not valid");

            }
        }
    }
}


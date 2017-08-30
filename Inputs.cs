using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAdvisor
{
    public enum Input
    {
        put_on_footwear = 1,
        put_on_headwear = 2,
        put_on_socks = 3,
        put_on_shirt = 4,
        put_on_jacket = 5,
        put_on_pants = 6,
        leave_house = 7,
        take_off_pajamas = 8
    }

    public static class Inputs
    {
        public static bool IsValid(string command)
        {
            return true;
        }

        /// <summary>
        /// Returns True If command is to put on an item.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool IsPutOnCommand(int command)
        {
            if (command >= 1 && command < 7)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Return True if if you can put on this item in this temperature
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool IsBanned(string temperature, int command)
        {
            bool response = false;

            if (temperature.ToLower() == "hot")
            {
                if (command == (int)Input.put_on_socks || command == (int)Input.put_on_jacket)
                    response = true;
            }

            return response;
        }

        public static bool IsPutOnPreConditionsMet(int command, string executedCommands, string inputCommands)
        {
            bool response = true;

            if (command == (int)Input.put_on_socks || command == (int)Input.put_on_pants)
            {
                if (inputCommands.Contains(((int)Input.put_on_footwear).ToString())
                    && executedCommands.Contains(((int)Input.put_on_footwear).ToString()))
                {
                    response = false;
                }
            }
            else if (command == (int)Input.put_on_headwear || command == (int)Input.put_on_jacket)
            {
                if (inputCommands.Contains(((int)Input.put_on_shirt).ToString())
                    && !executedCommands.Contains(((int)Input.put_on_shirt).ToString()))
                {
                    response = false;
                }
            }
                
            return response;
        }

        public static string MapOutput(int command, string tempaerature)
        {
            Input inputCommand = (Input)command;
            bool isHot = false;
            string response = string.Empty;

            if (tempaerature.ToLower() == "hot")
                isHot = true;

            switch (inputCommand)
            {
                case Input.put_on_footwear:
                    response = isHot ? "sandals" : "boots";
                    break;
                case Input.put_on_headwear:
                    response = isHot ? "sun visor" : "hat";
                    break;
                case Input.put_on_socks:
                    response = isHot ? "fail" : "socks";
                    break;
                case Input.put_on_shirt:
                    response = isHot ? "t-shirt" : "shirt";
                    break;
                case Input.put_on_jacket:
                    response = isHot ? "fail" : "jacket";
                    break;
                case Input.put_on_pants:
                    response = isHot ? "shorts" : "pants";
                    break;
                case Input.leave_house:
                    response = isHot ? "leaving house" : "leaving house";
                    break;
                case Input.take_off_pajamas:
                    response = isHot ? "Removing PJs" : "Removing PJs";
                    break;
                default:
                    response = "fail";
                    break;
            }
            return response;
        }
}
}

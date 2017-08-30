using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAdvisor
{
    public class InputProcessor
    {
        public string ProcessCommands(string commandsInput)
        {
            string temperature = string.Empty;
            string commandsExecuted = string.Empty;
            string outputMessage = string.Empty;
            
            try
            {
                temperature = SetTemperature(ref commandsInput);

                if (temperature != string.Empty)
                {
                    string[] commands = commandsInput.Replace(" ", "").Split(',');
                    bool pajamaOn = true;

                    foreach (string command in commands)
                    {
                        if (!Inputs.IsValid(command))
                        {
                            outputMessage += "fail";                            
                            break;
                        }
                        else if (command == ((int)Input.take_off_pajamas).ToString())   // Take Off Pajamas.
                        {
                            pajamaOn = false;
                            outputMessage += Inputs.MapOutput(Convert.ToInt32(command), temperature) + ", ";
                            commandsExecuted += command;
                        }
                        else if (commandsExecuted.Contains(command))    //Check if same command issued more than once.
                        {
                            outputMessage += "fail";
                            break;
                        }
                        else if (pajamaOn && Inputs.IsPutOnCommand(Convert.ToInt32(command)))   // Cannot put on anything before taking pajam's off.
                        {
                            outputMessage += "fail";
                            break;
                        }
                        else if (Inputs.IsBanned(temperature, Convert.ToInt32(command)))    // Socks and jackets are banned when hot.
                        {
                            outputMessage += "fail";
                            break;
                        }
                        else if (!Inputs.IsPutOnPreConditionsMet(Convert.ToInt32(command), commandsExecuted, commandsInput))
                        {
                            outputMessage += "fail";
                            break;
                        }
                        else      //valid input in order
                        {
                            outputMessage += Inputs.MapOutput(Convert.ToInt32(command), temperature) + ", ";
                            commandsExecuted += command;
                        }
                    }
                }
                else
                {
                    outputMessage = "fail";
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return outputMessage.Trim().TrimEnd(new char[] {','});
        }

        private string SetTemperature(ref string inputCommands)
        {
            const string hot = "HOT";
            const string cold = "COLD";
            string temp = string.Empty;

            if (inputCommands.StartsWith(hot))
                temp = hot;
            else if (inputCommands.StartsWith(cold))
                temp = cold;

            inputCommands = inputCommands.Replace(temp, "");

            return temp;
        }
    }
}

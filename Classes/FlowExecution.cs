using System;
using System.Collections.Generic;
using System.Linq;
using DIO.Series.Entities;
using DIO.Series.Dto;
using DIO.Series.Interfaces;
using DIO.Series.Repositories;
using DIO.Series.Shared.Extensions;
using DIO.Series.Interfaces.Command;
using DIO.Series.Command;
using System.Threading;

namespace DIO.Series.Classes
{
    public class FlowExecution
    {
        private string _userCommand;
        private readonly ISeriesRepository _rep;
        private readonly ICommand _command;

        public FlowExecution()
        {
            this._rep = new SeriesRepository();
            this._command = new SerieCommand(_rep);
        }

        public void ExecuteFlow()
        {
            Console.WriteLine(TextSystem.GetInitialText());
            InvokeAction();
        }

        private void GetUserOption()
        {
            _userCommand = Console.ReadLine();
            Console.WriteLine($"Voce digitou {_userCommand}");
        }

        private void InvokeAction()
        {
            GetUserOption();

            var optionSelected = GetAvaliableOptions()
            .FirstOrDefault(_ => _.Key == _userCommand.ToUpper());

            bool isValid = optionSelected.Key != null && optionSelected.Value != null;

            if(isValid)
            {
                optionSelected.Value.Invoke();

                if(optionSelected.Key != "X")
                    RestartIfNeeded();
            }
            else
            {
                Console.WriteLine(TextSystem.GetInvalidOptionText());
                ExecuteFlow();
            }


        }

        private Dictionary<string, Func<bool>> GetAvaliableOptions()
        {
            var options = new Dictionary<string, Func<bool>>();
            options.Add("1", _command.GetAllSeries);
            options.Add("2", _command.CreateSerie);
            options.Add("3", _command.UpdateSerie);
            options.Add("4", _command.DeleteSerie);
            options.Add("5", _command.ViewSerie);
            options.Add("C", _command.ClearConsole);
            options.Add("X", _command.ExitSystem);

            return options;
        }

        private void RestartIfNeeded()
        {
            Console.WriteLine(TextSystem.GetRestartOptionText());
            var optionSelect = Console.ReadLine().ToUpper();

            if(optionSelect == "S")
                ExecuteFlow();

            _command.ExitSystem();        
            
        }

        
    }
}
using Schroedinger.MauiCommands.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schroedinger.MauiCommands.ViewModel
{
    public class MainPageViewModel : BaseModel
    {
        #region Constructor

        public MainPageViewModel()
        {
            SayHelloCommand = new Command<string>(
                (_) => Message = $"Hallo {Text}",
                (_) => !String.IsNullOrEmpty(Text)
            );
        }


        #endregion

        #region Fields
        private string? _message = string.Empty;
        private string? _text = string.Empty;
        #endregion

        #region Commands
        public Command<string> SayHelloCommand { get; set; }

        #endregion

        #region Properties
        public string? Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public string? Text
        {
            get => _text;
            set 
            {
                SetProperty(ref _text, value);
                SayHelloCommand.ChangeCanExecute();
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}

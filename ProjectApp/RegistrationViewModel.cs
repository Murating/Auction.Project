using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using ProjectApp.Commands;
using System.Windows;

namespace ProjectApp.ViewModel
{
    class RegistrationViewModel : BaseViewModel
    {
        private User selectedUser;

        private CommandBase commandAddUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public CommandBase CommandAddUser
        {
            get
            {
                return commandAddUser ??
                 (commandAddUser = new CommandBase(obj =>
                 {
                     if (ValidationControl.IsValidAddUser(selectedUser))
                     {
                         DataBaseService.AddNewUser(selectedUser);
                     }
                 }));
            }
        }

        public RegistrationViewModel()
        {
            selectedUser = new User();
        }
    }
}

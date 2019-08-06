using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using ProjectApp.Commands;

namespace ProjectApp.ViewModel
{
    class ClientInfoViewModel : BaseViewModel
    {
        private User selectedUser;

        private CommandBase commandChangeUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public CommandBase CommandChangeUser
        {
            get
            {
                return commandChangeUser ??
                 (commandChangeUser = new CommandBase(obj =>
                 {
                     DataBaseService.ChangeUser(selectedUser);
                 }));
            }
        }

        public ClientInfoViewModel()
        {
            selectedUser = DataBaseService.GetUserInfo(currentUser.login);
        }
    }
}

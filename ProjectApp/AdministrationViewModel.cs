using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using System.Windows;
using System.Collections.ObjectModel;
using ProjectApp.Commands;

namespace ProjectApp.ViewModel
{
    class AdministrationViewModel : BaseViewModel
    {
        private ObservableCollection<LotInfo> lots;
        private ObservableCollection<User> users;
        private ObservableCollection<Bargaining> bargaes;
        private LotInfo selectedLot;
        private User selectedUser;


        private CommandBase commandDeleteLot;
        private CommandBase commandChangeLot;
        private CommandBase commandDeleteUser;
        private CommandBase commandChangeUser;
        private CommandBase commandUpdata;


        public ObservableCollection<LotInfo> Lots
        {
            get { return lots; }
            set
            {
                lots = value;
                OnPropertyChanged("Lots");
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }
        public ObservableCollection<Bargaining> Bargaes
        {
            get { return bargaes; }
            set
            {
                bargaes = value;
                OnPropertyChanged("Bargaes");
            }
        }
        public LotInfo SelectedLot
        {
            get { return selectedLot; }
            set
            {
                selectedLot = value;
                OnPropertyChanged("SelectedLot");
            }
        }
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }


        public CommandBase CommandDeleteLot
        {
            get
            {
                return commandDeleteLot ??
                 (commandDeleteLot = new CommandBase(obj =>
                 {
                     DataBaseService.DeleteLot(SelectedLot.ID.ToString());
                 }));
            }
        }
        public CommandBase CommandDeleteUser
        {
            get
            {
                return commandDeleteUser ??
                 (commandDeleteUser = new CommandBase(obj =>
                 {
                     DataBaseService.DeleteUser(SelectedUser.Login);

                 }));
            }
        }
        public CommandBase СommandChangeLot
        {
            get
            {
                return commandChangeLot ??
                 (commandChangeLot = new CommandBase(obj =>
                 {
                     DataBaseService.ChangeLot(SelectedLot);
                 }));
            }
        }
        public CommandBase CommandChangeUser
        {
            get
            {
                return commandChangeUser ??
                 (commandChangeUser = new CommandBase(obj =>
                 {
                     DataBaseService.ChangeUser(SelectedUser);
                 }));
            }
        }

        public CommandBase CommandUpdata
        {
            get
            {
                return commandUpdata ??
                 (commandUpdata = new CommandBase(obj =>
                 {
                     try
                     {
                         Lots.Clear();
                         Users.Clear();
                         Bargaes.Clear();
                         Lots = DataBaseService.LoadLotsFromDataBase();
                         Users = DataBaseService.LoadUsersFromDataBase();
                         Bargaes = DataBaseService.LoatBargaesFromDataBase();
                     }
                     catch (Exception exp)
                     {
                         MessageBox.Show(exp.Message);
                     }
                 }));
            }
        }

        public AdministrationViewModel()
        {
            try
            {
                Lots = DataBaseService.LoadLotsFromDataBase();
                Users = DataBaseService.LoadUsersFromDataBase();
                Bargaes = DataBaseService.LoatBargaesFromDataBase();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}

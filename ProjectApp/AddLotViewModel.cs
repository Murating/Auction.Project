using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using ProjectApp.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;

namespace ProjectApp.ViewModel
{
    class AddLotViewModel : BaseModel
    {
        private User user;
        private LotInfo selectedLot;
        private Bargaining barga;
        private CommandBase commandAddLot;
        private CommandBase commandLoadImage;
        public CommandBase CommandAddLot
        {
            get
            {
                return commandAddLot ??
                 (commandAddLot = new CommandBase(obj =>
                 {
                     if (ValidationControl.IsValidAddLot(selectedLot))
                     {
                         try
                         {
                             DataBaseService.AddNewLot(selectedLot);
                             int idLot = DataBaseService.GetLastLotId();
                             barga.IdLot = idLot;
                             barga.LoginOwner = user.Login;
                             barga.LoginWinner = "None";
                             barga.CurrentPrice = selectedLot.StartPrice;
                             DataBaseService.AddNewBargaining(barga);
                         }
                         catch (Exception exp)
                         {
                             MessageBox.Show(exp.Message);
                         }
                     }
                 }));
            }
        }

        public CommandBase CommandLoadImage
        {
            get
            {
                return commandLoadImage ??
                  (commandLoadImage = new CommandBase(obj =>
                  {
                      selectedLot.LotImage = LoadImage.LoadNewImage();
                  }));
            }
        }
        public Bargaining Barga
        {
            get { return barga; }
            set
            {
                barga = value;
                OnPropertyChanged("Barga");
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
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        public AddLotViewModel()
        {
            selectedLot = new LotInfo();
            user = DataBaseService.GetUserInfo(currentUser.login);
            Barga = new Bargaining();
        }
    

    }
}

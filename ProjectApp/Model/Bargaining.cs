using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Model
{
    class Bargaining : BaseModel
    {
        private int idLot;
        private DateTime startAuction;
        private DateTime finishAuction;
        private string loginOwner;
        private string loginWinner;
        private int currentPrice;

        public int IdLot
        {
            get { return idLot; }
            set
            {
                idLot = value;
                OnPropertyChanged("IdLot");
            }
        }
        public DateTime StartAuction
        {
            get { return startAuction; }
            set
            {
                startAuction = value;
                OnPropertyChanged("StartAuction");
            }
        }
        public DateTime FinishAuction
        {
            get { return finishAuction; }
            set
            {
                finishAuction = value;
                OnPropertyChanged("FinishAuction");
            }
        }
        public string LoginOwner
        {
            get { return loginOwner; }
            set
            {
                loginOwner = value;
                OnPropertyChanged("LoginOwner");
            }
        }
        public string LoginWinner
        {
            get { return loginWinner; }
            set
            {
                loginWinner = value;
                OnPropertyChanged("LoginWinner");
            }
        }
        public int CurrentPrice
        {
            get { return currentPrice; }
            set
            {
                currentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }

    }
}

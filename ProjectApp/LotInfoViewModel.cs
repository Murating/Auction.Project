using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using System.Collections.ObjectModel;
using ProjectApp.Commands;
using System.Windows;


namespace ProjectApp.ViewModel
{
    class LotInfoViewModel : BaseViewModel
    {
        private LotInfo selectedLot; //Выбранный лот
        private User user; //Пользователь
        private Bargaining selectedBarga; //Выбранный аукцион данные
        private User lotOwner; //Владелей лота
        private int summa; //Сумма ставки
        private User lotWinner; //Победитель торгов
        private string searchStr;
        private string timeLeft; //Оставшееся время для завершения торгов
        public bool flag1 { get; set; } //Флаги сортировки
        public bool flag2 { get; set; }
        public bool flag3 { get; set; }
        private ObservableCollection<LotInfo> lots; //Список всех лотов
        public ObservableCollection<Bargaining> Bargaes { get; set; } //Список всех аукционов

        private CommandBase commandAddNewPrice;//Команда добавления новой цены
        private CommandBase commandSortLots;//Команда сортировки лотов
        private CommandBase commandSearchLot;//Команда поиска лота

        public CommandBase СommandSearchLot
        {

            get
            {
                return commandSearchLot ??
                 (commandSearchLot = new CommandBase(obj =>
                 {
                     for (int i = 0; i < lots.Count; i++)
                     {
                         if (lots.ElementAt(i).Name == searchStr)
                         {
                             SelectedLot = lots.ElementAt(i);
                         }
                     }
                 }));
            }
        }


        public CommandBase СommandSortLots
        {

            get
            {
                return commandSortLots ??
                 (commandSortLots = new CommandBase(obj =>
                 {
                     if (flag1)
                     {
                         Lots = DataBaseService.SortCollection("order by startPrice desc");

                     }
                     else if (flag2)
                     {
                         Lots = DataBaseService.SortCollection(" order by nameLot");
                     }
                     else if (flag3)
                     {
                         Lots = DataBaseService.SortCollection("order by category");
                     }
                     else
                     {
                         MessageBox.Show("Выберите критерий сортировки");
                     }
                 }));
            }
        }
        public int Summa
        {
            get { return summa; }
            set
            {
                summa = value;
                OnPropertyChanged("Summa");
            }
        }
        public CommandBase СommandAddNewPrice
        {
            get
            {
                return commandAddNewPrice ??
                 (commandAddNewPrice = new CommandBase(obj =>
                 {

                     DataBaseService.SummAdd(selectedLot.ID, summa);
                     Updata();

                 }, obj2 => {
                     if (DateTime.Now < selectedBarga.StartAuction)
                     {
                         return false;
                     }
                     if (DateTime.Now <= selectedBarga.FinishAuction && DateTime.Now >= selectedBarga.StartAuction)
                     {
                         if (selectedBarga.LoginOwner != user.Login)
                         {
                             return true;
                         }
                         else
                         {
                             return false;
                         }
                     }
                     if (DateTime.Now > selectedBarga.FinishAuction)
                     {
                         return false;
                     }
                     return false;
                 }));
            }
        }

        public ObservableCollection<LotInfo> Lots
        {
            get { return lots; }
            set
            {
                lots = value;
                OnPropertyChanged("Lots");
            }
        }

       
        public LotInfo SelectedLot
        {
            get { return selectedLot; }
            set
            {
              
                    selectedLot = value;
                    SelectedBarga = ChengeSelectedBarga(selectedLot.ID);
                    LotOwner = DataBaseService.GetUserInfo(selectedBarga.LoginOwner);
                    LotWinner = DataBaseService.GetUserInfo(selectedBarga.LoginWinner);
                    timer();
                    OnPropertyChanged("SelectedLot");
                  
            }
        }
    
        public User LotOwner
        {
            get { return lotOwner; }
            set
            {
                lotOwner = value;
                OnPropertyChanged("LotOwner");
            }
        }

        public User LotWinner
        {
            get { return lotWinner; }
            set
            {
                lotWinner = value;
                OnPropertyChanged("LotWinner");
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
        
        public Bargaining SelectedBarga
        {
            get { return selectedBarga; }
            set
            {
                selectedBarga = value;
                OnPropertyChanged("SelectedBarga");
            }
        }

        public string SearchStr
        {
            get { return searchStr; }
            set
            {
                searchStr = value;
                OnPropertyChanged("SearchStr");
            }
        }
        public string TimeLeft
        {
            get { return timeLeft; }
            set
            {
                timeLeft = value;
                OnPropertyChanged("TimeLeft");
            }
        }
        public LotInfoViewModel()
        {
            Lots = DataBaseService.LoadLotsFromDataBase();
            user = DataBaseService.GetUserInfo(currentUser.login);
            Bargaes = DataBaseService.LoatBargaesFromDataBase();
            selectedBarga = new Bargaining();
            summa = 0;
            TimeLeft = "";
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    timer();
                }
            });
        }
        private Bargaining ChengeSelectedBarga(int id)
        {
            for (int i = 0; i < Bargaes.Count; i++)
            {
                if (Bargaes.ElementAt(i).IdLot == id)
                {
                    return Bargaes.ElementAt(i);
                }
            }
            return null;
        }

        private void Updata()
        {
            Lots.Clear();
            Bargaes.Clear();
            Lots = DataBaseService.LoadLotsFromDataBase();
            Bargaes = DataBaseService.LoatBargaesFromDataBase();
            
        }

        public void timer()
        {
            if (DateTime.Now < selectedBarga.StartAuction)
            {
                TimeLeft = (selectedBarga.StartAuction - DateTime.Now).Days.ToString() + " д. " +
                (selectedBarga.StartAuction - DateTime.Now).Hours.ToString() + " ч. " +
                (selectedBarga.StartAuction - DateTime.Now).Minutes.ToString() + " мин. ";
            }
            if (DateTime.Now <= selectedBarga.FinishAuction && DateTime.Now >= selectedBarga.StartAuction)
            {
                TimeLeft = (selectedBarga.FinishAuction - DateTime.Now).Days.ToString() + " д. " +
                (selectedBarga.FinishAuction - DateTime.Now).Hours.ToString() + " ч. " +
                (selectedBarga.FinishAuction - DateTime.Now).Minutes.ToString() + " мин. ";
            }
            if (DateTime.Now > selectedBarga.FinishAuction)
            {
                TimeLeft = "Время истекло";
            }
        }


    }
}

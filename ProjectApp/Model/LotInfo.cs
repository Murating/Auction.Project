using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectApp.Model
{
    class LotInfo : BaseModel
    {
        private int id;
        private string name;
        private string category;
        private string info;
        private int startPrice;
        private BitmapImage lotImage;
        
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public int StartPrice
        {
            get { return startPrice; }
            set
            {
                    startPrice = value;
                    OnPropertyChanged("StartPrice");        
            }
        }
        public BitmapImage LotImage
        {
            get { return lotImage; }
            set
            {
                lotImage = value;
                OnPropertyChanged("LotImage");
            }
        }
    }
}

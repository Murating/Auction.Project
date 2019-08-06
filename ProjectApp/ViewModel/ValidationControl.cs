using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using System.Windows;

namespace ProjectApp.ViewModel
{
    static class ValidationControl
    {
        static public bool IsValidAddUser(User user)
        {
            if (user.Name == "")
            {
                MessageBox.Show("Поле имени не заполнено!");
                return false;
            }
            if (user.Surname == "")
            {
                MessageBox.Show("Поле фамилии не заполнено!");
                return false;
            }
            if (user.Login == "")
            {
                MessageBox.Show("Поле login не заполнено!");
                return false;
            }
            if (user.Password == "")
            {
                MessageBox.Show("Поле пароля не заполнено!");
                return false;
            }
            if (user.Email == "")
            {
                MessageBox.Show("Не указан адрес электронной почты!");
                return false;
            }
            if (user.PhoneNumber == "")
            {
                MessageBox.Show("Не указан номер телефона!");
                return false;
            }
            if (user.County == "")
            {
                MessageBox.Show("Не заполнено поле страны проживания!");
                return false;
            }
            if (user.City == "")
            {
                MessageBox.Show("Не заполнено поле города проживания!");
                return false;
            }
            if (user.Name.Length < 2)
            {
                MessageBox.Show("Не корректно введено имя пользователя");
                return false;
            }
            if (user.Surname.Length < 2)
            {
                MessageBox.Show("Не корректно введена фамилия пользователя");
                return false;
            }
            return true;
        }

        static public bool IsValidAddLot(LotInfo lot)
        {
            if(lot.Name == "")
            {
                MessageBox.Show("Не заполнено поле названия лота!");
                return false;
            }
            if (lot.Category == "")
            {
                MessageBox.Show("Не заполнено поле категории лота!");
                return false;
            }
            return true;
        }
    }
}

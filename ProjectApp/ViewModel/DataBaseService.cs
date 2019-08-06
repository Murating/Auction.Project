using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectApp.Model;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace ProjectApp.ViewModel
{
    static class DataBaseService
    {
        static string connectionString = @"Data Source=DESKTOP-I8IHKHB\SQLEXPRESS;Initial Catalog=ProjectAppDataBase; Integrated Security=True";
        //Добавление нового лота
        static public void AddNewLot(LotInfo lot)
        {
            try
            {
                string sqlCommand = "Select * from LotInfo";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    DataRow newRow = dt.NewRow();
                    newRow["nameLot"] = lot.Name;
                    newRow["category"] = lot.Category;
                    newRow["lotInfo"] = lot.Info;
                    newRow["startPrice"] = lot.StartPrice;
                    newRow["lotImage"] = LoadImage.BitmapImageToBytes(lot.LotImage);
                    dt.Rows.Add(newRow);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                    MessageBox.Show("Новый лот был добавлен");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        //Получения списка лотов из базы данных
        static public ObservableCollection<LotInfo> LoadLotsFromDataBase()
        {
            ObservableCollection<LotInfo> LotsCollection = new ObservableCollection<LotInfo>();
            byte[] dataImage;
            string sqlCommand = "Select * from LotInfo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tableLots = ds.Tables[0];
                int n = tableLots.Rows.Count;
                LotInfo[] Lot = new LotInfo[n];

                for (int i = 0; i < n; i++)
                {
                    Lot[i] = new LotInfo();
                    Lot[i].ID = (int)tableLots.Rows[i][0];
                    Lot[i].Name = (string)tableLots.Rows[i][1];
                    Lot[i].Category = (string)tableLots.Rows[i][2];
                    Lot[i].Info = (string)tableLots.Rows[i][3];
                    Lot[i].StartPrice = (int)tableLots.Rows[i][4];
                    dataImage = (byte[])tableLots.Rows[i][5];
                    Lot[i].LotImage = LoadImage.BytesToBitmapImage(dataImage);
                }
                for (int i = 0; i < n; i++)
                {
                    LotsCollection.Add(Lot[i]);
                }
            }
            return LotsCollection;
        }
        //Получение списка пользователей из базы данных
        static public ObservableCollection<User> LoadUsersFromDataBase()
        {
            ObservableCollection<User> UsersCollection = new ObservableCollection<User>();
            string sqlCommand = "Select * from Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tableLots = ds.Tables[0];
                ProjectApp.Model.User[] users = new ProjectApp.Model.User[10];
                
                for (int i = 0; i < 10; i++)
                {
                    users[i] = new User();
                    users[i].Login = (string)tableLots.Rows[i][0];
                    users[i].Password = (string)tableLots.Rows[i][1];
                    users[i].Name = (string)tableLots.Rows[i][2];
                    users[i].Surname = (string)tableLots.Rows[i][3];
                    users[i].Email = (string)tableLots.Rows[i][4];
                    users[i].County = (string)tableLots.Rows[i][5];
                    users[i].City = (string)tableLots.Rows[i][6];
                    users[i].PhoneNumber = (string)tableLots.Rows[i][7];
                }
                for (int i = 0; i < 10; i++)
                {
                    UsersCollection.Add(users[i]);
                }
            }
            return UsersCollection;
        }

        static public ObservableCollection<LotInfo> SortCollection(string strCommand)
        {
            ObservableCollection<LotInfo> LotsCollection = new ObservableCollection<LotInfo>();
            byte[] dataImage;
            string sqlCommand = "Select * from LotInfo " + strCommand;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tableLots = ds.Tables[0];
                int n = tableLots.Rows.Count;
                LotInfo[] Lot = new LotInfo[n];

                for (int i = 0; i < n; i++)
                {
                    Lot[i] = new LotInfo();
                    Lot[i].ID = (int)tableLots.Rows[i][0];
                    Lot[i].Name = (string)tableLots.Rows[i][1];
                    Lot[i].Category = (string)tableLots.Rows[i][2];
                    Lot[i].Info = (string)tableLots.Rows[i][3];
                    Lot[i].StartPrice = (int)tableLots.Rows[i][4];
                    dataImage = (byte[])tableLots.Rows[i][5];
                    Lot[i].LotImage = LoadImage.BytesToBitmapImage(dataImage);
                }
                for (int i = 0; i < n; i++)
                {
                    LotsCollection.Add(Lot[i]);
                }
            }
            return LotsCollection;
        }
        //Получаем список торгов из базы данных
        static public ObservableCollection<Bargaining> LoatBargaesFromDataBase()
        {
            ObservableCollection<Bargaining> bargaCollection = new ObservableCollection<Bargaining>();
            string sqlCommand = "Select * from Bargaining";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tableLots = ds.Tables[0];
                int n = tableLots.Rows.Count;
                Bargaining[] barga = new Bargaining[n];

                for (int i = 0; i < n; i++)
                {
                    barga[i] = new Bargaining();
                    barga[i].IdLot = (int)tableLots.Rows[i][1];
                    barga[i].StartAuction = (DateTime)tableLots.Rows[i][2];
                    barga[i].FinishAuction = (DateTime)tableLots.Rows[i][3];
                    barga[i].LoginOwner = (string)tableLots.Rows[i][4];
                    barga[i].LoginWinner = (string)tableLots.Rows[i][5];
                    barga[i].CurrentPrice = (int)tableLots.Rows[i][6];

                }
                for (int i = 0; i < n; i++)
                {
                    bargaCollection.Add(barga[i]);
                }
            }
            return bargaCollection;
        }
        //Добавление ставки на лот
        static public void SummAdd(int id, int sum)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = string.Format("UPDATE Bargaining SET currentPrice " +
                        "= currentPrice + {0} where idLot = {1}", sum, id);
                    command.Connection = connection;
                    command.ExecuteNonQuery();

                    command.CommandText = string.Format("UPDATE Bargaining SET loginWinner " +
                        "= '{0}' where idLot = {1}", currentUser.login, id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Сумма успешно обнавлена!");
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        //Проверка что в базе даных имеется пользователь с заданным логином
        static public bool IsUserExist(string userName)
        {
            string sqlCommand = string.Format("Select * from Users where loginUser = '{0}'", userName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Проверка авторизации
        static public bool IsUserTrue(string login, string password)
        {
            try
            {
                string sqlCommand = string.Format("Select * from Users where loginUser = '{0}' and passwordUser = '{1}'", login, password);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlCommand, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return false;
        }
        //Получить информацию о пользователе из базы данных по логину
        static public User GetUserInfo(string login)
        {
            User user = new User();
            string sqlCommand = string.Format("Select * from Users where loginUser = '{0}'", login);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Login = reader.GetString(0);
                    user.Password = reader.GetString(1);
                    user.Name = reader.GetString(2);
                    user.Surname = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.County = reader.GetString(5);
                    user.City = reader.GetString(6);
                    user.PhoneNumber = reader.GetString(7);
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
        //Добавление нового аукциона для лота
        static public void AddNewBargaining(Bargaining barga)
        {
            string sqlCommand = "Select * from Bargaining";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

                DataRow newRow = dt.NewRow();
                newRow["idLot"] = barga.IdLot;
                newRow["startAuction"] = barga.StartAuction;
                newRow["finishAuction"] = barga.FinishAuction;
                newRow["loginOwner"] = barga.LoginOwner;
                newRow["loginWinner"] = barga.LoginWinner;
                newRow["currentPrice"] = barga.CurrentPrice;
                dt.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);

            }
        }
        //Регистрация нового пользователя в базе данных
        static public void AddNewUser(User user)
        {
            try
            {
                if (!DataBaseService.IsUserExist(user.Login))
                {
                    string sqlCommand = "Select * from Users";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow newRow = dt.NewRow();
                        newRow["loginUser"] = user.Login;
                        newRow["passwordUser"] = user.Password;
                        newRow["name"] = user.Name;
                        newRow["surname"] = user.Surname;
                        newRow["email"] = user.Email;
                        newRow["country"] = user.County;
                        newRow["city"] = user.City;
                        newRow["phoneNumber"] = user.PhoneNumber;
                        dt.Rows.Add(newRow);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(ds);
                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким login уже существует!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        //Получить колличество записей
        static public int GetRowsCount()
        {
            string sqlExpression = "SELECT COUNT(*) FROM LotInfo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = command.ExecuteScalar();
                return (int)count;
            }
        }
        //Изменение учетной записи пользователя
        static public void ChangeUser(User newUser)
        {
            try
            {
                string sqlExpression = string.Format("delete from Users where loginUser = '{0}'", newUser.Login);
                string sqlExpr2 = string.Format("delete from Bargaining where loginOwner = '{0}'", newUser.Login);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connection);
                    command2.ExecuteScalar();
                    command.ExecuteScalar();
                }
                AddNewUser(newUser);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        //Изменение лота
        static public void ChangeLot(LotInfo lot)
        {
            try
            {
                string sqlExpression = string.Format("delete from LotInfo where ID = '{0}'", lot.ID);
                string sqlExpr2 = string.Format("delete from Bargaining where idLot = '{0}'", lot.ID);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlCommand command2 = new SqlCommand(sqlExpr2, connection);
                    command2.ExecuteScalar();
                    command.ExecuteScalar();
                }
                AddNewLot(lot);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }



        //Удаление лота по ID
        static public void DeleteLot(string ID)
        {
            string sqlExpression = string.Format("delete from LotInfo where ID = '{0}'", ID);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteScalar();
            }
        }
        //Удаление пользователя по логину
        static public void DeleteUser(string login)
        {
            string sqlExpression = string.Format("delete from Users where loginUser = '{0}'", login);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteScalar();
            }
        }

        static public int GetLastLotId()
        {
            int Id = 0;
            string sqlCommand = "select * from LotInfo where ID = (select max(ID) from LotInfo)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tableLots = ds.Tables[0];
                Id = (int)tableLots.Rows[0][0];
            }   
            return Id;
        }
    }
}

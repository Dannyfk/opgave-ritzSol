using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ritz
{
    public class Service
    {
        static Dal d = new Dal();
        static SqlConnection con = d.getConnection();
        DataTable drinksTable = null;
        private static Service instance;

        public static Service Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Service();
                }
                return instance;
            }
        }

        public DataTable getDrinkTable()
        {
            string sql = "select name as Navn, drinkPrice as Pris, picture as Billede from drink";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            drinksTable = new DataTable();
            da.Fill(drinksTable);

            return drinksTable;
        }

        // Hent alle drinks til GUI
        public static List<Image> getDrinks()
        {
            List<Image> images = new List<Image>();
            string sql = "SELECT name,picture FROM drink WHERE isAktive = 1";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"] as string;
                    byte[] img = (byte[])reader["picture"];
                    MemoryStream str = new MemoryStream();
                    str.Write(img, 0, img.Length);
                    System.Drawing.Bitmap bit = new System.Drawing.Bitmap(str);

                    MemoryStream ms = new MemoryStream();
                    bit.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();

                    Image i = new Image();
                    i.Source = bi;
                    i.Tag = name;
                    if (!images.Contains(i))
                        images.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return images;
        }

        // finder den samlede pris på valgte drinks
        public static int getTotalPrice(List<String> list)
        {
            int price = 0;

            foreach (string s in list)
            {
                string sql = "SELECT drinkPrice FROM DRINK WHERE name = '" + s + "'";

                int drinkPrice = executeQueryReturnInt(sql);
                price += drinkPrice;
            }

            return price;
        }

        public static int getDrinkPrice(String name)
        {
            string sql = "SELECT drinkPrice FROM DRINK WHERE name = '" + name + "'";

            int drinkPrice = executeQueryReturnInt(sql);

            return drinkPrice;
        }

        // finde værelses nummer
        public static List<int> getRoomNumbersAsInt()
        {
            List<int> roomNumbers = new List<int>();
            String sql = "SELECT roomNumber FROM roomReservation";
            DataTable dt = getDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int number = (int)dt.Rows[i]["roomNumber"];
                roomNumbers.Add(number);
            }

            return roomNumbers;
        }

        // finde værelses nummer
        public static List<string> getRoomNumbers()
        {
            List<string> roomNumbers = new List<string>();
            String sql = "SELECT roomNumber FROM roomReservation";
            DataTable dt = getDataTable(sql);

            roomNumbers.Add("All rooms");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String s = dt.Rows[i]["roomNumber"].ToString();
                roomNumbers.Add(s);
            }
            roomNumbers.Add(" ");

            return roomNumbers;
        }

        public static DataTable getDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error while reading database");
            }
            return dt;
        }

        public static int executeQueryReturnInt(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = (int)cmd.ExecuteScalar();
            con.Close();

            return result;
        }

        public static void executeQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();

            con.Close();
        }

        // Transaction methods - same connection
        public static int executeQueryReturnInt(string sql, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = (int)cmd.ExecuteScalar();

            return result;
        }

        public static void executeQuery(string sql, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();

        }

       

        public static DataTable getDrinksStock()
        {
            String sql = "SELECT name as Navn, inFridge as Køleskab, onStock as Lager FROM drink";
            return getDataTable(sql);
        }

        public void createDrink(string name, int price, byte[] picture)
        {
            SqlCommand command = new SqlCommand(
             "INSERT INTO drink (name, drinkPrice, picture, inFridge, onStock, isAktive) " +
             "Values(@Name, @Price, @Photo,0,0,0)", con);

            command.Parameters.Add("@Name",
               SqlDbType.NVarChar, 20).Value = name;

            command.Parameters.Add("@Price",
               SqlDbType.Int).Value = price;

            command.Parameters.Add("@Photo",
                SqlDbType.Image, picture.Length).Value = picture;

            executeQuery(command);
        }

        public void updateDrink(string oldname, string name, int price)
        {
            SqlCommand command = new SqlCommand(
             "Update drink SET name=@Name, drinkprice=@Price WHERE name=@OldName", con);

            command.Parameters.Add("@Name",
               SqlDbType.NVarChar, 20).Value = name;

            command.Parameters.Add("@Price",
               SqlDbType.Int).Value = price;

            command.Parameters.Add("@OldName",
               SqlDbType.NVarChar, 20).Value = oldname;

            executeQuery(command);
        }

        public void updateDrinkWithPicture(string oldname, string name, int price, byte[] picture)
        {
            SqlCommand command = new SqlCommand(
             "Update drink SET name=@Name, drinkprice=@Price, picture=@Picture WHERE name=@OldName", con);

            command.Parameters.Add("@Name",
               SqlDbType.NVarChar, 20).Value = name;

            command.Parameters.Add("@Price",
               SqlDbType.Int).Value = price;

            command.Parameters.Add("@Picture",
               SqlDbType.Image, picture.Length).Value = picture;

            command.Parameters.Add("@OldName",
               SqlDbType.NVarChar, 20).Value = oldname;

            executeQuery(command);
        }

        public void deleteDrink(string name)
        {
            SqlCommand command = new SqlCommand(
             "DELETE FROM drink WHERE name=@Name", con);

            command.Parameters.Add("@Name",
               SqlDbType.NVarChar, 20).Value = name;

            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drikkevaren kan ikke slettes da køb af den eksisterer i systemet");
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public void executeQuery(SqlCommand cmd)
        {
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        public Boolean fridgeAlarm(String s)
        {
            String sql = "SELECT inFridge FROM drink WHERE name='" + s + "'";
            int i = executeQueryReturnInt(sql);
            if (i <= 0)
                return true;
            else
                return false;
        }

        public static List<String> makeReceipt(List<String> list)
        {
            List<String> drinks = new List<string>();
            list.Sort();
            foreach(String s in list){
                String sql = "SELECT drinkPrice FROM drink WHERE name ='" + s + "'";
                int i = executeQueryReturnInt(sql);
                drinks.Add(s + "-" + i + "kr");
            }
            return drinks;
        }


        // køb på regning
        public static List<String> buyRoom(List<String> list, int id)
        {
            List<String> drinks = new List<string>();
            String sql2 = "";
            list.Sort();
            int inFridge = 0;
            int price = 0;
            int sum = 0;
            int totalSum = 0;
            int amount = 0;
            string drink = "";
            foreach (string s in list)
            {
                if (drink == "")
                    drink = s;
                String sql = "SELECT inFridge, drinkPrice FROM drink WHERE name = '" + s + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        inFridge = (int)reader["inFridge"];
                        price = (int)reader["drinkPrice"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
                if (inFridge != 0)
                {
                    sql2 = "INSERT INTO loungeBilling VALUES(" + id + ", '" + s + "'," + "getDate()" + ")";
                    executeQuery(sql2);

                    if (drink == s)
                    {
                        amount += 1;
                        sum += price;
                    }
                    else
                    {
                        if (amount != 0)
                        {
                            drinks.Add(drink + " x" + amount + " - " + sum + "kr");
                            totalSum += sum;
                            amount = 1;
                            sum = price;
                            drink = s;
                        }
                        else
                        {
                            amount += 1;
                            sum += price;
                            drink = s;
                        }
                    }
                }
                else
                {
                    if (amount != 0)
                    {
                        drinks.Add(drink + " x" + amount + " - " + sum + "kr");
                        totalSum += sum;
                        amount = 0;
                        sum = 0;
                        drink = s;
                    }
                }
            }
            String checkSql = "SELECT inFridge FROM drink WHERE name = '" + drink + "'";
            inFridge = executeQueryReturnInt(checkSql);
            if (inFridge != 0 && amount > 1)
            {
                checkSql = "UPDATE drink SET inFridge -=1 WHERE name='" + drink + "'";
                executeQuery(checkSql);
            }
            if (amount != 0)
            drinks.Add(drink + " x" + amount + " - " + sum + "kr");
            totalSum += sum;
            drinks.Add("Totalpris: " + totalSum + "kr");
            return drinks;
        }

        public static List<String> buyCash(List<String> list)
        {
            List<String> drinks = new List<string>();
            list.Sort();
            int inFridge = 0;
            int price = 0;
            int sum = 0;
            int totalSum = 0;
            int amount = 0;
            string drink = "";
            foreach (string s in list)
            {
                if (drink == "")
                    drink = s;
                String sql = "SELECT inFridge, drinkPrice FROM drink WHERE name = '" + s + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        inFridge = (int)reader["inFridge"];
                        price = (int)reader["drinkPrice"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }
                if (inFridge != 0)
                {
                    String sql2 = "UPDATE drink SET inFridge -=1 WHERE name='" + s + "'";
                    executeQuery(sql2);

                    if (drink == s)
                    {
                        amount += 1;
                        sum += price;
                    }
                    else
                    {
                        if (amount != 0)
                        {
                            drinks.Add(drink + " x" + amount + " - " + sum + "kr");
                            totalSum += sum;
                            amount = 1;
                            sum = price;
                            drink = s;
                        }
                        else
                        {
                            amount += 1;
                            sum += price;
                            drink = s;
                        }
                    }
                }
                else
                {
                    if (amount != 0)
                    {
                        drinks.Add(drink + " x" + amount + " - " + sum + "kr");
                        totalSum += sum;
                        amount = 0;
                        sum = 0;
                        drink = s;
                    }
                }
            }
            String checkSql = "SELECT inFridge FROM drink WHERE name = '" + drink + "'";
            inFridge = executeQueryReturnInt(checkSql);
            if (inFridge != 0 && amount>1)
            {
                String sql2 = "UPDATE drink SET inFridge -=1 WHERE name='" + drink + "'";
                executeQuery(sql2);
            }
            if(amount!=0)
            drinks.Add(drink + " x" + amount + " - " + sum + "kr");
            totalSum += sum;
            drinks.Add("Totalpris: " + totalSum + "kr");
            return drinks;
        }
    }
}

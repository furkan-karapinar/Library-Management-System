using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    internal class Database_Control
    {
        // Veritabanı adı ve konumu
        string path = "database.db", cs = @"URI=file:" + Application.StartupPath + "\\database.db";

        // Gerekli tanımlamalar
        SQLiteConnection data_connection;
        SQLiteCommand command;
        SQLiteDataReader reader;



        


        #region Books
        public bool Add_Book(Book book)
        {
            try
            {
                if (Control_Item("books", "isbn", book.ISBN) != 0)
                {
                   
                    return false;
                }
                else
                {
                    var con = new SQLiteConnection(cs);
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    cmd.CommandText = "INSERT INTO books (title, author, category, isbn, barcode) VALUES(@title , @author , @category , @isbn , @barcode)";
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@category", book.Category);
                    cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                    cmd.Parameters.AddWithValue("@barcode", book.Barcode);

                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    return true;
                }
            }
            catch {  return false; }
        }

        public bool Edit_Book(Book book)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "UPDATE books SET title=@title , author=@author , barcode=@barcode , category=@category WHERE isbn=@isbn";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@barcode", book.Barcode);
                cmd.Parameters.AddWithValue("@category", book.Category);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
        }

        public bool Delete_Book(Book book)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM books WHERE isbn=@isbn";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
                return true;
            }
            catch { return false; }
        }

        public DataTable List_Books(string filter)
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                string query = $"SELECT books.id, books.title AS Title,books.author AS Author, categories.name AS Category,books.barcode AS Barcode,books.isbn AS ISBN FROM books INNER JOIN categories ON categories.id = books.category WHERE isbn LIKE '%{filter}%' OR barcode LIKE '%{filter}%'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                       
                    }
                }
            }

            return dataTable;
        }


        #endregion

        public bool Add_Orders(string memberId, string bookId, DateTime dateIssued, DateTime deliveryDate)
        {
            try
            {


                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
                {
                    connection.Open();


                    string insertQuery = $"INSERT INTO orders (member, book, date_issued, delivery_date, is_returned) " +
                                         $"VALUES ({memberId}, {bookId}, '{dateIssued.ToString("yyyy-MM-dd")}', " +
                                         $"'{deliveryDate.ToString("yyyy-MM-dd")}', {0})";

                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            } catch (Exception) { return false; }
            return false;
        }


        #region Categories
        public bool Add_Category(Category category)
        {
            try
            {
                if (Control_Item("categories", "name", category.Name) != 0)
                {
                    
                    return false;
                }
                else
                {
                    var con = new SQLiteConnection(cs);
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    cmd.CommandText = "INSERT INTO categories (name) VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", category.Name);

                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    return true;
                }
            }
            catch {  return false; }
        }

        public bool Edit_Category(Category category, int id)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "UPDATE categories SET name=@name WHERE id=@id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch {  return false; }
        }

        public bool Delete_Category(int id)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM categories WHERE id=@id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
                return true;
            }
            catch { return false; }
        }

        public DataTable List_Categories()
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                
                string query = "SELECT * FROM categories";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable List_Categories(string filter)
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                string query = $"SELECT id AS Id , name AS Name FROM categories WHERE name LIKE '%{filter}%'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable List_Categories_With_CheckBox(string filter)
        {
            DataTable dataTable = new DataTable();

            
            DataColumn checkBoxColumn = new DataColumn("Select", typeof(bool));
            checkBoxColumn.DefaultValue = false;
            dataTable.Columns.Add(checkBoxColumn);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                string query = $"SELECT books.id, books.title AS Title, books.author AS Author, categories.name AS Category, books.barcode AS Barcode, books.isbn AS ISBN FROM books INNER JOIN categories ON books.category = categories.id WHERE books.title LIKE '%{filter}%'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        #endregion


        #region Members
        public bool Add_Member(Member member)
        {
            try
            {
                if (Control_Item("members", "id", member.id) != 0)
                {
                   
                    return false;
                }
                else
                {
                    var con = new SQLiteConnection(cs);
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    cmd.CommandText = "INSERT INTO members (id,name,surname,phone,address) VALUES(@id , @name , @surname , @phone , @address)";
                    cmd.Parameters.AddWithValue("@id", member.id);
                    cmd.Parameters.AddWithValue("@name", member.name);
                    cmd.Parameters.AddWithValue("@surname", member.surname);
                    cmd.Parameters.AddWithValue("@phone", member.phone);
                    cmd.Parameters.AddWithValue("@address", member.address);

                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    return true;
                }
            }
            catch { return false; }
        }

        public bool Edit_Member(Member member)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "UPDATE members SET address=@address , name=@name , surname=@surname , phone=@phone WHERE id=@id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", member.id);
                cmd.Parameters.AddWithValue("@name",member.name);
                cmd.Parameters.AddWithValue("@surname", member.surname);
                cmd.Parameters.AddWithValue("@address", member.address);
                cmd.Parameters.AddWithValue("@phone", member.phone);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch {  return false; }
        }

        public bool Delete_Member(Member member)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM members WHERE id=@id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", member.id);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
                return true;
            }
            catch { return false; }
        }

        public DataTable List_Members()
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                // Books tablosundan verileri seç
                string query = "SELECT * FROM members";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable List_Members(string filter)
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                string query = $"SELECT id AS Id, name AS Name, surname AS Surname, phone AS Phone, address AS Address FROM members WHERE id LIKE '%{filter}%' OR name LIKE '%{filter}%'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        #endregion


        #region Orders

        public DataTable List_Orders(string filter, int search_type)
        {
            
            DataTable dataTable = new DataTable();


            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                string query = "";
                if (search_type == 0) 
                {
                    query = $"SELECT orders.order_no AS 'Order No' , orders.date_issued AS 'Date Issued' , orders.delivery_date AS 'Delivery Date', orders.member AS 'Member ID', members.name AS Name, members.surname AS Surname , members.phone AS Phone, members.address AS Address, books.title AS Title, books.author AS Author, " +
                    $"categories.name AS Category, books.barcode AS Barcode, books.isbn AS ISBN From orders Inner Join members On members.id = orders.member " +
                    $"Inner Join books On orders.book = books.id Inner Join categories On books.category = categories.id " +
                    $"WHERE orders.is_returned = 0 AND (books.title LIKE '%{filter}%' OR members.name LIKE '%{filter}%')";
                }
                else if (search_type == 1)
                {
                    query = $"SELECT orders.order_no AS 'Order No' , orders.date_issued AS 'Date Issued' , orders.delivery_date AS 'Delivery Date', orders.member AS 'Member ID', members.name AS Name, members.surname AS Surname , members.phone AS Phone, members.address AS Address, books.title AS Title, books.author AS Author, " +
                    $"categories.name AS Category, books.barcode AS Barcode, books.isbn AS ISBN From orders Inner Join members On members.id = orders.member " +
                    $"Inner Join books On orders.book = books.id Inner Join categories On books.category = categories.id " +
                    $"WHERE date(orders.delivery_date) < date('now') AND orders.is_returned = 0 AND (books.title LIKE '%{filter}%' OR members.name LIKE '%{filter}%')";
                }
                else
                {
                    query = $"SELECT orders.order_no AS 'Order No' , orders.date_issued AS 'Date Issued' , orders.delivery_date AS 'Delivery Date', orders.member AS 'Member ID', members.name AS Name, members.surname AS Surname , members.phone AS Phone, members.address AS Address, books.title AS Title, books.author AS Author, " +
                    $"categories.name AS Category, books.barcode AS Barcode, books.isbn AS ISBN From orders Inner Join members On members.id = orders.member " +
                    $"Inner Join books On orders.book = books.id Inner Join categories On books.category = categories.id " +
                    $"WHERE date(orders.delivery_date) >= date('now') AND orders.is_returned = 0 AND (books.title LIKE '%{filter}%' OR members.name LIKE '%{filter}%')";
                }
                

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public bool Receive_Book(Order order)
        {
            try
            {
                string updateQuery = $"UPDATE orders SET is_returned = 1 WHERE order_no = {order.Order_Number} AND member = {order.Member} AND book = {GetBookID(order.Book)}";

                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                
            } catch (Exception) { return false; }
            return false;
        }
        #endregion

        #region Get Data
        public int GetBookID(Book book)
        {
            int bookID = -1; 
            string selectQuery = $"SELECT id FROM books WHERE title = '{book.Title}' AND author = '{book.Author}' AND barcode = '{book.Barcode}'";

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        
                        bookID = Convert.ToInt32(result);
                    }
                }
            }

            return bookID;
        }

        #endregion


        public int Control_Item(String datatable_name, String database_item_name, String item_name)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "SELECT COUNT(*) FROM " + datatable_name + " WHERE " + database_item_name + " ='" + item_name + "'";

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Cancel();
                return count;
            }
            catch { return 0; }



        }

    }
}

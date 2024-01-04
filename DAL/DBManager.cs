namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
public class DBManager{

    public static List<softdrink> GetAllDrink(){
        List<softdrink>ord=new List<softdrink>();
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString="server=LocalHost;port=3306;user=root;password=Shubham@242#;database=db4";
        string query="select * from softdrink";
        MySqlCommand command=new MySqlCommand(query,conn);
        try{
            conn.Open();
            MySqlDataReader reader=command.ExecuteReader();
            
            while(reader.Read()){
                softdrink s=new softdrink();
                int ID=int.Parse(reader["ID"].ToString());
                string NAME=reader["NAME"].ToString();
                int RATE=int.Parse(reader["RATE"].ToString());
                s.ID=ID;
                s.NAME=NAME;
                s.RATE=RATE;
                ord.Add(s);
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return ord;
    }


    public static bool Insert(int Id,string Name,int Rate){
         MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString="server=LocalHost;port=3306;user=root;password=Shubham@242#;database=db4";
        string query="insert into softdrink values(@Id,@Name,@Rate)";
        try{
            MySqlCommand command=new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@Id",Id);
            command.Parameters.AddWithValue("@Name",Name);
            command.Parameters.AddWithValue("@Rate",Rate);
            conn.Open();
            int n=command.ExecuteNonQuery();
            if(n>0){
                return true;
            }
            else{
                return false;
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return false;
    }
    public static bool Delete(int Id){
         MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString="server=LocalHost;port=3306;user=root;password=Shubham@242#;database=db4";
        string query="delete from softdrink where @Id=Id";
        try{
            MySqlCommand command=new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@Id",Id);
            conn.Open();
            int n=command.ExecuteNonQuery();
            if(n>0){
                return true;
            }
            else{
                return false;
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return false;
    }
    public static List<softdrink> GetById(int Id){
        List<softdrink>ord=new List<softdrink>();
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString="server=LocalHost;port=3306;user=root;password=Shubham@242#;database=db4";
        string query="select * from softdrink where ID=@Id";
        try{
            MySqlCommand command=new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@Id",Id);
            conn.Open();
            MySqlDataReader reader=command.ExecuteReader();
            while(reader.Read()){
                
                softdrink s=new softdrink();
                int ID=int.Parse(reader["ID"].ToString());
                string NAME=reader["NAME"].ToString();
                int RATE=int.Parse(reader["RATE"].ToString());
                s.ID=ID;
                s.NAME=NAME;
                s.RATE=RATE;
                ord.Add(s);

            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return ord;

    } 
}
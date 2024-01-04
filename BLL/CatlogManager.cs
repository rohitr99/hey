namespace BLL;
using DAL;
using BOL;
public class CatlogManager{

    public List<softdrink> GetDrinks(){
        List<softdrink>lst=new List<softdrink>();
        lst=DBManager.GetAllDrink();
        return lst;
    }

    public static bool Insert(int Id,string Name,int Rate){
        return DBManager.Insert(Id,Name,Rate);
    }

    public static bool Delete(int Id){
        return DBManager.Delete(Id);
    }
    public List<softdrink> GetById(int Id){
        List<softdrink>lst=DBManager.GetById(Id);
        return lst;
    }
}
using Azure;
using Azure.Data.Tables;

public class MenuTable : ITableEntity
{
   
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }

   
    public ETag ETag { get; set; }

    
    public DateTimeOffset? Timestamp { get; set; }

  
    public string Day { get; set; }
    public string KoldRet { get; set; }
    public string VarmRet { get; set; }

    
    public MenuTable(string day, string coldDish, string hotDish)
    {
        Day = day;
        KoldRet = coldDish;
        VarmRet = hotDish;
        PartitionKey = day; 
        RowKey = day;      
    }

    
    public MenuTable() { }
}

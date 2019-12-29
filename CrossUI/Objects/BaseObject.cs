namespace CrossUI.Objects
{
    public class BaseObject
    {
        public BaseObject(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
        
        public BaseObject Parent { get; set; }
    }
}
namespace Task_3
{
    public interface ISecuritySystem
    {
        bool HasAccessToTheHouse(int Id);

        event EventHandler<DoorVisitor> SomeOneAtTheDoor;

        void LeaveMessageOnDoorBell(string msg);
    }


    public class DoorVisitor : EventArgs
    {
        public int VisitorId { get; set; }

    }

}

namespace Triggers
{
    interface IChild
    {
        bool Finished();
        void StartUp();
        void Action();
        void AfterAction();
    }
}

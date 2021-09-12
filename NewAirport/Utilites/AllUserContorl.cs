using NewAirport.VVM.Editer;
using NewAirport.VVM.Editer.ModelEditer;
using NewAirport.VVM.Editor.Schedule;
using NewAirport.VVM.Schedule;
using System.Windows.Controls;

namespace NewAirport.Utilites
{
    public enum ALLUC
    {
        ScheduleUC,
        EditerUC,
        ModelEditerUC,
        ScheduleEditerUC
    }
    class AllUserContorl : IAllUserControl
    {
        private ScheduleUC scheduleUC;
        private EditerUC editerUC;
        private ModelEditerUC modelEditerUC;
        private ScheduleEditerUC scheduleEditerUC;

        public UserControl GetUC(ALLUC uc)
        {
            return uc switch
            {
                ALLUC.ScheduleUC => scheduleUC ??= new ScheduleUC(),
                ALLUC.EditerUC => editerUC ??= new EditerUC(),
                ALLUC.ModelEditerUC => modelEditerUC ??= new ModelEditerUC(),
                ALLUC.ScheduleEditerUC => scheduleEditerUC ??= new ScheduleEditerUC(),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}

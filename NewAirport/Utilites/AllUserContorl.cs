using NewAirport.VVM.Editer;
using NewAirport.VVM.Editor.Schedule;
using NewAirport.VVM.Schedule;
using System.Windows.Controls;
using NewAirport.VVM.Editor.Libruary;
using NewAirport.VVM.Editor.Template;
using NewAirport.VVM.MenuAndContent;
using NewAirport.VVM.SelectCurrentCity;
using NewAirport.VVM.TemplateList;

namespace NewAirport.Utilites
{
    public enum ALLUC
    {
        SelectCurrentCityUC,
        MenuAndContentUC,
        ScheduleUC,
        EditerUC,
        TemplateEditorUC,
        ScheduleEditerUC,
        TemplatesUC,
        LibraryEditerUC
    }
    class AllUserContorl : IAllUserControl
    {
        private TemplateListUC templateListUC;
        private SelectCurrentCityUC selectCurrentCityVM;
        private MenuAndContentUC menuUC;
        private ScheduleUC scheduleUC;
        private EditerUC editerUC;
        private TemplateEditorUC _templateEditorUC;
        private ScheduleEditerUC scheduleEditerUC;
        private LibraryEditorUC _libraryEditorUc;

        public UserControl GetUC(ALLUC uc)
        {
            return uc switch
            {
                ALLUC.SelectCurrentCityUC => selectCurrentCityVM ??= new SelectCurrentCityUC(),
                ALLUC.MenuAndContentUC => menuUC ??= new MenuAndContentUC(),
                ALLUC.ScheduleUC => scheduleUC ??= new ScheduleUC(),
                ALLUC.EditerUC => editerUC ??= new EditerUC(),
                ALLUC.TemplateEditorUC => _templateEditorUC ??= new TemplateEditorUC(),
                ALLUC.ScheduleEditerUC => scheduleEditerUC ??= new ScheduleEditerUC(),
                ALLUC.TemplatesUC => templateListUC ??= new TemplateListUC(),
                ALLUC.LibraryEditerUC => _libraryEditorUc ??= new LibraryEditorUC(),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}

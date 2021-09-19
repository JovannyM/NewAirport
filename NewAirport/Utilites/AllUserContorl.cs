﻿using NewAirport.VVM.Editer;
using NewAirport.VVM.Editer.ModelEditer;
using NewAirport.VVM.Editor.Schedule;
using NewAirport.VVM.Schedule;
using System.Windows.Controls;
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
        ModelEditerUC,
        ScheduleEditerUC,
        TemplatesUC
    }
    class AllUserContorl : IAllUserControl
    {
        private TemplateListUC templateListUC;
        private SelectCurrentCityUC selectCurrentCityVM;
        private MenuAndContentUC menuUC;
        private ScheduleUC scheduleUC;
        private EditerUC editerUC;
        private ModelEditerUC modelEditerUC;
        private ScheduleEditerUC scheduleEditerUC;

        public UserControl GetUC(ALLUC uc)
        {
            return uc switch
            {
                ALLUC.SelectCurrentCityUC => selectCurrentCityVM ??= new SelectCurrentCityUC(),
                ALLUC.MenuAndContentUC => menuUC ??= new MenuAndContentUC(),
                ALLUC.ScheduleUC => scheduleUC ??= new ScheduleUC(),
                ALLUC.EditerUC => editerUC ??= new EditerUC(),
                ALLUC.ModelEditerUC => modelEditerUC ??= new ModelEditerUC(),
                ALLUC.ScheduleEditerUC => scheduleEditerUC ??= new ScheduleEditerUC(),
                ALLUC.TemplatesUC => templateListUC ??= new TemplateListUC(),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}

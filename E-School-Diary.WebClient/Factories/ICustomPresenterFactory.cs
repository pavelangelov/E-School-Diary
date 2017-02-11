using System;

using WebFormsMvp;

namespace E_School_Diary.WebClient.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}

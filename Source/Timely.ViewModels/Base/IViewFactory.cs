// -----------------------------------------------------------------------
// <copyright file="IViewFactory.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.Base
{
    public interface IViewFactory<T>
        where T : IView
    {
        T Create();
        
        T Create(IViewModel dataContext);
    }
}
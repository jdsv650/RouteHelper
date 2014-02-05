using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDLRouteHelper.Models;

namespace CDLRouteHelper.Adapters.Interface
{
    interface IRestrictedAdapter
    {
 
        void SaveCreateViewModel(CreateViewModel cvm);

        void DropBridge(CreateViewModel cvm);

        CreateViewModel GetCreateViewModel(RetrieveViewModel rvm);

        List<CreateViewModel> GetListViewModel(Models.RetrieveViewModel rvm);
   
        void UpdateCreateViewModel(CreateViewModel cvm);

        DisplayRestrictedViewModel GetDisplayRestrictedViewModel(RestrictedIndexViewModel rivm);

        DisplayRestrictedViewModel GetDisplayRestrictedViewModelByCityAndState(Models.RetrieveByCityViewModel rbcvm);
    }
}

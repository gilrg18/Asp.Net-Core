using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents
{
    //[ViewComponent] //Optional Atribute
    public class TableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() //green underline because we are not using an await keyword in the logic
        {
            return View(); //invoked a partial view Views/Shared/Components/Table/Default.cshtml
        }
    }
}

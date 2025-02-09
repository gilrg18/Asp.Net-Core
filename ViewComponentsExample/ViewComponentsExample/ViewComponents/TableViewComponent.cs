﻿using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    //[ViewComponent] //Optional Atribute
    public class TableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonTableModel table) //green underline because we are not using an await keyword in the logic
        {
            //PersonTableModel personTableModel = new PersonTableModel()
            //{
            //    TableTitle = "Persons List",
            //    Persons = new List<Person>() {
            //        new Person() { Name = "Gil", JobTitle =  "Programmer" },
            //        new Person() { Name = "Gil2", JobTitle =  "Programmer2" },
            //        new Person() { Name = "Gil3", JobTitle =  "Programmer3" }
            //    }
            //};
            //ViewBag.Table = model;
            return View("Sample", table); //invoked a partial view Views/Shared/Components/Table/Sample.cshtml
        }
    }
}

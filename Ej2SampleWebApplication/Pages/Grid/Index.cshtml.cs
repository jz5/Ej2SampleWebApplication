using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ej2SampleWebApplication
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Flag { get; set; }
    }

    public class IndexModel : PageModel
    {
        public List<ItemViewModel> Items = new List<ItemViewModel>();

        public void OnGet()
        {
            for (var i = 0; i < 10; i++)
            {
                Items.Add(new ItemViewModel
                {
                    Id = 100 + i,
                    Name = $"Item_{i}",
                    UpdateTime = DateTime.Now.AddDays(-i),
                });
            }
        }

        public IActionResult OnPostUpdate([FromBody]int id)
        {
            var item = new ItemViewModel
            {
                Id = id,
                UpdateTime = DateTime.Now,
                Flag = true
            };

            return new JsonResult(item);
        }
    }
}
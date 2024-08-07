﻿

namespace WebStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Display(Name = "Category Order")]
        [UniqueOrder]
        public int CategoryOrder {  get; set; }
    }
}

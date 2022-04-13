using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObj
    {
        public static void Initial(AddDb content)
        {
            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Tovar.Any())
            {
                content.AddRange(
                      new Tovar { name = "Brusko", sdesk = "45mg", ldesk = "nihuevo", img = "https://avatars.mds.yandex.net/i?id=2a00000179e3270a72c18fe5b794bc6716fc-4883974-images-thumbs&n=13", price = 15, isF = true, available = true, Category = Categories["salt"] },
                    new Tovar { name = "Huski", sdesk = "45mg", ldesk = "holodok", img = "https://avatars.mds.yandex.net/i?id=2a00000179e3270a72c18fe5b794bc6716fc-4883974-images-thumbs&n=13", price = 15, isF = false, available = true, Category = Categories["salt"] },
                    new Tovar { name = "Boshki", sdesk = "20mg", ldesk = "shiiish", img = "https://avatars.mds.yandex.net/i?id=2a00000179e3270a72c18fe5b794bc6716fc-4883974-images-thumbs&n=13", price = 15, isF = true, available = true, Category = Categories["salt"] }
                    );
            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category>Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                     new Category { name = "salt", desk = "viebet silno" },
                    new Category { name = "nesalt", desk = "viebet slabo" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category item in list)
                    {
                        category.Add(item.name, item);
                    }
                }
                return category;
            }
        }
    }
}

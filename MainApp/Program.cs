using Domain.Entities;
using Infrastructure.Services;

//Users

UsersService uServ = new UsersService();

Users us1 = new Users(){
    FullName = "Safarov Muhammad",
    Email = "safarov11",
    Phone = "000080864"
};

Users us2 = new Users(){
    FullName = "Abdullo Urazov",
    Email = "urazov01",
    Phone = "900010009"
};

Users us3 = new Users(){
    FullName = "Muhammad Hakimov",
    Email = "hakimov07",
    Phone = "010101010"
};
// uServ.AddUser(us1);
// uServ.AddUser(us2);
// uServ.AddUser(us3);

Users us1Upd = new Users(){
    Id = 1,
    FullName = "Safarov Muhammadsharif",
    Email = "safarov11",
    Phone = "882891919"
};
// uServ.UpdateUsers(us1Upd);

// uServ.DeleteUser(1);

var users = uServ.GetAllUsers();
foreach (var u in users)
{
    System.Console.WriteLine($"{u.Id}\t{u.FullName}\t{u.Email}\t{u.Phone}");
}

System.Console.WriteLine("\n-----------------------------------\n");
//Markets
MarketsService mServ = new MarketsService();
Markets mk1 = new Markets(){
    Name = "Dastras",
    Address ="Profsoyuz"
};
Markets mk2 = new Markets(){
    Name = "Yovar",
    Address ="Slovyanskiy"
};
Markets mk3 = new Markets(){
    Name = "Paykar",
    Address ="Profsoyuz"
};

// mServ.AddMarket(mk1);
// mServ.AddMarket(mk2);
// mServ.AddMarket(mk3);

Markets mk3upd = new Markets(){
    Id = 3,
    Name = "Paykar",
    Address ="Sadbarg"
};
// mServ.UpdateMarkets(mk3upd);

// mServ.DeleteMarket(2);

var markets = mServ.GetAllMarkets();
foreach (var m in markets)
{
    System.Console.WriteLine($"{m.Id}\t{m.Name}\t{m.Address}");
}

System.Console.WriteLine("\n-----------------------------------\n");

//category
CategoryService cServ = new CategoryService();
Category cat1 = new Category(){
    Name = "Ovoshi"
};
Category cat2 = new Category(){
    Name = "Napitki"
};
Category cat3 = new Category(){
    Name = "Vipechka"
};
// cServ.AddCategory(cat1);
// cServ.AddCategory(cat2);
// cServ.AddCategory(cat3);

Category cat1Upd = new Category(){
    Id = 1,
    Name = "Ovoshi i frukti"
};
// cServ.UpdateCategory(cat1Upd);

// cServ.DeleteCategory(3);

var categories = cServ.GetAllCategories();
foreach (var c in categories)
{
    System.Console.WriteLine($"{c.Id}\t{c.Name}");
}

System.Console.WriteLine("\n-----------------------------------\n");

//Products
ProductsService pServ = new ProductsService();
Products p1 = new Products
{
    Name = "Bulochka",
    Price = 9.99m,
    Quantity = 10,
    CategoryId = 3,
    MarketId = 1
};
Products p2 = new Products
{
    Name = "Siyoma cola",
    Price = 8.50m,
    Quantity = 15,
    CategoryId = 2,
    MarketId = 2
};
Products p3 = new Products
{
    Name = "Arbuz",
    Price = 49.99m,
    Quantity = 30,
    CategoryId = 1,
    MarketId = 3
};
// pServ.AddProduct(p1);
// pServ.AddProduct(p2);
// pServ.AddProduct(p3);


Products p2Upd = new Products
{
    Id = 2,
    Name = "Dyushes",
    Price = 8.00m,
    Quantity = 40,
    CategoryId = 2,
    MarketId = 3
};
// pServ.UpdateProducts(p2Upd);

// pServ.DeleteProduct(3);

var products = pServ.GetAllProducts();
foreach (var p in products)
{
    System.Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Price}\t{p.CategoryId}\t{p.MarketId}\t{p.Quantity}");
}

System.Console.WriteLine("\n-----------------------------------\n");



var uss = uServ.GetUserByNameOrEmail("safar");
foreach (var u in uss)
{
    System.Console.WriteLine($"{u.Id}\t{u.FullName}\t{u.Email}\t{u.Phone}");
}

System.Console.WriteLine("\n-----------------------------------\n");

var categoryCount = cServ.GetCategoryWithCount();
foreach (var ct in categoryCount)
{
    System.Console.WriteLine($"{ct.Name}\t{ct.CategoryCount}");
}

System.Console.WriteLine("\n-----------------------------------\n");

pServ.UpdatePricesByCategoryId(2,20);
var prodAfterUpdate = pServ.GetAllProducts();
foreach (var p in prodAfterUpdate)
{
    System.Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Price}\t{p.CategoryId}\t{p.MarketId}\t{p.Quantity}");
}

System.Console.WriteLine("\n-----------------------------------\n");


var SumPriceProds = pServ.GetSumPriceOfProductsByMarketId();
foreach (var p in SumPriceProds)
{
    System.Console.WriteLine($"{p.ProductName}\t{p.MarketName}\t{p.SumPrice}");
}


// uServ.AddDateTimeToUsers();
// cServ.AddDateTimeToCategory();
// mServ.AddDateTimeToMarket();
// pServ.AddDateTimeToProducts();

System.Console.WriteLine("\n-----------------------------------\n");

// mServ.CreateNewColumnforUserId();
// mServ.AddUserToMarket(1,1);
// mServ.AddUserToMarket(2,2);
// mServ.AddUserToMarket(3,3);

System.Console.WriteLine("\n-----------------------------------\n");

var usersMCount = uServ.UsersAndMarketsCount();
foreach (var u in usersMCount)
{
    System.Console.WriteLine($"{u.UserName}\t{u.MarketCount}");
}

System.Console.WriteLine("\n-----------------------------------\n");

var listpr = pServ.GetProdWithSmallestQoantity();
if(listpr != null){
    foreach (var p in listpr)
    {
        System.Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Price}\t{p.CategoryId}\t{p.MarketId}\t{p.Quantity}");
    }
}
else System.Console.WriteLine("Empty list");

System.Console.WriteLine("\n-----------------------------------\n");











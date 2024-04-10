@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
<a asp-controller="home" asp-action="details" asp-route-id="@amigo.Id" class="btn btn-primary">View Details</a>
<img class="card-img-top" src="~/images/nezukoBaby.jpg" asp-append-version="true" />
<environment include="Development">
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
</environment>
<environment exclude="Development">
    <link rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN"
        crossorigin="anonymous"
        asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
        asp-fallback-test-class="sr-only"
        asp-fallback-test-property="position"
        asp-fallback-test-value="absolute"
        asp-suppress-fallback-integrity="true"/>
</environment>

[HttpPost]
public RedirectToActionResult Create(Friend friend)
{
    Friend friendCreated = _friendRepository.Create(friend);
    return RedirectToAction("details", new {id = friendCreated.Id});
}

builder.Services.AddScoped<IFriendRepository, MockFriendRepository>();

public class Friend
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Required"), MaxLength(100, ErrorMessage = "The Name must be least than 100")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Email")]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Email Wrong Format")]
    public string Email { get; set; }
    [Required(ErrorMessage = "You must select a skill from the list")]
    public SkillEnum? Skill { get; set; }
}

@model Friend
@{
    ViewBag.Title = "Create Friend";
}

<form asp-asp-controller="Home" asp-action="Create" method="post" class="m-2">
    <div asp-validation-summary="All" class="text-danger"></div>
    <div class="form-group row">
        <label asp-for="Name" class="col-sm-2 col-form-label"></label>
        <div class="col-sm-10">
            <input asp-for="Name" class="form-control" placeholder="Name" />
            <span asp-validation-for="Name" class="text-danger"></span>
        </div>
    </div>
    <div class="form-group row">
        <label asp-for="Email" class="col-sm-2 col-form-label"></label>
        <div class="col-sm-10">
            <input asp-for="Email" class="form-control" placeholder="E-mail" />
            <span asp-validation-for="Email" class="text-danger"></span>
        </div>
    </div>
    <div class="form-group row">
        <label asp-for="Skill" class="col-sm-2 col-form-label"></label>
        <div class="col-sm-10">
            <select asp-for="Skill" class="custom-select mr-sm-2" asp-items="Html.GetEnumSelectList<SkillEnum>()">
                <option value="">Choose one</option>
            </select>
            <span asp-validation-for="Skill" class="text-danger"></span>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-10">
            <button type="submit" class="btn btn-primary">New Friend</button>
        </div>
    </div>
</form>

[HttpPost]
public IActionResult Create(Friend friend)
{
    if (ModelState.IsValid)
    {
        Friend friendCreated = _friendRepository.Create(friend);
        return RedirectToAction("details", new { id = friendCreated.Id });
    }
    return View();
}

https://www.smartgroup-us.com/ (2 vacantes)
https://intechenergy.net/ ()

Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

"ConnectionStrings": {
    "ConnectionSQL": "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
  }

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").GetSection("ConnectionSQL").Value;
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionStrings));

using Microsoft.EntityFrameworkCore;

namespace CoreWebAppMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasData(new Friend
            {
                Id = 1,
                Name = "Test",
                Email = "test@test.com.ar",
                Skill = SkillEnum.Demon
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
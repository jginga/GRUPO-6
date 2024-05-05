using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MeetingRoomBooking.Data
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
    }

}

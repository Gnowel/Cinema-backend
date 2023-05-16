using Core.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SeatSeed
    {
        public static async Task SeedAsync(CinemaContext context)
        {
            try
            {
                //byte[] bytes = File.ReadAllBytes("F:\\Project\\School\\Web\\Cinema Frontend and Backend\\Cinema\\Infrastructure\\46543.jpg");
                //Movie movie = new Movie()
                //{
                //    Title = "Зеленая миля",
                //    ReleaseData = new DateTime(1999, 12, 6),
                //    Director = "Фрэнк Дарабонт",
                //    Time = new TimeSpan(3,9,0),
                //    Synopsis = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.",
                //    Poster = bytes,
                //    AgeRestriction = 16
                //};
                //Country country = context.Find<Country>(1);
                //Genre genre = context.Find<Genre>(1);
                //Genre genre1 = context.Find<Genre>(1002);
                //Genre genre2 = context.Find<Genre>(1003);

                //movie.Countries.Add(country);
                //movie.Genres.Add(genre);
                //movie.Genres.Add(genre1);
                //movie.Genres.Add(genre2);
                //context.Add(movie);

                //SessionRepository repository = new SessionRepository(context);
                //HallRepository hallRepository = new HallRepository(context);

                //Hall hall = await hallRepository.GetById(1);
                //Session session = await repository.GetSessionById(9);
                //List<Seat> seat = new List<Seat>();

                //for (int i = 0; i < 8; i++)
                //{
                //    for (int j = 0; j < 8; j++)
                //    {
                //        seat.Add(new Seat
                //        {
                //            Hall = hall,
                //            Session = session,
                //            RowNumber = i + 1,
                //            SeatNumber = j + 1,
                //            Status = false
                //        });
                //    }
                //}

                //foreach (var s in seat)
                //{
                //    context.Seats.Add(s);
                //}

                //await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

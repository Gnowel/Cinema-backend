using Core.Entities;
using Infrastructure.Context;

namespace Infrastructure.Data
{
    public static class CinemaContextSeed
    {
        public static async Task SeedAsync(CinemaContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Genres.Any() && context.Countries.Any() && context.Movies.Any())
                {
                    return;
                }

                var countries = new Country[]
                {
                    new Country{Name = "США"},
                    new Country{Name = "Великобритания"},
                    new Country{Name = "Китай"},
                    new Country{Name = "Канада"}

                };
                foreach(var country in countries)
                {
                    context.Countries.Add(country);
                }

                var genres = new Genre[]
                {
                    new Genre { Name = "драма" },
                    new Genre { Name = "комедия" },
                    new Genre { Name = "фантастика"},
                    new Genre { Name = "приключения"}
                };

                foreach (var genre in genres)
                {
                    context.Genres.Add(genre);
                }

                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title = "Однажды в… Голливуде",
                        Countries = new List<Country>()
                        {
                            countries[0],
                            countries[1],
                            countries[2]
                        },
                        ReleaseData = new DateTime(2019, 5, 21),
                        Director = "Квентин Тарантино",
                        Time = new TimeSpan(2, 41, 0),
                        Synopsis = "1969 год, золотой век Голливуда уже закончился. Известный актёр Рик Далтон и его дублер Клифф Бут пытаются найти свое место в стремительно меняющемся мире киноиндустрии.",
                        Poster = File.ReadAllBytes("Once_Upon_a_Time_in_Hollywood_cover.png"),
                        AgeRestriction = 18
                    },
                    new Movie
                    {
                        Title = "Интерстеллар",
                        Countries = new List<Country>()
                        {
                            countries[0],
                            countries[1],
                            countries[3]
                        },
                        ReleaseData = new DateTime(2014, 10, 26),
                        Director = "Кристофер Нолан",
                        Time = new TimeSpan(2, 49, 0),
                        Synopsis = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями.",
                        Poster = File.ReadAllBytes("Interstellar_2014.jpg"),
                        AgeRestriction = 16,
                        Genres = new List<Genre>()
                        {
                            genres[0],
                            genres[2],
                            genres[3]
                        }
                    }
                };

                movies[0].Genres.Add(genres[0]);
                movies[0].Genres.Add(genres[1]);
                movies[0].Countries.Add(countries[0]);
                movies[0].Countries.Add(countries[1]);
                movies[0].Countries.Add(countries[2]);

                movies[1].Genres.Add(genres[0]);
                movies[1].Genres.Add(genres[2]);
                movies[1].Genres.Add(genres[3]);
                movies[1].Countries.Add(countries[0]);
                movies[1].Countries.Add(countries[1]);
                movies[1].Countries.Add(countries[3]);


                foreach (var movie in movies)
                {
                    context.Movies.Add(movie);
                }

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

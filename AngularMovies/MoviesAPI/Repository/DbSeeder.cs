using Microsoft.AspNetCore.Identity;
using MoviesAPI.Models;
using NetTopologySuite.Geometries;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace MoviesAPI.Repository
{
    public class DbSeeder
    {
        

        public async static void SeedData(ApplicationDbContext _context, GeometryFactory geometryFactory, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!_context.Genres.Any())
            {
                string[] genreName = { "Action", "Comedy", "Drama", "Sci-Fi", "Adventure", "Horror", "Anime", "Romance", "Isekai", "Super-Heroes", "Super Natural", "Thriller", "Family", "Fantasy", "Biography", "Crime", "Suspense", "Mystery", "Military", "War" };

                List<Genre> createdGenres = new List<Genre>();

                for(int i = 0; i < genreName.Length; i++)
                {
                    createdGenres.Add(new Genre { Name = genreName[i] });
                }
                _context.Genres.AddRange(createdGenres);
                _context.SaveChanges();
            }
            if( !_context.Actors.Any() )
            {
                List<Actor> createdActors = new List<Actor>()
                {
                    new Actor
                    {
                       Name = "Johnny Depp",
                       DateOfBirth = new DateTime(1963, 6, 19),
                       Picture="https://s.yimg.com/fz/api/res/1.2/TbGe5OQ.kRgi4EO8.i.U_A--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/2131664c-5f47-3906-bfce-70d60afc1be9/t_500x300",
                       Biography = "John Christopher \"Johnny\" Depp II was born on June 9, 1963 in Owensboro, Kentucky, to Betty Sue Palmer (née Wells), a waitress, and John Christopher Depp, a civil engineer. He was raised in Florida. He dropped out of school when he was 15, and fronted a series of music-garage bands, including one named 'The Kids'. When he married Lori A. Depp, he took a job as a ballpoint-pen salesman to support himself and his wife. A visit to Los Angeles, California, with his wife, however, happened to be a blessing in disguise, when he met up with actor Nicolas Cage, who advised him to turn to acting, which culminated in Depp's film debut in the low-budget horror film, A Nightmare on Elm Street (1984), where he played a teenager who falls prey to dream-stalking demon Freddy Krueger."

                    },
                    new Actor
                    {
                        Name="Al Pacino",
                        DateOfBirth = new DateTime(1940, 4, 25),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/HOKRhE1O8cnuukUDzm5k.Q--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/438f89d7-9954-38b2-a001-5289962ac549/t_500x300",
                        Biography="Alfredo James \"Al\" 'Pacino established himself as a film actor during one of cinema's most vibrant decades, the 1970s, and has become an enduring and iconic figure in the world of American movies.\r\n\r\nHe was born April 25, 1940 in Manhattan, New York City, to Italian-American parents, Rose (nee Gerardi) and Sal Pacino. They divorced when he was young. His mother moved them into his grandparents' home in the South Bronx. Pacino found himself often repeating the plots and voices of characters he had seen in the movies. Bored and unmotivated in school, he found a haven in school plays, and his interest soon blossomed into a full-time career. Starting onstage, he went through a period of depression and poverty, sometimes having to borrow bus fare to succeed to auditions. He made it into the prestigious Actors Studio in 1966, studying under Lee Strasberg, creator of the Method Approach that would become the trademark of many 1970s-era actors."
                    },
                    new Actor
                    {
                        Name = "Robert De Niro",
                        DateOfBirth = new DateTime(1943, 8, 17),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/TPuvNmjzI_JEiCl1U9b70A--~C/YXBwaWQ9c3JjaGRkO2ZpPW9wdGk7aD0xMjA7dz04MA--/http://d.yimg.com/sr/img/1/3bfb07c5-29c0-3980-8baa-4ec8b7cc824b",
                        Biography = "One of the greatest actors of all time, Robert De Niro was born on August 17, 1943 in Manhattan, New York City, to artists Virginia (Admiral) and Robert De Niro Sr. His paternal grandfather was of Italian descent, and his other ancestry is Irish, English, Dutch, German, and French."
                    },
                    new Actor
                    {
                        Name = "Kevin Spacey",
                        DateOfBirth = new DateTime(1959, 6, 26),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/d1sIF5DUl3xctipFuTbXhg--~C/YXBwaWQ9c3JjaGRkO2ZpPW9wdGk7aD0xMjA7dz04MA--/http://d.yimg.com/sr/img/1/5f7c3122-bf15-36bb-a661-8cb22d370377",
                        Biography = "Kevin Spacey Fowler, better known by his stage name Kevin Spacey, is an American actor of screen and stage, film director, producer, screenwriter and singer. He began his career as a stage actor during the 1980s before obtaining supporting roles in film and television. He gained critical acclaim in the early 1990s that culminated in his first Academy Award for Best Supporting Actor for the neo-noir crime thriller The Usual Suspects (1995), and an Academy Award for Best Actor for midlife crisis-themed drama American Beauty (1999)."
                    },
                    new Actor
                    {
                        Name ="Denzel Washington",
                        DateOfBirth = new DateTime(1954, 12, 28),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/oMn7QOg8e09M.z2OGcz7kw--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNjE-/https://s.yimg.com/zb/imgv1/a1b04120-45ae-339d-ab9e-8009b85ab32c/t_500x300",
                        Biography = "Denzel Hayes Washington Jr. (born December 28, 1954) is an American actor, producer and director. In a career spanning over four decades, Washington has received numerous accolades, including a Tony Award, two Academy Awards, three Golden Globe Awards and two Silver Bears."
                    },
                    new Actor
                    {
                        Name = "Brad Pitt",
                        DateOfBirth = new DateTime(1963, 12,18),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/zTn6dwpv9Btf5eApXxMGQw--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/9eef9355-840c-3949-b30b-ae8cf9d52926/t_500x300",
                        Biography = "William Bradley Pitt (born December 18, 1963) is an American actor and film producer. He is the recipient of various accolades, including two Academy Awards, two British Academy Film Awards, two Golden Globe Awards, and a Primetime Emmy Award. As a public figure, Pitt has been cited as one of the most powerful and influential people in the American entertainment industry. Pitt first gained recognition as a cowboy hitchhiker in the Ridley Scott road film Thelma & Louise (1991)."
                    },
                    new Actor
                    {
                        Name = "Angelina Jolie",
                        DateOfBirth = new DateTime(1975, 6, 4),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/Qk09sYzCM.OIWoo8.VeGQg--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNTk-/https://s.yimg.com/zb/imgv1/2ce2cbc1-e19a-38fd-848e-d67a9d24e48d/t_500x300",
                        Biography = "Angelina Jolie (born Angelina Jolie Voight; June 4, 1975) is an American actress, filmmaker and humanitarian. The recipient of numerous accolades, including an Academy Award and three Golden Globe Awards, she has been named Hollywood's highest-paid actress multiple times. Jolie made her screen debut as a child alongside her father, Jon Voight, in Lookin' to Get Out (1982)."
                    },
                    new Actor
                    {
                        Name = "Leonardo Di Caprio",
                        DateOfBirth = new DateTime(1974, 11, 11),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/JyrrPBNWNpfJLqIFcSB.WA--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNTc-/https://s.yimg.com/zb/imgv1/8e49e7ac-4952-34af-9be3-95869543ae1f/t_500x300",
                        Biography = "Leonardo Wilhelm DiCaprio is an American actor and film producer. Known for his work in biographical and period films, he is the recipient of numerous accolades, including an Academy Award, a British Academy Film Award and three Golden Globe Awards. As of 2019, his films have grossed over $7.2 billion worldwide, and he has been placed eight times in annual rankings of the world's highest-paid actors."
                    },
                    new Actor
                    {
                        Name = "Tom Cruise",
                        DateOfBirth = new DateTime(1962, 6, 3),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/0v9q.TiQS4PVjaq5RUlvwg--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNjc-/https://s.yimg.com/zb/imgv1/6417f365-faf5-3968-8cf6-158e3320243f/t_500x300",
                        Biography = "Thomas Cruise Mapother IV (born July 3, 1962), known professionally as Tom Cruise, is an American actor. One of the world's highest-paid actors, he has received various accolades, including an Honorary Palme d'Or and three Golden Globe Awards, in addition to nominations for four Academy Awards. His films have grossed over $4 billion in North America and over $11.5 billion worldwide, making him one of the highest-grossing box-office stars of all time. "
                    },
                    new Actor
                    {
                        Name = "Kate Winslet",
                        DateOfBirth = new DateTime(1975, 10, 5),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/G.VHu.MAH_plvUlG5QSZzQ--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDM-/https://s.yimg.com/zb/imgv1/73a7101d-822d-31fe-8709-eca214a0c5c8/t_500x300",
                        Biography = "Kate Elizabeth Winslet CBE (born 5 October 1975) is an English actress. Known for her work in independent films, particularly period dramas, and for her portrayals of headstrong and complicated women, she has received numerous accolades, including an Academy Award, a Grammy Award, two Primetime Emmy Awards, five BAFTA Awards and five Golden Globe Awards. Time magazine named Winslet one of the 100 most influential people in the world in 2009 and 2021."
                    },
                    new Actor
                    {
                        Name = "Morgan Freeman",
                        DateOfBirth = new DateTime(1937, 5, 1),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/2HmRolqlRVbcxNKR5vyA0w--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/10a0f998-393e-3ad7-b1b0-b233ec24a313/t_500x300",
                        Biography = "Morgan Freeman (born June 1, 1937) is an American actor and producer. He is known for his distinctive deep voice and various roles in a wide variety of film genres. Throughout his career spanning over five decades, he has received numerous accolades, including an Academy Award, a Screen Actors Guild Award, and a Golden Globe Award. He is the recipient of the Kennedy Center Honor in 2008, the AFI Life Achievement Award in 2011, the Cecil B."
                    },
                    new Actor
                    {
                        Name = "Christian Bale",
                        DateOfBirth = new DateTime(1934, 1,30),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/C4I9qXMpDYrbMsnQCcOP9Q--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDI-/https://s.yimg.com/zb/imgv1/14a10021-f82f-37ac-a2e4-defa10a989c4/t_500x300",
                        Biography = "Christian Charles Philip Bale (born 30 January 1974) is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards."
                    },
                    new Actor
                    {
                        Name = "Tom Hanks",
                        DateOfBirth = new DateTime(1956, 06, 9),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/GUeZsvNRQ26WRHfSGNExaQ--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/fcaffbc4-da3c-3259-bbca-18ad37f5c45f/t_500x300",
                        Biography = "Thomas Jeffrey Hanks (born July 9, 1956) is an American actor and filmmaker. Known for both his comedic and dramatic roles, he is one of the most popular and recognizable film stars worldwide, and is regarded as an American cultural icon. Hanks' films have grossed more than $4.9 billion in North America and more than $9.96 billion worldwide, making him the fourth-highest-grossing actor in North America."
                    },
                    new Actor
                    {
                        Name = "Keeanu Charles Reeves",
                        DateOfBirth = new DateTime(1964, 09, 2),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/Iwf0c3fekdoS3yRydiibWw--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDU-/https://s.yimg.com/zb/imgv1/6eb70a67-eb12-3bc7-a5ca-bfc793400734/t_500x300",
                        Biography = "Keanu Charles Reeves ( kee-AH-noo; born September 2, 1964) is a Canadian actor and musician. Born in Beirut and raised in Toronto, he made his acting debut in the Canadian television series Hangin In (1984), before making his feature film debut in Youngblood (1986). He had his breakthrough role in the science fiction comedy Bill & Ted's Excellent Adventure (1989), and he reprised his role in its sequels"
                    },
                    new Actor
                    {
                        Name = "Ryan Reynolds",
                        DateOfBirth = new DateTime(1976, 11,23),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/oIL69j1AUk5TqJ9gKJHOoQ--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNTk-/https://s.yimg.com/zb/imgv1/dd63f93e-0931-3955-b0cb-362f9965be8e/t_500x300",
                        Biography = "Ryan Rodney Reynolds OBC (born October 23, 1976) is a Canadian and American actor, producer and businessman. He began his career starring in the Canadian teen soap opera Hillside (1991–1993), and had minor roles before landing the lead role on the sitcom Two Guys and a Girl between 1998 and 2001. "
                    },
                    new Actor
                    {
                        Name = "Robert Downey Jr.",
                        DateOfBirth = new DateTime(1965, 4, 4),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/I6EUwftUr2dg2e3tGDk.0Q--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNTM-/https://s.yimg.com/zb/imgv1/ed6b1eff-3c5a-3750-b3f8-117ca6067cd4/t_500x300",
                        Biography = "Robert John Downey Jr. (born April 4, 1965) is an American actor. His career has been characterized by critical success in his youth, followed by a period of substance abuse and legal troubles, and a surge in popular and commercial success later in his career. In 2008, Downey was named by Time magazine among the 100 most influential people in the world, and from 2013 to 2015, he was listed by Forbes as Hollywood's highest-paid actor."
                    },
                    new Actor
                    {
                        Name = "Tom Hardy",
                        DateOfBirth = new DateTime(1977, 09, 15),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/m8NhQuKK5RdxEHw8gJZ4Gg--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0zMzA-/https://s.yimg.com/zb/imgv1/2113958e-9cbc-38e5-941e-3d98a1d44fd1/t_500x300",
                        Biography = "Edward Thomas Hardy CBE (born 15 September 1977) is an English actor, producer and screenwriter. After studying acting at the Drama Centre London, he made his film debut in Ridley Scott's Black Hawk Down (2001). He had supporting roles in Star Trek: Nemesis (2002) and RocknRolla (2008), and went on to star in Bronson (2008), Warrior (2011), Tinker Tailor Soldier Spy (2011), Lawless (2012), This Means War (2012), and Locke (2013)."
                    },
                    new Actor
                    {
                        Name = "Tom Holland",
                        DateOfBirth = new DateTime(1996, 06, 1),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/6K1RmzuPTit41Qk21pvA0A--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNDY-/https://s.yimg.com/zb/imgv1/672cfd0b-1ac6-3df2-b32a-15303c89a49c/t_500x300",
                        Biography = "Thomas Stanley Holland (born 1 June 1996) is an English actor. His accolades include a British Academy Film Award and three Saturn Awards. Some publications have called him one of the most popular actors of his generation. Holland's career began at age nine when he enrolled in a dancing class, where a choreographer noticed him and arranged for him to audition for a role in Billy Elliot the Musical at London's Victoria Palace Theatre."
                    },
                    new Actor
                    {
                        Name = "Andrew Garfield",
                        DateOfBirth = new DateTime(1943, 8, 20),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/cH838R_Achx33MJR35angQ--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNjk-/https://s.yimg.com/zb/imgv1/627bf3bf-4cb4-34c3-a237-66dbaf18967b/t_500x300",
                        Biography = "Andrew Russell Garfield (born 20 August 1983) is an English and American actor. He has received various accolades, including a Tony Award, a BAFTA TV Award and a Golden Globe, in addition to nominations for a Primetime Emmy Award, a Laurence Olivier Award and two Academy Awards. Time included Garfield on its list of 100 most influential people in the world in 2022."
                    },
                    new Actor
                    {
                        Name = "Cilian Murphy",
                        DateOfBirth = new DateTime(1976, 05, 25),
                        Picture = "https://s.yimg.com/fz/api/res/1.2/SqS5Cf1qmltGMUZofsaZPQ--~C/YXBwaWQ9c3JjaGRkO2ZpPWZpbGw7aD0yMjA7cHhvZmY9MDtweW9mZj0wO3E9ODA7dz0xNjI-/https://s.yimg.com/zb/imgv1/63680d55-28d7-3975-a58e-3efdd2850fc7/t_500x300",
                        Biography = "Cillian Murphy ( KILL-ee-ən; born 25 May 1976) is an Irish actor. He made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation. His early notable film credits include the horror film 28 Days Later (2002), the dark comedy Intermission (2003), the thriller Red Eye (2005), the Irish war drama The Wind That Shakes the Barley (2006), and the science fiction thriller Sunshine (2007). "
                    },
                    new Actor
                    {
                        Name = "Tom Ribbons",
                        DateOfBirth = new DateTime(1958, 10, 16),
                        Picture = "https://ia.media-imdb.com/images/M/MV5BMTg5MjQ3MTU2Ml5BMl5BanBnXkFtZTcwNDczMzcyNw@@._V1._SX640_SY960_.jpg",
                        Biography = "Director, producer, activist, musician, and Academy Award-winning actor Tim Robbins began acting in the early '80s and went on to star in such films as Bull Durham, The Shawshank Redemption, The Hudsucker Proxy, and Mystic River. He won a Best Supporting Actor award for the latter, and was nominated for Best Director for 1995’s Dead Man Walking. "
                    },
                     new Actor
                    {
                        Name = "James Caan",
                        DateOfBirth = new DateTime(1940, 10, 16),
                        Picture = "https://factsfive.com/wp-content/uploads/2020/11/James-Caan-Wiki-Bio-Age-Net-Worth-and-Other-Facts-scaled.jpg",
                        Biography = "A masculine and enigmatic actor whose life and movie career have had more ups and downs than the average rollercoaster and whose selection of roles has arguably derailed him from achieving true superstar status, James Caan is New York-born and bred."
                    },
                    new Actor
                    {
                        Name = "Heath Ledger",
                        DateOfBirth = new DateTime(1979, 4, 4),
                        Picture = "https://static.accessonline.com/uploads/80455.jpg",
                        Biography = "Heath Andrew Ledger (4 April 1979 – 22 January 2008) was an Australian actor. After playing roles in several Australian television and film productions during the 1990s, he moved to the United States in 1998 to further develop his film career."
                    },
                    

                };

                _context.Actors.AddRange(createdActors);
                _context.SaveChanges();


            }

            if(!_context.Movies.Any())
            {
                List<Movie> movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Name = "The Shawshank Redemption",
                        Poster = "https://image.tmdb.org/t/p/original/q6y0Go1tsGEsmtFryDOJo3dEmqu.jpg",
                        InTheaters= false,
                        Summary = "Chronicles the experiences of a formerly successful banker as a prisoner in the gloomy jailhouse of Shawshank after being found guilty of a crime he did not commit. The film portrays the man's unique way of dealing with his new, torturous life; along the way he befriends a number of fellow prisoners, most notably a wise long-term inmate named Red.",
                        Trailer = "https://www.youtube.com/watch?v=NmzuHjWmXOc",
                        ReleaseDate = new DateTime(1994, 01,12)
                    },
                    new Movie()
                    {
                        Name = "The Dark Knight",
                        Poster = "https://wallpapercave.com/wp/PQzCndX.jpg",
                        InTheaters= false,
                        Summary = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                        Trailer = "https://www.youtube.com/watch?v=EXeTwQWrcwY&t=22s",
                        ReleaseDate = new DateTime(2008, 03,15)
                    },
                    new Movie()
                    {
                        Name = "The Godfather",
                        Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
                        InTheaters= false,
                        Summary = "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.",
                        Trailer = "https://www.youtube.com/watch?v=UaVTIH8mujA",
                        ReleaseDate = new DateTime(2008, 03,15)
                    },
                    new Movie()
                    {
                        Name = "Forrest Gump",
                        Poster = "https://picfiles.alphacoders.com/350/350230.jpg",
                        InTheaters= false,
                        Summary = "The history of the United States from the 1950s to the '70s unfolds from the perspective of an Alabama man with an IQ of 75, who yearns to be reunited with his childhood sweetheart.",
                        Trailer = "https://www.youtube.com/watch?v=bLvqoHBptjg",
                        ReleaseDate = new DateTime(1994, 12,1)
                    },
                    new Movie()
                    {
                        Name = "Inception",
                        Poster = "https://images2.fanpop.com/image/photos/12300000/Inception-Wallpaper-inception-2010-12396931-1440-900.jpg",
                        InTheaters= false,
                        Summary = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                        Trailer = "https://www.youtube.com/watch?v=YoHD9XEInc0",
                        ReleaseDate = new DateTime(2010, 1,17)
                    },
                    new Movie()
                    {
                        Name = "The Matrix",
                        Poster = "https://image.tmdb.org/t/p/original/sRaupdJawe6UTS0t77vwJoLjd7h.jpg",
                        InTheaters = false,
                        Summary = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                        Trailer = "https://www.youtube.com/watch?v=9ix7TUGVYIo",
                        ReleaseDate = new DateTime(1999 ,5, 8)
                    },
                    new Movie()
                    {
                        Name = "Interstellar",
                        Poster = "https://1.bp.blogspot.com/-l7aTAUwMI58/X6O7G6yslfI/AAAAAAAAAHM/BRXfZCuEU6caMvMhFZznB9VhFOwLQKGUQCLcBGAsYHQ/s1697/111c5c9ad99661af2d80e38948cf29d8.jpg",
                        InTheaters= false,
                        Summary = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                        Trailer = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                        ReleaseDate = new DateTime(2014, 10,23)
                    },
                    new Movie()
                    {
                        Name = "Spider-Man:Across the spider verse",
                        Poster = "https://images.hdqwalls.com/download/spider-man-into-the-spider-verse-fanart-88-1920x1080.jpg",
                        InTheaters= true,
                        Summary = "Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.",
                        Trailer = "https://www.youtube.com/watch?v=shW9i6k8cB0",
                        ReleaseDate = new DateTime(2023 , 2, 5)
                    },
                    new Movie()
                    {
                        Name = "Spirited Away",
                        Poster = "http://image.tmdb.org/t/p/original/yA6TbjztJtop9sqNkZjhsUDq2Uy.jpg",
                        InTheaters= false,
                        Summary = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches and spirits, a world where humans are changed into beasts.",
                        Trailer = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                        ReleaseDate = new DateTime(2001, 03,25)
                    },
                    new Movie()
                    {
                        Name = "The Pianist",
                        Poster = "https://www.dvdplanetstore.pk/wp-content/uploads/2013/12/The-pianist.jpg",
                        InTheaters= false,
                        Summary = "A Polish Jewish musician struggles to survive the destruction of the Warsaw ghetto of World War II.",
                        Trailer = "https://www.youtube.com/watch?v=BFwGqLa_oAo",
                        ReleaseDate = new DateTime(2002, 7,12)
                    },
                    new Movie()
                    {
                        Name = "Parasite",
                        Poster = "https://levelingupyourgame.com/wp-content/uploads/2019/11/Parasite-Movie-Review-2019-Breakdown-Analysis-Synopsis-and-Ending-Explained.jpg",
                        InTheaters= false,
                        Summary = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                        Trailer = "https://www.youtube.com/watch?v=isOGD_7hNIY",
                        ReleaseDate = new DateTime(2019, 10, 11)
                    },
                    new Movie()
                    {
                        Name = "Oppenheimer",
                        Poster = "https://movies.universalpictures.com/media/04-opp-dm-mobile-banner-1080x745-pl-f01-050523-1-1-1-6458870c70c1d-1.jpg",
                        InTheaters= true,
                        Summary = "The story of American scientist, J. Robert Oppenheimer, and his role in the development of the atomic bomb.",
                        Trailer = "https://www.youtube.com/watch?v=uYPbbksJxIg",
                        ReleaseDate = new DateTime(2023, 07, 21)
                    },
                    new Movie()
                    {
                        Name = "Wall.E.",
                        Poster = "https://images-na.ssl-images-amazon.com/images/I/91YTk3e7c-L._RI_.jpg",
                        InTheaters= false,
                        Summary = "In the distant future, a small waste-collecting robot inadvertently embarks on a space journey that will ultimately decide the fate of mankind.",
                        Trailer = "https://www.youtube.com/watch?v=CZ1CATNbXg0",
                        ReleaseDate = new DateTime(2008, 10, 10)
                    },
                    new Movie()
                    {
                        Name = "Avengers: Infinity War",
                        Poster = "https://images.hdqwalls.com/download/avengers-infinity-war-official-poster-2018-4o-2048x2048.jpg",
                        InTheaters= false,
                        Summary = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                        Trailer = "https://www.youtube.com/watch?v=6ZfuNTqbHE8",
                        ReleaseDate = new DateTime(2018, 06, 06)
                    },
                    new Movie()
                    {
                        Name = "The Dark Knight Raises",
                        Poster = "https://www.filmofilia.com/wp-content/uploads/2012/05/THE-DARK-KNIGHT-RISES_06.jpg",
                        InTheaters= false,
                        Summary = "Eight years after the Joker's reign of chaos, Batman is coerced out of exile with the assistance of the mysterious Selina Kyle in order to defend Gotham City from the vicious guerrilla terrorist Bane.",
                        Trailer = "https://www.youtube.com/watch?v=GokKUqLcvD8",
                        ReleaseDate = new DateTime(2012, 07, 20)
                    },
                    new Movie()
                    {
                        Name = "Toy Story",
                        Poster = "https://whatsondisneyplus.com/wp-content/uploads/2020/11/Toy-Story-Featured.png",
                        InTheaters= false,
                        Summary = "A cowboy doll is profoundly threatened and jealous when a new spaceman action figure supplants him as top toy in a boy's bedroom.",
                        Trailer = "https://www.youtube.com/watch?v=v-PjgYDrg70",
                        ReleaseDate = new DateTime(1995, 11, 11)
                    },
                    new Movie()
                    {
                        Name = "Avengers: End Game",
                        Poster = "https://image.tmdb.org/t/p/original/fTFRY6RJTpwkrYybwj4Wdf5nfgn.jpg",
                        InTheaters= false,
                        Summary = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                        Trailer = "https://www.youtube.com/watch?v=TcMBFSGVi1c",
                        ReleaseDate = new DateTime(2019, 06, 10)
                    },
                    new Movie()
                    {
                        Name = "Joker",
                        Poster = "https://www.youtube.com/watch?v=zAGVQLHvwOY",
                        InTheaters= false,
                        Summary = "During the 1980s, a failed stand-up comedian is driven insane and turns to a life of crime and chaos in Gotham City while becoming an infamous psychopathic crime figure.",
                        Trailer = "https://www.vintagemovieposters.co.uk/wp-content/uploads/2019/11/IMG_2167-2.jpeg",
                        ReleaseDate = new DateTime(2020, 11 ,12)
                    },
                    new Movie()
                    {
                        Name = "Good Will Hunting",
                        Poster = "https://image.tmdb.org/t/p/original/rcvidea8xtCZF32x6ATUlLYfpJ5.jpg",
                        InTheaters= false,
                        Summary = "Will Hunting, a janitor at M.I.T., has a gift for mathematics, but needs help from a psychologist to find direction in his life.",
                        Trailer = "https://www.youtube.com/watch?v=ReIJ1lbL-Q8",
                        ReleaseDate = new DateTime(1997, 06, 05)
                    },
                    new Movie()
                    {
                        Name = "Your Name",
                        Poster = "https://i.pinimg.com/originals/47/2e/92/472e9277dae8a2750e32f493c0f08246.jpg",
                        InTheaters= false,
                        Summary = "Two teenagers share a profound, magical connection upon discovering they are swapping bodies. Things manage to become even more complicated when the boy and girl decide to meet in person.",
                        Trailer = "https://www.youtube.com/watch?v=xU47nhruN-Q",
                        ReleaseDate = new DateTime(2016 ,09 ,11)
                    },
                    new Movie()
                    {
                        Name = "Toy Story 3",
                        Poster = "https://farm3.staticflickr.com/2898/14317452030_e8831034eb_o.jpg",
                        InTheaters= false,
                        Summary = "The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it's up to Woody to convince the other toys that they weren't abandoned and to return home.",
                        Trailer = "https://www.youtube.com/watch?v=JcpWXaA2qeg",
                        ReleaseDate = new DateTime(2010, 04, 22)
                    },
                    new Movie()
                    {
                        Name = "Top Gun: Maverick",
                        Poster = "https://image.tmdb.org/t/p/original/6plTmebpsVcqcXCuNAfIg0LCQQB.jpg",
                        InTheaters= false,
                        Summary = "After thirty years, Maverick is still pushing the envelope as a top naval aviator, but must confront ghosts of his past when he leads TOP GUN's elite graduates on a mission that demands the ultimate sacrifice from those chosen to fly it.",
                        Trailer = "https://www.youtube.com/watch?v=qSqVVswa420",
                        ReleaseDate = new DateTime(2022, 05, 17)
                    },
                    new Movie()
                    {
                        Name = "The Wolf Of Wall Street",
                        Poster = "https://is5-ssl.mzstatic.com/image/thumb/Video114/v4/0a/d6/6c/0ad66c58-6fc4-e1a4-ec82-eb89979eea7e/PAR_THE_WOLF_OF_WALL_STREET_WW_ARTWORK_EN_3840x2160_1ML6DP000000MZ.lsr/2000x1125.jpg",
                        InTheaters= false,
                        Summary = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                        Trailer = "https://www.youtube.com/watch?v=iszwuX1AK6A",
                        ReleaseDate = new DateTime(2013, 02, 12)
                    },
                    new Movie()
                    {
                        Name = "Green Book",
                        Poster = "https://wallpapercave.com/wp/wp3998470.jpg",
                        InTheaters= false,
                        Summary = "A working-class Italian-American bouncer becomes the driver for an African-American classical pianist on a tour of venues through the 1960s American South.",
                        Trailer = "https://www.youtube.com/watch?v=QkZxoko_HC0",
                        ReleaseDate = new DateTime(2018, 7,7)
                    },
                    new Movie()
                    {
                        Name = "Spider-Man:No Way Home",
                        Poster = "https://i.ytimg.com/vi/IE5y03_YEdo/maxresdefault.jpg",
                        InTheaters= false,
                        Summary = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                        Trailer = "https://www.youtube.com/watch?v=JfVOs4VSpmA",
                        ReleaseDate = new DateTime(2021, 11, 17)
                    },
                    new Movie()
                    {
                        Name = "Harry Potter and the Deathly Hallows: Part 2",
                        Poster = "https://image.tmdb.org/t/p/original/gOduLS90AehfJPoJMizaRkC3Hoz.jpg",
                        InTheaters= false,
                        Summary = "Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.",
                        Trailer = "https://www.youtube.com/watch?v=mObK5XD8udk",
                        ReleaseDate = new DateTime(2011, 12, 12)
                    },
                    new Movie()
                    {
                        Name = "Harry Potter and the Deathly Hallows: Part 1",
                        Poster = "https://ilarge.lisimg.com/image/1695809/999full-harry-potter-and-the-deathly-hallows:-part-1-poster.jpg",
                        InTheaters= false,
                        Summary = "As Harry, Ron and Hermione race against time and evil to destroy the Horcruxes, they uncover the existence of the three most powerful objects in the wizarding world: the Deathly Hallows.",
                        Trailer = "https://www.youtube.com/watch?v=MxqsmsA8y5k",
                        ReleaseDate = new DateTime(2010, 05, 12)
                    },
                    new Movie()
                    {
                        Name = "Hacksaw Ridge",
                        Poster = "http://www.blackfilm.com/read/wp-content/uploads/2016/11/Hacksaw-Ridge-poster-2.jpg",
                        InTheaters= false,
                        Summary = "World War II American Army Medic Desmond T. Doss, serving during the Battle of Okinawa, refuses to kill people and becomes the first man in American history to receive the Medal of Honor without firing a shot.",
                        Trailer = "https://www.youtube.com/watch?v=s2-1hz1juBI",
                        ReleaseDate = new DateTime(2018, 08, 12)
                    },
                    new Movie()
                    {
                        Name = "How to Train Your Dragon",
                        Poster = "https://image.tmdb.org/t/p/original/q9JwFktEfzdXlE7gFjKSTOD3jpK.jpg",
                        InTheaters= false,
                        Summary = "A hapless young Viking who aspires to hunt dragons becomes the unlikely friend of a young dragon himself, and learns there may be more to the creatures than he assumed",
                        Trailer = "https://www.youtube.com/watch?v=2AKsAxrhqgM",
                        ReleaseDate = new DateTime(2010, 10, 10)
                    },
                    new Movie()
                    {
                        Name = "Ratatouille",
                        Poster = "https://picfiles.alphacoders.com/147/thumb-1920-147273.jpg",
                        InTheaters= false,
                        Summary = "A rat who can cook makes an unusual alliance with a young kitchen worker at a famous Paris restaurant.",
                        Trailer = "https://www.youtube.com/watch?v=NgsQ8mVkN8w",
                        ReleaseDate = new DateTime(2007 ,07,25)
                    },
                    new Movie()
                    {
                        Name = "The Terminator",
                        Poster = "https://image.tmdb.org/t/p/original/1EfQZfyMgNrYWP3dcHytX9XO0Ad.jpg",
                        InTheaters= false,
                        Summary = "A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year, which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.",
                        Trailer = "https://www.youtube.com/watch?v=k64P4l2Wmeg",
                        ReleaseDate = new DateTime(1984, 07, 11)
                    },
                    new Movie()
                    {
                        Name = "Deadpool 3",
                        Poster = "https://image.tmdb.org/t/p/original/1SlhjVF0QYYd3c8fJehGDrFfrQI.jpg",
                        InTheaters= false,
                        Summary = "Wolverine joins the \"merc with a mouth\" in the third installment of the Deadpool film franchise.",
                        Trailer = "https://www.youtube.com/watch?v=gfMRgap9jWk",
                        ReleaseDate = new DateTime(2024, 05, 03)
                    },
                    new Movie()
                    {
                        Name = "Venom: along came a spider",
                        Poster = "https://i.ytimg.com/vi/WIuccpRL5Lw/maxresdefault.jpg",
                        InTheaters= false,
                        Summary = "up coming",
                        Trailer = "https://www.youtube.com/watch?v=uWfGGw-KGtQ",
                        ReleaseDate = new DateTime(2024, 01,20 )
                    },
                    new Movie()
                    {
                        Name = "JOKER 2: Folie à Deux",
                        Poster = "https://cdn.kinocheck.com/i/y43dk5voar.jpg",
                        InTheaters= false,
                        Summary = "upcoming",
                        Trailer = "https://www.youtube.com/watch?v=03ymBj144ng",
                        ReleaseDate = new DateTime(2024, 11 ,12)
                    },
                    new Movie()
                    {
                        Name = "The Hunger Games: The Ballad of Songbirds & Snakes",
                        Poster = "https://images.fandango.com/ImageRenderer/820/0/redesign/static/img/default_poster.png/0/images/masterrepository/fandango/233468/thehungergames-balladofsongbirdsandsnakes-Poster.jpg",
                        InTheaters= false,
                        Summary = "Coriolanus Snow mentors and develops feelings for the female District 12 tribute during the 10th Hunger Games.",
                        Trailer = "https://www.youtube.com/watch?v=NxW_X4kzeus",
                        ReleaseDate = new DateTime(2023, 11, 17)
                    },
                    new Movie()
                    {
                        Name = "Attack on Titan Final season part 4",
                        Poster = "https://topictrekhub.com/wp-content/uploads/2023/11/Attack-on-Titan-Season-4-Part-3-Final-Episode-1024x575.png",
                        InTheaters= true,
                        Summary = "Attack on Titan is a Japanese dark fantasy and post-apocalyptic anime television series based on Hajime Isayama 's manga series of the same name. It is set in a world where humanity lives inside cities surrounded by enormous walls due to the Titans, gigantic humanoid beings who devour humans seemingly without reason.",
                        Trailer = "https://www.youtube.com/watch?v=E7WytLM2KvY",
                        ReleaseDate = new DateTime(2023, 11, 4)
                    },
                    new Movie()
                    {
                        Name = "Mission: Impossible - Dead Reckoning Part One",
                        Poster = "https://media.cinemacloud.co.uk/imageFilm/1491_1_2.jpg",
                        InTheaters= true,
                        Summary = "Ethan Hunt and his IMF team must track down a dangerous weapon before it falls into the wrong hands.",
                        Trailer = "https://www.youtube.com/watch?v=avz06PDqDbM",
                        ReleaseDate = new DateTime(2023, 06, 11)
                    },
                    new Movie()
                    {
                        Name = "When evil lurks",
                        Poster = "https://www.naijaprey.com/wp-content/uploads/2023/10/whenevillurks.webp",
                        InTheaters= true,
                        Summary = "In a remote village, two brothers find a demon-infected man just about to give birth to evil itself. They decide to get rid of the man but merely succeed in spreading the chaos.",
                        Trailer = "https://www.youtube.com/watch?v=YrTnV6gNzno",
                        ReleaseDate = new DateTime(2023, 11, 7)
                    },
                    new Movie()
                    {
                        Name = "The Nun II",
                        Poster = "https://f4.bcbits.com/img/a3594521705_10.jpg",
                        InTheaters= false,
                        Summary = "1956 - France. A priest is murdered. An evil is spreading. The sequel to the worldwide smash hit follows Sister Irene as she once again comes face-to-face with Valak, the demon nun.",
                        Trailer = "https://www.youtube.com/watch?v=QF-oyCwaArU",
                        ReleaseDate = new DateTime(2023, 04, 12)
                    },
                    new Movie()
                    {
                        Name = "The Nun",
                        Poster = "https://image.tmdb.org/t/p/original/sFC1ElvoKGdHJIWRpNB3xWJ9lJA.jpg",
                        InTheaters= false,
                        Summary = "A priest with a haunted past and a novice on the threshold of her final vows are sent by the Vatican to investigate the death of a young nun in Romania and confront a malevolent force in the form of a demonic nun.",
                        Trailer = "https://www.youtube.com/watch?v=pzD9zGcUNrw",
                        ReleaseDate = new DateTime(2018 , 11, 11)
                    },
                    new Movie()
                    {
                        Name = "Anatomy of Fall",
                        Poster = "https://image-cdn.neatoshop.com/styleimg/10267/none/lightturquoise/default/133370-20.jpg",
                        InTheaters= true,
                        Summary = "A woman is suspected of her husband's murder, and their blind son faces a moral dilemma as the sole witness.",
                        Trailer = "https://www.youtube.com/watch?v=MJlpGZuE4R4",
                        ReleaseDate = new DateTime(2023, 05, 06)
                    },
                    new Movie()
                    {
                        Name = "John Wick",
                        Poster = "https://image.tmdb.org/t/p/original/5w2pb3dxENKRl8VA7ADUTZ1cEOz.jpg",
                        InTheaters= false,
                        Summary = "An ex-hitman comes out of retirement to track down the gangsters who killed his dog and stole his car.",
                        Trailer = "https://www.youtube.com/watch?v=C0BMx-qxsP4",
                        ReleaseDate = new DateTime(2014 ,06, 24)
                    },
                    new Movie()
                    {
                        Name = "John Wick: Chapter 2",
                        Poster = "https://image.tmdb.org/t/p/original/1jvyy3UtMbWBHikj7byFJeY5Fc7.jpg",
                        InTheaters= false,
                        Summary = "After returning to the criminal underworld to repay a debt, John Wick discovers that a large bounty has been put on his life.",
                        Trailer = "https://www.youtube.com/watch?v=XGk2EfbD_Ps",
                        ReleaseDate = new DateTime(2017, 02, 03)
                    },
                    new Movie()
                    {
                        Name = "John Wick: Chapter 3",
                        Poster = "https://image.tmdb.org/t/p/original/68IgAFx9X9zNeoDvm9sCvud93Au.jpg",
                        InTheaters= false,
                        Summary = "John Wick is on the run after killing a member of the international assassins' guild, and with a $14 million price tag on his head, he is the target of hit men and women everywhere.",
                        Trailer = "https://www.youtube.com/watch?v=M7XM597XO94",
                        ReleaseDate = new DateTime(2019, 08, 18)
                    },
                    new Movie()
                    {
                        Name = "John Wick: Chapter 4",
                        Poster = "https://www.sanity.com.au/media/Images/fullimage/629201/SDC_1401731_2021-13-4--09-25-47.jpg",
                        InTheaters= false,
                        Summary = "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.",
                        Trailer = "https://www.youtube.com/watch?v=qEVUtrk8_B4",
                        ReleaseDate = new DateTime(2023, 12, 25)
                    },
                    new Movie()
                    {
                        Name = "The BatMan",
                        Poster = "https://wallpapers.com/images/hd/the-batman-2022-movie-poster-4u7dg02wjiewmyum.jpg",
                        InTheaters= false,
                        Summary = "When a sadistic serial killer begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
                        Trailer = "https://www.youtube.com/watch?v=mqqft2x_Aa4",
                        ReleaseDate = new DateTime(2022, 04, 01)
                    },
                    new Movie()
                    {
                        Name = "FreeLance",
                        Poster = "https://kinomeister.de/wp-content/uploads/2023/08/image002-37.jpg",
                        InTheaters= true,
                        Summary = "An ex-special forces operative takes a job to provide security for a journalist as she interviews a dictator, but a military coup breaks out in the middle of the interview, they are forced to escape into the jungle where they must survive.",
                        Trailer = "https://www.youtube.com/watch?v=BrqWlOzm2Iw",
                        ReleaseDate = new DateTime(2023, 10, 6)
                    },
                    new Movie()
                    {
                        Name = "Dunkrik",
                        Poster = "https://usustatesman.com/wp-content/uploads/2017/07/dunkirk.jpg",
                        InTheaters= false,
                        Summary = "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.",
                        Trailer = "https://www.youtube.com/watch?v=F-eMt3SrfFU",
                        ReleaseDate = new DateTime(2017, 11, 14)
                    },
                    new Movie()
                    {
                        Name = "The Revenant",
                        Poster = "https://i.pinimg.com/originals/26/5e/89/265e89318d1f345432bd2eb34bd2c279.jpg",
                        InTheaters= false,
                        Summary = "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
                        Trailer = "https://www.youtube.com/watch?v=LoebZZ8K5N0",
                        ReleaseDate = new DateTime(2015, 09, 11)
                    },
                    new Movie()
                    {
                        Name = "The Great Gatsby",
                        Poster = "http://scriptshadow.net/wp-content/uploads/2013/05/the_great_gatsby_movie-wide.jpg",
                        InTheaters= false,
                        Summary = "A writer and wall street trader, Nick Carraway, finds himself drawn to the past and lifestyle of his mysterious millionaire neighbor, Jay Gatsby, amid the riotous parties of the Jazz Age.",
                        Trailer = "https://www.youtube.com/watch?v=rARN6agiW7o",
                        ReleaseDate = new DateTime(2013, 10, 16)
                    }


                };
                _context.Movies.AddRange(movies);
                _context.SaveChanges();
            }

            if (!_context.MovieTheaters.Any())
            {
                List<MovieTheater> movieTheaters = new List<MovieTheater>()
                {
                    new MovieTheater
                    {
                        Name = "IMAX",
                        Location = geometryFactory.CreatePoint(new Coordinate(54.10450205265256, -113.56567219631273)),
                    },
                    new MovieTheater
                    {
                        Name = "CinePlex",
                        Location = geometryFactory.CreatePoint(new Coordinate(43.64674238882388, -79.69073096012843))
                    },
                    new MovieTheater
                    {
                        Name = "Niagara Adventure Theatre",
                        Location = geometryFactory.CreatePoint(new Coordinate(43.11596866638369, -79.0863957443596))
                    },
                    new MovieTheater
                    {
                        Name = "Imagine Cinemas Market Square",
                        Location = geometryFactory.CreatePoint(new Coordinate(43.66448854149757, -79.3742623346682))
                    },
                    new MovieTheater
                    {
                        Name = "Landmark Cinemas Waterloo",
                        Location = geometryFactory.CreatePoint(new Coordinate(44.38858820627144, -81.25174930722018))
                    }
                };
                _context.MovieTheaters.AddRange(movieTheaters);
                _context.SaveChanges();
            }
            if (!_context.movieGenres.Any())
            {
                
                var movies = _context.Movies.ToList();

                foreach (var movie in movies) 
                {
                    var genreIDs = _context.Genres.Select(x => x.ID).ToList();
                    var random  = new Random();

                    var number = random.Next(1, 4);
                    var addedID = new List<int>();
                    for (var i = 0; i < number; i++)
                    {

                        var randomID = random.Next(1, genreIDs.Count);
                        if (!addedID.Contains(randomID))
                        {
                            addedID.Add(randomID);
                            _context.movieGenres.Add(new MovieGenre {GenreID = randomID, MovieID = movie.ID});
                        }
                    }
                }
                _context.SaveChanges();
            }

            if(!_context.MovieTheaterMovies.Any())
            {
                var theaters = _context.MovieTheaters.ToList();
                var movies = _context.Movies.ToList();

                foreach(var movie in movies)
                {
                    var random = new Random();
                    var number = random.Next(1 , theaters.Count);
                    var addedID = new List<int>();
                    for(int i = 0; i < number; i++)
                    {
                        var randomID = random.Next(1 ,theaters.Count);
                        if (!addedID.Contains(randomID))
                        {
                            addedID.Add(randomID);
                            _context.MovieTheaterMovies.Add(new MovieTheaterMovies { MovieID = movie.ID, MovieTheaterID = randomID});
                        }
                    }
                }
                _context.SaveChanges();
            }

            if (!_context.MovieActors.Any())
            {
                string[] characters = new string[] { "Morgan", "Alex", "Emma", "Smith", "Luffy", "Kate", "Shanks", "Gwen", "Peter", "Nick", "Jack", "Joker", "James", "Adam", "Alan", "Green", "Ross", "GoodMen" };

                var movies = _context.Movies.ToList();

                foreach (var movie in movies)
                {
                    var actorID = _context.Actors.Select(x => x.ID).ToList();
                    var random = new Random();
                    var number = random.Next(1, 4);
                    var usedID = new List<int>();
                    for (int i = 0; i < number;i++)
                    {
                        var randomID = random.Next(1, actorID.Count);
                        if (!usedID.Contains(randomID))
                        {
                            usedID.Add(randomID);
                            _context.Add(new MovieActor { MovieID = movie.ID, ActorID = randomID, Character = characters[random.Next(0, characters.Length - 1)] });
                        }
                    }
                    _context.SaveChanges();
                }
            }
            if (!_context.Roles.Any())
            {
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    var adminRole = new IdentityRole("Admin");
                    var result = roleManager.CreateAsync(adminRole).Result;
                }

                if (!roleManager.RoleExistsAsync("User").Result)
                {
                    var userRole = new IdentityRole("User");
                    var result = roleManager.CreateAsync(userRole).Result;
                }
                _context.SaveChanges();
            }
            if (!_context.Users.Any())
            {
                if (userManager.FindByNameAsync("admin").Result == null)
                {
                    var adminUser = new IdentityUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com"
                    };

                    var result = userManager.CreateAsync(adminUser, "Password123#").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                        var claim = new Claim(ClaimTypes.Role, "admin");
                       userManager.AddClaimAsync(adminUser, claim).Wait();
                    }
                }
                _context.SaveChanges();
            }
            

            if (!_context.Ratings.Any())
            {
                var ratings = new List<Rating>();
                var movies = _context.Movies.ToList();
                var random = new Random();
                var user = _context.Users.FirstOrDefault();

                foreach(var movie in movies)
                {
                    ratings.Add(new Rating { MovieID = movie.ID, Rate = random.Next(1, 5), UserID = user.Id,  });
                }
                _context.AddRange(ratings);
                _context.SaveChanges();
            }
        }
    }
}
